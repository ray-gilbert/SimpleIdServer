﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using MassTransit;
using Microsoft.Extensions.Options;
using SimpleIdServer.Scim.Domain;
using SimpleIdServer.Scim.Domains;
using SimpleIdServer.Scim.DTOs;
using SimpleIdServer.Scim.Exceptions;
using SimpleIdServer.Scim.Helpers;
using SimpleIdServer.Scim.Infrastructure;
using SimpleIdServer.Scim.Persistence;
using SimpleIdServer.Scim.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleIdServer.Scim.Commands.Handlers
{
    public class PatchRepresentationCommandHandler : BaseCommandHandler, IPatchRepresentationCommandHandler
    {
        private readonly ISCIMSchemaCommandRepository _scimSchemaCommandRepository;
        private readonly ISCIMAttributeMappingQueryRepository _scimAttributeMappingQueryRepository;
        private readonly ISCIMRepresentationCommandRepository _scimRepresentationCommandRepository;
        private readonly IRepresentationReferenceSync _representationReferenceSync;
        private readonly SCIMHostOptions _options;

        public PatchRepresentationCommandHandler(
            ISCIMSchemaCommandRepository scimSchemaCommandRepository,
            ISCIMAttributeMappingQueryRepository scimAttributeMappingQueryRepository,
            ISCIMRepresentationCommandRepository scimRepresentationCommandRepository,
            IRepresentationReferenceSync representationReferenceSync,
            IOptions<SCIMHostOptions> options,
            IBusControl busControl) : base(busControl)
        {
            _scimSchemaCommandRepository = scimSchemaCommandRepository;
            _scimAttributeMappingQueryRepository = scimAttributeMappingQueryRepository;
            _scimRepresentationCommandRepository = scimRepresentationCommandRepository;
            _representationReferenceSync = representationReferenceSync;
            _options = options.Value;
        }

        public async virtual Task<GenericResult<PatchRepresentationResult>> Handle(PatchRepresentationCommand patchRepresentationCommand)
        {
            var schema = await _scimSchemaCommandRepository.FindRootSCIMSchemaByResourceType(patchRepresentationCommand.ResourceType);
            if (schema == null) throw new SCIMSchemaNotFoundException();
            CheckParameter(patchRepresentationCommand.PatchRepresentation);
            var existingRepresentation = await _scimRepresentationCommandRepository.Get(patchRepresentationCommand.Id);
            if (existingRepresentation == null) throw new SCIMNotFoundException(string.Format(Global.ResourceNotFound, patchRepresentationCommand.Id));
            return await UpdateRepresentation(existingRepresentation, patchRepresentationCommand, schema);
        }

        private async Task<GenericResult<PatchRepresentationResult>> UpdateRepresentation(SCIMRepresentation existingRepresentation, PatchRepresentationCommand patchRepresentationCommand, SCIMSchema schema)
        {
            var attributeMappings = await _scimAttributeMappingQueryRepository.GetBySourceResourceType(existingRepresentation.ResourceType);
            var oldDisplayName = existingRepresentation.DisplayName;
            var patchResult = existingRepresentation.ApplyPatches(patchRepresentationCommand.PatchRepresentation.Operations, attributeMappings, _options.IgnoreUnsupportedCanonicalValues);
            var displayNameDifferent = existingRepresentation.DisplayName != oldDisplayName;
            if (!patchResult.Any()) return GenericResult<PatchRepresentationResult>.Ok(PatchRepresentationResult.NoPatch());
            existingRepresentation.SetUpdated(DateTime.UtcNow);
            var references = _representationReferenceSync.Sync(patchRepresentationCommand.ResourceType, existingRepresentation, patchResult, patchRepresentationCommand.Location, schema, displayNameDifferent);
            using (var transaction = await _scimRepresentationCommandRepository.StartTransaction())
            {
                foreach (var reference in references)
                {
                    await _scimRepresentationCommandRepository.BulkInsert(reference.AddedRepresentationAttributes);
                    await _scimRepresentationCommandRepository.BulkUpdate(reference.UpdatedRepresentationAttributes);
                    await _scimRepresentationCommandRepository.BulkDelete(reference.RemovedRepresentationAttributes);
                    await Notify(reference);
                }

                await _scimRepresentationCommandRepository.Update(existingRepresentation);
                await transaction.Commit();
            }

            existingRepresentation.ApplyEmptyArray();
            return GenericResult<PatchRepresentationResult>.Ok(PatchRepresentationResult.Ok(existingRepresentation));
        }

        private void CheckParameter(PatchRepresentationParameter patchRepresentation)
        {
            if (patchRepresentation == null || (patchRepresentation.Operations != null && patchRepresentation.Operations.Any(o => o.Operation == null)))
            {
                throw new SCIMBadSyntaxException(string.Format(Global.RequestIsNotWellFormatted, "PATCH"));
            }

            var requestedSchemas = patchRepresentation.Schemas;
            if (!requestedSchemas.Any())
            {
                throw new SCIMBadSyntaxException(string.Format(Global.AttributeMissing, StandardSCIMRepresentationAttributes.Schemas));
            }

            if (!requestedSchemas.SequenceEqual(new List<string> { StandardSchemas.PatchRequestSchemas.Id }))
            {
                throw new SCIMBadSyntaxException(Global.SchemasNotRecognized);
            }

            if (patchRepresentation.Operations == null)
            {
                throw new SCIMBadSyntaxException(string.Format(Global.AttributeMissing, StandardSCIMRepresentationAttributes.Operations));
            }

            if(!patchRepresentation.Operations.Any())
            {
                throw new SCIMBadSyntaxException(Global.OperationsRequired);
            }
        }
    }
}
