﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using Microsoft.Extensions.Logging;
using SimpleIdServer.IdServer.Domains;
using SimpleIdServer.IdServer.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleIdServer.IdServer.Authenticate.Handlers
{
    public class OAuthClientTlsClientAuthenticationHandler : IOAuthClientAuthenticationHandler
    {
        private ILogger<OAuthClientTlsClientAuthenticationHandler> _logger;

        public OAuthClientTlsClientAuthenticationHandler(ILogger<OAuthClientTlsClientAuthenticationHandler> logger)
        {
            _logger = logger;
        }


        public const string AUTH_METHOD = "tls_client_auth";
        public string AuthMethod => "tls_client_auth";

        public Task<bool> Handle(AuthenticateInstruction authenticateInstruction, Client client, string expectedIssuer, CancellationToken cancellationToken, string errorCode = ErrorCodes.INVALID_CLIENT)
        {
            var certificate = authenticateInstruction.Certificate;
            if (certificate == null)throw new OAuthException(errorCode, ErrorMessages.NO_CLIENT_CERTIFICATE);
            if (!certificate.IsValid())
            {
                _logger.LogError("the certificate is not trusted");
                throw new OAuthException(errorCode, ErrorMessages.CERTIFICATE_IS_NOT_TRUSTED);
            }

            if (!string.IsNullOrWhiteSpace(client.TlsClientAuthSubjectDN) && client.TlsClientAuthSubjectDN != certificate.Subject) throw new OAuthException(errorCode, ErrorMessages.CERTIFICATE_SUBJECT_INVALID);
            var subjectAlternative = certificate.GetSubjectAlternativeName();
            if (!string.IsNullOrWhiteSpace(client.TlsClientAuthSanDNS) && !Check(client.TlsClientAuthSanDNS, SubjectAlternativeNameTypes.DNSNAME, subjectAlternative)) throw new OAuthException(errorCode, ErrorMessages.CERTIFICATE_SAN_DNS_INVALID);
            if (!string.IsNullOrWhiteSpace(client.TlsClientAuthSanEmail) && !Check(client.TlsClientAuthSanEmail, SubjectAlternativeNameTypes.EMAIL, subjectAlternative)) throw new OAuthException(errorCode, ErrorMessages.CERTIFICATE_SAN_EMAIL_INVALID);
            if (!string.IsNullOrWhiteSpace(client.TlsClientAuthSanIP) && !Check(client.TlsClientAuthSanIP, SubjectAlternativeNameTypes.IPADDRESS, subjectAlternative)) throw new OAuthException(errorCode, ErrorMessages.CERTIFICATE_SAN_IP_INVALID);
            return Task.FromResult(true);
        }

        private static bool Check(string value, SubjectAlternativeNameTypes type, List<KeyValuePair<SubjectAlternativeNameTypes, string>> san)
        {
            if (!san.Any(_ => _.Key == type && _.Value == value))
            {
                return false;
            }

            return true;
        }
    }
}
