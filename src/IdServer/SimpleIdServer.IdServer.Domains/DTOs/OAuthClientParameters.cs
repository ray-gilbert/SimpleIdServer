﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
namespace SimpleIdServer.IdServer.Domains.DTOs
{
    public class OAuthClientParameters
    {
        public const string ClientId = "client_id";
        public const string ClientSecret = "client_secret";
        public const string ClientIdIssuedAt = "client_id_issued_at";
        public const string ClientSecretExpiresAt = "client_secret_expires_at";
        public const string RegistrationAccessToken = "registration_access_token";
        public const string GrantTypes = "grant_types";
        public const string RedirectUris = "redirect_uris";
        public const string TokenEndpointAuthMethod = "token_endpoint_auth_method";
        public const string ResponseTypes = "response_types";
        public const string ClientName = "client_name";
        public const string ClientUri = "client_uri";
        public const string LogoUri = "logo_uri";
        public const string Scope = "scope";
        public const string Contacts = "contacts";
        public const string TosUri = "tos_uri";
        public const string PolicyUri = "policy_uri";
        public const string JwksUri = "jwks_uri";
        public const string Jwks = "jwks";
        public const string SoftwareId = "software_id";
        public const string SoftwareVersion = "software_version";
        public const string SoftwareStatement = "software_statement";
        public const string TokenSignedResponseAlg = "token_signed_response_alg";
        public const string TokenEncryptedResponseAlg = "token_encrypted_response_alg";
        public const string TokenEncryptedResponseEnc = "token_encrypted_response_enc";
        public const string TokenExpirationTimeInSeconds = "token_expiration_time_seconds";
        public const string RefreshTokenExpirationTimeInSeconds = "refresh_token_expiration_time_seconds";
        public const string RegistrationClientUri = "registration_client_uri";
        public const string TlsClientAuthSubjectDN = "tls_client_auth_subject_dn";
        public const string TlsClientAuthSanDNS = "tls_client_auth_san_dns";
        public const string TlsClientAuthSanUri = "tls_client_auth_san_uri";
        public const string TlsClientAuthSanIp = "tls_client_auth_san_ip";
        public const string TlsClientAuthSanEmail = "tls_client_auth_san_email";
        public const string UpdateDateTime = "update_datetime";
        public const string CreateDateTime = "create_datetime";
        public const string PostLogoutRedirectUris = "post_logout_redirect_uris";
        public const string PreferredTokenProfile = "preferred_token_profile";
        public const string TlsClientCertificateBoundAccessToken = "tls_client_certificate_bound_access_token";
        public const string IsConsentDisabled = "is_consent_disabled";
        public const string RequestObjectSigningAlg = "request_object_signing_alg";
        public const string RequestObjectEncryptionAlg = "request_object_encryption_alg";
        public const string RequestObjectEncryptionEnc = "request_object_encryption_enc";
        public const string SubjectType = "subject_type";
        public const string SectorIdentifierUri = "sector_identifier_uri";
        public const string IdTokenSignedResponseAlg = "id_token_signed_response_alg";
        public const string IdTokenEncryptedResponseAlg = "id_token_encrypted_response_alg";
        public const string IdTokenEncryptedResponseEnc = "id_token_encrypted_response_enc";
        public const string BCTokenDeliveryMode = "backchannel_token_delivery_mode";
        public const string BCClientNotificationEndpoint = "backchannel_client_notification_endpoint";
        public const string BCAuthenticationRequestSigningAlg = "backchannel_authentication_request_signing_alg";
        public const string BCUserCodeParameter = "backchannel_user_code_parameter";
        public const string UserInfoSignedResponseAlg = "userinfo_signed_response_alg";
        public const string UserInfoEncryptedResponseAlg = "userinfo_encrypted_response_alg";
        public const string UserInfoEncryptedResponseEnc = "userinfo_encrypted_response_enc";
        public const string FrontChannelLogoutUri = "frontchannel_logout_uri";
        public const string FrontChannelLogoutSessionRequired = "frontchannel_logout_session_required";
        public const string BackChannelLogoutSessionRequired = "backchannel_logout_session_required";
        public const string BackChannelLogoutUri = "backchannel_logout_uri";
        public const string ApplicationType = "application_type";
        public const string InitiateLoginUri = "initiate_login_uri";
        public const string DefaultMaxAge = "default_max_age";
        public const string DefaultAcrValues = "default_acr_values";
        public const string RequireAuthTime = "require_auth_time";
        public const string AuthorizationSignedResponseAlg = "authorization_signed_response_alg";
        public const string AuthorizationEncryptedResponseAlg = "authorization_encrypted_response_alg";
        public const string AuthorizationEncryptedResponseEnc = "authorization_encrypted_response_enc";
        public const string AuthorizationDataTypes = "authorization_data_types";
        public const string CredentialOfferEndpoint = "credential_offer_endpoint";
    }
}
