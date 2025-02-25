﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using SimpleIdServer.IdServer.Domains.DTOs;
using SimpleIdServer.IdServer.Helpers;
using System.Text.Json.Serialization;

namespace SimpleIdServer.IdServer.Domains
{
    public class UserCredential : ICloneable
    {
        public const string PWD = "pwd";
        public const string OTP = "otp";

        public UserCredential()
        {

        }

        [JsonIgnore]
        public string Id { get; set; } = null!;
        [JsonPropertyName(UserCredentialNames.Type)]
        public string CredentialType { get; set; } = null!;
        [JsonPropertyName(UserCredentialNames.Value)]
        public string Value { get; set; } = null!;
        [JsonIgnore]
        public OTPAlgs? OTPAlg { get; set; } = null;
        [JsonIgnore]
        public bool IsActive { get; set; }
        [JsonIgnore]
        public int OTPCounter { get; set; } = 0;
        [JsonIgnore]
        public User User { get; set; }

        public byte[] OTPKey => CredentialType == PWD ? null : Value?.ConvertToBase32();

        public object Clone()
        {
            return new UserCredential
            {
                CredentialType = CredentialType,
                Value = Value
            };
        }

        public static UserCredential CreatePassword(string pwd) => new UserCredential { Id = Guid.NewGuid().ToString(), CredentialType = "pwd", Value = PasswordHelper.ComputeHash(pwd) };
    }

    public enum OTPAlgs
    {
        HOTP = 0,
        TOTP = 1
    }
}
