﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using Microsoft.EntityFrameworkCore;
using SimpleIdServer.IdServer.Api;
using SimpleIdServer.IdServer.Domains;
using SimpleIdServer.IdServer.Store;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleIdServer.IdServer.Extractors
{
    public interface IClaimsExtractor
    {
        Task<Dictionary<string, object>> ResolveGroupsAndExtract(HandlerContext context, IEnumerable<IClaimMappingRule> mappingRules);
        Dictionary<string, object> Extract(HandlerContext context, IEnumerable<IClaimMappingRule> mappingRules);
    }

    public class ClaimsExtractor : IClaimsExtractor
    {
        private readonly IEnumerable<IClaimExtractor> _extractors;
        private readonly IGroupRepository _groupRepository;

        public ClaimsExtractor(IEnumerable<IClaimExtractor> extractors, IGroupRepository groupRepository)
        {
            _extractors = extractors;
            _groupRepository = groupRepository;
        }

        public async Task<Dictionary<string, object>> ResolveGroupsAndExtract(HandlerContext context, IEnumerable<IClaimMappingRule> mappingRules)
        {
            var grpPathLst = context.User.Groups.SelectMany(g => g.ResolveAllPath()).Distinct();
            var allGroups = await _groupRepository.Query().Include(g => g.Roles).AsNoTracking().Where(g => grpPathLst.Contains(g.FullPath)).ToListAsync();
            var roles = allGroups.SelectMany(g => g.Roles).Select(r => r.Name).Distinct();
            foreach (var role in roles)
                context.User.AddClaim(Constants.UserClaims.Role, role);
            return Extract(context, mappingRules);
        }

        public Dictionary<string, object> Extract(HandlerContext context, IEnumerable<IClaimMappingRule> mappingRules)
        {
            var dic = new Dictionary<string, object>();
            foreach(var mappingRule in mappingRules)
            {
                var extractor = _extractors.Single(e => e.MappingRuleType == mappingRule.MapperType);
                var value = extractor.Extract(context, mappingRule);
                var splittedPath = mappingRule.TargetClaimPath.Split('.');
                Populate(dic, value, splittedPath);
            }

            return dic;
        }

        protected static void Populate(Dictionary<string, object> dic, object value, string[] splittedPath, int level = 0)
        {
            var isRoot = splittedPath.Length - 1 == level;
            var name = splittedPath[level];
            if(!dic.ContainsKey(name))
            {
                if (isRoot) dic.Add(name, value);
                else dic.Add(name, new Dictionary<string, object>());
            }

            if(!isRoot)
            {
                var val = dic[name] as Dictionary<string, object>;
                Populate(val, value, splittedPath, level + 1);
            }
        }
    }
}
