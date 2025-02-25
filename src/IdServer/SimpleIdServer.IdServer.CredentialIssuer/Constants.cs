﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

namespace SimpleIdServer.IdServer.CredentialIssuer
{
    public static class Constants
    {
        public static class EndPoints
        {
            public const string CredentialIssuer = ".well-known/openid-credential-issuer";
            public const string Credential = "credential";
            public const string CredentialOffer = "credential_offer";
        }

        public static class StandardAuthorizationDetails
        {
            public const string OpenIdCredential = "openid_credential";
        }

        public static class StandardProofTypes
        {
            public const string Jwt = "jwt";
        }
    }
}
