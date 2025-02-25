﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using SimpleIdServer.IdServer.Domains.DTOs;
using System.Text.Json.Serialization;

namespace SimpleIdServer.IdServer.Api.Users
{
    public class ReplaceCredentialRequest
    {
        /// <summary>
        /// Types of credential for example : pwd, otp.
        /// </summary>
        [JsonPropertyName(UserCredentialNames.Type)]
        public string Type { get; set; }
        /// <summary>
        /// Value.
        /// </summary>
        [JsonPropertyName(UserCredentialNames.Value)]
        public string Value { get; set; }
    }
}
