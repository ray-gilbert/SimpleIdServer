﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
namespace SimpleIdServer.IdServer.Domains
{
    public class IdentityProvisioningProperty : IPropertyInstance
    {
        public string PropertyName { get; set; } = null!;
        public string? Value { get; set; } = null;
        public IdentityProvisioning IdentityProvisioning { get; set; } = null!;
    }
}
