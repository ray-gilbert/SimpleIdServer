﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using Fluxor;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QRCoder;
using Radzen;
using SimpleIdServer.IdServer.Domains;
using SimpleIdServer.IdServer.Store;
using SimpleIdServer.IdServer.Website.Resources;
using SimpleIdServer.IdServer.Website.Stores.Base;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Text.Json.Nodes;

namespace SimpleIdServer.IdServer.Website.Stores.UserStore
{
    public class UserEffects
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly IDbContextFactory<StoreDbContext> _factory;
        private readonly IWebsiteHttpClientFactory _websiteHttpClientFactory;
        private readonly ProtectedSessionStorage _sessionStorage;
        private readonly IdServerWebsiteOptions _websiteOptions;
        private readonly DefaultSecurityOptions _securityOptions;

        public UserEffects(
            ILoggerFactory loggerFactory,
            IDbContextFactory<StoreDbContext> factory,
            IWebsiteHttpClientFactory websiteHttpClientFactory,
            ProtectedSessionStorage sessionStorage,
            DbContextOptions<StoreDbContext> options,
            DefaultSecurityOptions securityOptions)
        {
            _loggerFactory = loggerFactory;
            _factory = factory;
            _websiteHttpClientFactory = websiteHttpClientFactory;
            _sessionStorage = sessionStorage;
            _securityOptions = securityOptions;
        }

        [EffectMethod]
        public async Task Handle(SearchUsersAction action, IDispatcher dispatcher)
        {
            var realm = await GetRealm();
            using (var dbContext = _factory.CreateDbContext())
            {
                IQueryable<User> query = dbContext.Users.Include(u => u.Realms).Include(u => u.OAuthUserClaims).Where(u => u.Realms.Any(r => r.RealmsName == realm)).AsNoTracking();
                if (!string.IsNullOrWhiteSpace(action.Filter))
                    query = query.Where(SanitizeExpression(action.Filter));

                if (!string.IsNullOrWhiteSpace(action.OrderBy))
                    query = query.OrderBy(SanitizeExpression(action.OrderBy));

                var count = query.Count();
                var users = await query.Skip(action.Skip.Value).Take(action.Take.Value).ToListAsync(CancellationToken.None);
                dispatcher.Dispatch(new SearchUsersSuccessAction { Users = users, Count = count });
            }

            string SanitizeExpression(string expression) => expression.Replace("Value.", "");
        }

        [EffectMethod]
        public async Task Handle(GetUserAction action, IDispatcher dispatcher)
        {
            var realm = await GetRealm();
            using (var dbContext = _factory.CreateDbContext())
            {
                var user = await dbContext.Users.Include(u => u.Realms).Include(u => u.OAuthUserClaims).Include(u => u.CredentialOffers).Include(u => u.Groups).Include(u => u.Consents).ThenInclude(c => c.Scopes).Include(u => u.Sessions).Include(u => u.Credentials).Include(u => u.ExternalAuthProviders).Include(u => u.CredentialOffers).AsNoTracking().SingleOrDefaultAsync(a => a.Id == action.UserId && a.Realms.Any(r => r.RealmsName == realm));
                if (user == null)
                {
                    dispatcher.Dispatch(new GetUserFailureAction { ErrorMessage = string.Format(Global.UnknownUser, action.UserId) });
                    return;
                }

                user.Consents = user.Consents.Where(c => c.Realm == realm).ToList();
                user.Sessions = user.Sessions.Where(c => c.Realm == realm).ToList();
                dispatcher.Dispatch(new GetUserSuccessAction { User = user });
            }
        }

        [EffectMethod]
        public async Task Handle(UpdateUserDetailsAction action, IDispatcher dispatcher)
        {
            var realm = await GetRealm();
            using (var dbContext = _factory.CreateDbContext())
            {
                var user = await dbContext.Users.Include(u => u.Realms).Include(u => u.OAuthUserClaims).SingleOrDefaultAsync(a => a.Id == action.UserId && a.Realms.Any(r => r.RealmsName == realm));
                user.UpdateEmail(action.Email);
                user.UpdateName(action.Firstname);
                user.UpdateLastname(action.Lastname);
                user.UpdateDateTime = DateTime.UtcNow;
                await dbContext.SaveChangesAsync(CancellationToken.None);
                dispatcher.Dispatch(new UpdateUserDetailsSuccessAction { Email = action.Email, Firstname = action.Firstname, Lastname = action.Lastname, UserId = action.UserId });
            }
        }

        [EffectMethod]
        public async Task Handle(RevokeUserConsentAction action, IDispatcher dispatcher)
        {
            var realm = await GetRealm();
            using (var dbContext = _factory.CreateDbContext())
            {
                var user = await dbContext.Users.Include(u => u.Realms).Include(u => u.Consents).SingleAsync(a => a.Id == action.UserId && a.Realms.Any(r => r.RealmsName == realm));
                var consent = user.Consents.Single(c => c.Id == action.ConsentId);
                user.Consents.Remove(consent);
                await dbContext.SaveChangesAsync(CancellationToken.None);
                dispatcher.Dispatch(new RevokeUserConsentSuccessAction { ConsentId = action.ConsentId, UserId = action.UserId });
            }
        }

        [EffectMethod]
        public async Task Handle(UnlinkExternalAuthProviderAction action, IDispatcher dispatcher)
        {
            var realm = await GetRealm();
            using (var dbContext = _factory.CreateDbContext())
            {
                var user = await dbContext.Users.Include(u => u.Realms).Include(u => u.ExternalAuthProviders).SingleAsync(a => a.Id == action.UserId && a.Realms.Any(r => r.RealmsName == realm));
                var externalAuthProvider = user.ExternalAuthProviders.Single(c => c.Scheme == action.Scheme && c.Subject == action.Subject);
                user.ExternalAuthProviders.Remove(externalAuthProvider);
                await dbContext.SaveChangesAsync(CancellationToken.None);
                dispatcher.Dispatch(new UnlinkExternalAuthProviderSuccessAction { Scheme = action.Scheme, Subject = action.Subject, UserId = action.UserId });
            }
        }

        [EffectMethod]
        public async Task Handle(RevokeUserSessionAction action, IDispatcher dispatcher)
        {
            var realm = await GetRealm();
            using (var dbContext = _factory.CreateDbContext())
            {
                var user = await dbContext.Users.Include(u => u.Realms).Include(u => u.Sessions).SingleAsync(a => a.Id == action.UserId && a.Realms.Any(r => r.RealmsName == realm));
                var session = user.Sessions.Single(s => s.SessionId == action.SessionId);
                session.State = UserSessionStates.Rejected;
                await dbContext.SaveChangesAsync(CancellationToken.None);
                dispatcher.Dispatch(new RevokeUserSessionSuccessAction { SessionId = action.SessionId, UserId = action.UserId });
            }
        }

        [EffectMethod]
        public async Task Handle(UpdateUserClaimsAction action, IDispatcher dispatcher)
        {
            var realm = await GetRealm();
            using (var dbContext = _factory.CreateDbContext())
            {
                var user = await dbContext.Users.Include(u => u.Realms).Include(u => u.OAuthUserClaims).SingleAsync(a => a.Id == action.UserId && a.Realms.Any(r => r.RealmsName == realm));
                user.OAuthUserClaims.Clear();
                var fileteredClaims = action.Claims.Where(c => !string.IsNullOrWhiteSpace(c.Value) && !string.IsNullOrWhiteSpace(c.Name));
                foreach (var cl in fileteredClaims)
                    user.OAuthUserClaims.Add(new UserClaim { Id = Guid.NewGuid().ToString(), Name = cl.Name, Value = cl.Value });

                await dbContext.SaveChangesAsync(CancellationToken.None);
                dispatcher.Dispatch(new UpdateUserClaimsSuccessAction { UserId = action.UserId, Claims = fileteredClaims.ToList() });
            }
        }

        [EffectMethod]
        public async Task Handle(AddUserCredentialAction action, IDispatcher dispatcher)
        {
            var realm = await GetRealm();
            using (var dbContext = _factory.CreateDbContext())
            {
                var user = await dbContext.Users.Include(u => u.Realms).Include(u => u.Credentials).SingleAsync(a => a.Id == action.UserId && a.Realms.Any(r => r.RealmsName == realm));
                if (action.IsDefault)
                {
                    foreach (var act in user.Credentials.Where(c => c.CredentialType == action.Credential.CredentialType))
                        act.IsActive = false;
                    action.Credential.IsActive = true;
                }

                user.Credentials.Add(action.Credential);
                await dbContext.SaveChangesAsync(CancellationToken.None);
                dispatcher.Dispatch(new AddUserCredentialSuccessAction { Credential = action.Credential, IsDefault = action.IsDefault });
            }
        }

        [EffectMethod]
        public async Task Handle(UpdateUserCredentialAction action, IDispatcher dispatcher)
        {
            var realm = await GetRealm();
            using (var dbContext = _factory.CreateDbContext())
            {
                var user = await dbContext.Users.Include(u => u.Realms).Include(u => u.Credentials).SingleAsync(a => a.Id == action.UserId && a.Realms.Any(r => r.RealmsName == realm));
                var credential = user.Credentials.Single(c => c.Id == action.Credential.Id);
                credential.Value = action.Credential.Value;
                credential.OTPAlg = action.Credential.OTPAlg;
                await dbContext.SaveChangesAsync(CancellationToken.None);
                dispatcher.Dispatch(new UpdateUserCredentialSuccessAction { Credential = action.Credential });
            }
        }

        [EffectMethod]
        public async Task Handle(RemoveUserCredentialAction action, IDispatcher dispatcher)
        {
            var realm = await GetRealm();
            using (var dbContext = _factory.CreateDbContext())
            {
                var user = await dbContext.Users.Include(u => u.Realms).Include(u => u.Credentials).SingleAsync(a => a.Id == action.UserId && a.Realms.Any(r => r.RealmsName == realm));
                var credential = user.Credentials.Single(c => c.Id == action.CredentialId);
                user.Credentials.Remove(credential);
                await dbContext.SaveChangesAsync(CancellationToken.None);
                dispatcher.Dispatch(new RemoveUserCredentialSuccessAction { CredentialId = action.CredentialId });
            }
        }

        [EffectMethod]
        public async Task Handle(DefaultUserCredentialAction action, IDispatcher dispatcher)
        {
            var realm = await GetRealm();
            using (var dbContext = _factory.CreateDbContext())
            {
                var user = await dbContext.Users.Include(u => u.Realms).Include(u => u.Credentials).SingleAsync(a => a.Id == action.UserId && a.Realms.Any(r => r.RealmsName == realm));
                var credential = user.Credentials.Single(c => c.Id == action.CredentialId);
                foreach (var cred in user.Credentials.Where(c => c.CredentialType == credential.CredentialType))
                    cred.IsActive = false;
                credential.IsActive = true;
                await dbContext.SaveChangesAsync(CancellationToken.None);
                dispatcher.Dispatch(new DefaultUserCredentialSuccessAction { CredentialId = action.CredentialId, UserId = action.UserId });
            }
        }

        [EffectMethod]
        public async Task Handle(RemoveSelectedUserGroupAction action, IDispatcher dispatcher)
        {
            using (var dbContext = _factory.CreateDbContext())
            {
                var user = await dbContext.Users.Include(u => u.Groups).SingleAsync(u => u.Id == action.UserId);
                user.Groups = user.Groups.Where(g => !action.GroupIds.Contains(g.Id)).ToList();
                await dbContext.SaveChangesAsync(CancellationToken.None);
                dispatcher.Dispatch(new RemoveSelectedUserGroupSuccessAction { GroupIds = action.GroupIds, UserId = action.UserId });
            }
        }

        [EffectMethod]
        public async Task Handle(AssignUserGroupsAction action, IDispatcher dispatcher)
        {
            using (var dbContext = _factory.CreateDbContext())
            {
                var realm = await GetRealm();
                var activeRealm = await dbContext.Realms.FirstAsync(r => r.Name == realm);
                var groups = await dbContext.Groups.Include(s => s.Realms).Where(s => action.GroupIds.Contains(s.Id) && s.Realms.Any(r => r.Name == realm)).ToListAsync(CancellationToken.None);
                var user = await dbContext.Users.Include(u => u.Groups).SingleAsync(u => u.Id == action.UserId);
                foreach (var grp in groups)
                    user.Groups.Add(grp);
                await dbContext.SaveChangesAsync(CancellationToken.None);
                dispatcher.Dispatch(new AssignUserGroupsSuccessAction { Groups = groups, UserId = action.UserId });
            }
        }

        [EffectMethod]
        public async Task Handle(ResolveUserRolesAction action, IDispatcher dispatcher)
        {
            if (!action.IsSelected) return;
            using (var dbContext = _factory.CreateDbContext())
            {
                var user = await dbContext.Users.Include(u => u.Groups).AsNoTracking().SingleAsync(u => u.Id == action.UserId);
                var grpPathLst = user.Groups.SelectMany(g => g.ResolveAllPath()).Distinct();
                var allGroups = await dbContext.Groups.Include(g => g.Roles).AsNoTracking().Where(g => grpPathLst.Contains(g.FullPath)).ToListAsync();
                var roles = allGroups.SelectMany(g => g.Roles).Select(r => r.Name).Distinct();
                dispatcher.Dispatch(new ResolveUserRolesSuccessAction { Roles = roles, UserId = user.Id });
            }
        }

        [EffectMethod]
        public async Task Handle(RemoveSelectedUsersAction action, IDispatcher dispatcher)
        {
            using (var dbContext = _factory.CreateDbContext())
            {
                var users = await dbContext.Users.Where(u => action.UserIds.Contains(u.Id)).ToListAsync();
                dbContext.Users.RemoveRange(users);
                await dbContext.SaveChangesAsync(CancellationToken.None);
                dispatcher.Dispatch(new RemoveSelectedUsersSuccessAction { UserIds = action.UserIds });
            }
        }

        [EffectMethod]
        public async Task Handle(AddUserAction action, IDispatcher dispatcher)
        {
            ILogger logger = _loggerFactory.CreateLogger("Effect for AddUserAction");
            logger.LogDebug("Attempting to create an user.");

            if (string.IsNullOrEmpty(action.Name))
            {
                dispatcher.Dispatch(new AddUserFailureAction() { ErrorMessage = $"The field 'Name' is required." });
                return;
            }

            using (var dbContext = _factory.CreateDbContext())
            {
                string nameLower = action.Name.ToLower();
                bool userExists = dbContext.Users.Any(u => u.Name.ToLower() == nameLower);

                if (userExists)
                {
                    string message = $"The user '{action.Name}' already exists.";
                    dispatcher.Dispatch(new AddUserFailureAction() { ErrorMessage = message });
                    logger.LogDebug(message);
                    return;
                }

                string id = Guid.NewGuid().ToString();
                string realm = await GetRealm();

                var newUser = new User()
                {
                    Id = id,
                    Name = action.Name,
                    Firstname = action.Firstname,
                    Lastname = action.Lastname,
                    Email = action.Email,
                    CreateDateTime = DateTime.UtcNow,
                    UpdateDateTime = DateTime.UtcNow
                };

                newUser.Realms.Add(new RealmUser() { RealmsName = realm, UsersId = id });
                dbContext.Users.Add(newUser);

                await dbContext.SaveChangesAsync(CancellationToken.None);

                dispatcher.Dispatch(new AddUserSuccessAction()
                {
                    Id = id,
                    Email = action.Email,
                    Firstname = action.Firstname,
                    Lastname = action.Lastname,
                    Name = action.Name
                });

                logger.LogInformation($"The user '{action.Name}' was added succesfully.");
            }
        }

        [EffectMethod]
        public async Task Handle(RemoveSelectedUserCredentialOffersAction action, IDispatcher dispatcher)
        {
            using (var dbContext = _factory.CreateDbContext())
            {
                var user = await dbContext.Users.Include(u => u.CredentialOffers).FirstOrDefaultAsync(u => u.Id == action.UserId);
                user.CredentialOffers = user.CredentialOffers.Where(c => !action.CredentialOffersId.Contains(c.Id)).ToList();
                await dbContext.SaveChangesAsync(CancellationToken.None);
                dispatcher.Dispatch(new RemoveSelectedUserCredentialOffersSuccessAction { CredentialOffersId = action.CredentialOffersId });
            }
        }

        [EffectMethod]
        public async Task Handle(ShareCredentialOfferAction action, IDispatcher dispatcher)
        {
            var realm = await GetRealm();
            var httpClient = await _websiteHttpClientFactory.Build();
            var request = new JsonObject
            {
                { "credential_template_id", action.CredentialTemplateId },
                { "wallet_client_id", action.ClientId }
            };
            var requestMessage = new HttpRequestMessage
            {
                RequestUri = new Uri($"{_websiteOptions.IdServerBaseUrl}/{realm}/credential_offer/share/{action.UserName}"),
                Method = HttpMethod.Post,
                Content = new StringContent(request.ToJsonString(), Encoding.UTF8, "application/json")
            };
            var httpResult = await httpClient.SendAsync(requestMessage);
            var json = await httpResult.Content.ReadAsStringAsync();
            if(httpResult.StatusCode == System.Net.HttpStatusCode.Redirect)
            {
                var credentialOffer = httpResult.Headers.Location.OriginalString;
                var picture = GetQRCode(credentialOffer);
                dispatcher.Dispatch(new ShareCredentialOfferSuccessAction { Picture = picture, CredentialOffer = credentialOffer });
                dispatcher.Dispatch(new GetUserAction { UserId = action.UserId });
                return;
            }

            var jObj = JsonObject.Parse(json);
            dispatcher.Dispatch(new ShareCredentialOfferFailureAction { ErrorMessage = jObj["error_description"].GetValue<string>() });

            string GetQRCode(string url)
            {
                var qrGenerator = new QRCodeGenerator();
                var qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
                var qrCode = new Base64QRCode(qrCodeData);
                var payload = qrCode.GetGraphic(20);
                return $"data:image/jpeg;base64,{payload}";
            }
        }

        [EffectMethod]
        public async Task Handle(GenerateDIDEthrAction action, IDispatcher dispatcher)
        {
            var realm = await GetRealm();
            var httpClient = await _websiteHttpClientFactory.Build();
            var request = new JsonObject
            {
                { "method", "ethr" },
                { "publicKey", action.PublicKey },
                { "network", action.NetworkName }
            };
            var requestMessage = new HttpRequestMessage
            {
                RequestUri = new Uri($"{_websiteOptions.IdServerBaseUrl}/{realm}/users/{action.UserId}/did"),
                Method = HttpMethod.Post,
                Content = new StringContent(request.ToJsonString(), Encoding.UTF8, "application/json")
            };
            var httpResult = await httpClient.SendAsync(requestMessage);
            var json = await httpResult.Content.ReadAsStringAsync();
            try
            {
                httpResult.EnsureSuccessStatusCode();
                var jObj = JsonObject.Parse(json);
                dispatcher.Dispatch(new GenerateDIDEthrSuccessAction { UserId = action.UserId, Did = jObj["did"].GetValue<string>(), DidPrivateHex = jObj["private_key"].GetValue<string>() });
            }
            catch
            {
                var jObj = JsonObject.Parse(json);
                dispatcher.Dispatch(new GenerateDIDEthrFailureAction { ErrorMessage = jObj["error_description"].GetValue<string>() });
            }
        }


        [EffectMethod]
        public async Task Handle(GenerateDIDKeyAction action, IDispatcher dispatcher)
        {
            var realm = await GetRealm();
            var httpClient = await _websiteHttpClientFactory.Build();
            var request = new JsonObject
            {
                { "method", "key" }
            };
            var requestMessage = new HttpRequestMessage
            {
                RequestUri = new Uri($"{_websiteOptions.IdServerBaseUrl}/{realm}/users/{action.UserId}/did"),
                Method = HttpMethod.Post,
                Content = new StringContent(request.ToJsonString(), Encoding.UTF8, "application/json")
            };
            var httpResult = await httpClient.SendAsync(requestMessage);
            var json = await httpResult.Content.ReadAsStringAsync();
            try
            {
                httpResult.EnsureSuccessStatusCode();
                var jObj = JsonObject.Parse(json);
                dispatcher.Dispatch(new GenerateDIDKeySuccessAction { UserId = action.UserId, Did = jObj["did"].GetValue<string>(), DidPrivateHex = jObj["private_key"].GetValue<string>() });
            }
            catch
            {
                var jObj = JsonObject.Parse(json);
                dispatcher.Dispatch(new GenerateDIDKeyFailureAction { ErrorMessage = jObj["error_description"].GetValue<string>() });
            }
        }

        private async Task<string> GetRealm()
        {
            var realm = await _sessionStorage.GetAsync<string>("realm");
            var realmStr = !string.IsNullOrWhiteSpace(realm.Value) ? realm.Value : SimpleIdServer.IdServer.Constants.DefaultRealm;
            return realmStr;
        }
    }

    public class SearchUsersAction
    {
        public string? Filter { get; set; } = null;
        public string? OrderBy { get; set; } = null;
        public int? Skip { get; set; } = null;
        public int? Take { get; set; } = null;
    }

    public class SearchUsersSuccessAction
    {
        public IEnumerable<User> Users { get; set; } = new List<User>();
        public int Count { get; set; }
    }

    public class ToggleUserSelectionAction
    {
        public bool IsSelected { get; set; } = false;
        public string UserId { get; set; } = null!;
    }

    public class ToggleAllUserSelectionAction
    {
        public bool IsSelected { get; set; } = false;
    }

    public class GetUserAction
    {
        public string UserId { get; set; } = null!;
    }

    public class GetUserSuccessAction
    {
        public User User { get; set; } = null!;
    }

    public class GetUserFailureAction
    {
        public string UserId { get; set; } = null!;
        public string ErrorMessage { get; set; } = null!;
    }

    public class UpdateUserDetailsAction
    {
        public string UserId { get; set; } = null!;
        public string? Email { get; set; } = null;
        public string? Firstname { get; set; } = null;
        public string? Lastname { get; set; } = null;
    }

    public class UpdateUserDetailsSuccessAction
    {
        public string UserId { get; set; } = null!;
        public string? Email { get; set; } = null;
        public string? Firstname { get; set; } = null;
        public string? Lastname { get; set; } = null;
    }

    public class RevokeUserConsentAction
    {
        public string UserId { get; set; } = null!;
        public string ConsentId { get; set; } = null!;
    }

    public class RevokeUserConsentSuccessAction
    {
        public string UserId { get; set; } = null!;
        public string ConsentId { get; set; } = null!;
    }

    public class UnlinkExternalAuthProviderAction
    {
        public string UserId { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string Scheme { get; set; } = null!;
    }

    public class UnlinkExternalAuthProviderSuccessAction
    {
        public string UserId { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string Scheme { get; set; } = null!;
    }

    public class RevokeUserSessionAction
    {
        public string UserId { get; set; } = null!;
        public string SessionId { get; set; } = null!;
    }

    public class RevokeUserSessionSuccessAction
    {
        public string UserId { get; set; } = null!;
        public string SessionId { get; set; } = null!;
    }

    public class UpdateUserClaimsAction
    {
        public string UserId { get; set; } = null!;
        public ICollection<UserClaim> Claims { get; set; } = new List<UserClaim>();
    }

    public class UpdateUserClaimsSuccessAction
    {
        public string UserId { get; set; } = null!;
        public ICollection<UserClaim> Claims { get; set; } = new List<UserClaim>();
    }

    public class AddUserClaimAction
    {
        public string Key { get; set; } = null!;
        public string Value { get; set; } = null!;
    }

    public class RemoveUserClaimAction
    {
        public string Id { get; set; } = null!;
    }

    public class AddUserCredentialAction
    {
        public string UserId { get; set; } = null!;
        public bool IsDefault { get; set; } = false;
        public UserCredential Credential { get; set; } = null!;
    }

    public class AddUserCredentialSuccessAction
    {
        public UserCredential Credential { get; set; } = null!;
        public bool IsDefault { get; set; } = false;
    }

    public class UpdateUserCredentialAction
    {
        public string UserId { get; set; } = null!;
        public UserCredential Credential { get; set; } = null!;
    }

    public class UpdateUserCredentialSuccessAction
    {
        public UserCredential Credential { get; set; } = null!;
    }

    public class RemoveUserCredentialAction
    {
        public string UserId { get; set; } = null!;
        public string CredentialId { get; set; } = null!;
    }

    public class RemoveUserCredentialSuccessAction
    {
        public string CredentialId { get; set; } = null!;
    }

    public class DefaultUserCredentialAction
    {
        public string UserId { get; set; } = null!;
        public string CredentialId { get; set; } = null!;
    }

    public class DefaultUserCredentialSuccessAction
    {
        public string UserId { get; set; } = null!;
        public string CredentialId { get; set; } = null!;
    }

    public class ToggleAllUserGroupsAction
    {
        public bool IsSelected { get; set; }
    }

    public class ToggleUserGroupAction
    {
        public string GroupId { get; set; }
        public bool IsSelected { get; set; }
    }

    public class RemoveSelectedUserGroupAction
    {
        public IEnumerable<string> GroupIds { get; set; }
        public string UserId { get; set; }
    }

    public class RemoveSelectedUserGroupSuccessAction
    {
        public string UserId { get; set; }
        public IEnumerable<string> GroupIds { get; set; }
    }

    public class AssignUserGroupsAction
    {
        public string UserId { get; set; }
        public IEnumerable<string> GroupIds { get; set; }
    }

    public class AssignUserGroupsSuccessAction
    {
        public string UserId { get; set; }
        public IEnumerable<SimpleIdServer.IdServer.Domains.Group> Groups { get; set; }
    }

    public class ResolveUserRolesAction
    {
        public string UserId { get; set; }
        public bool IsSelected { get; set; }
    }

    public class ResolveUserRolesSuccessAction
    {
        public string UserId { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }

    /// <summary>
    /// Represents the information needed to add an user.
    /// </summary>
    public class AddUserAction
    {
        /// <summary>
        /// The username to use when login.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// (Optional) The user's first name.
        /// </summary>
        public string? Firstname { get; set; } = null;

        /// <summary>
        /// (Optional) The user's last name.
        /// </summary>
        public string? Lastname { get; set; } = null;

        /// <summary>
        /// (Optional) The user's email.
        /// </summary>
        public string? Email { get; set; } = null;
    }

    /// <summary>
    /// Information about the succesfull user addition.
    /// </summary>
    public class AddUserSuccessAction
    {
        /// <summary>
        /// The generated user's TechnicalId.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The username to use when login.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// (Optional) The user's first name.
        /// </summary>
        public string? Firstname { get; set; } = null;

        /// <summary>
        /// (Optional) The user's last name.
        /// </summary>
        public string? Lastname { get; set; } = null;

        /// <summary>
        /// (Optional) The user's email.
        /// </summary>
        public string? Email { get; set; } = null;
    }

    /// <summary>
    /// Information about the failed user addition.
    /// </summary>
    public class AddUserFailureAction : FailureAction
    {

    }

    public class RemoveSelectedUsersAction
    {
        public IEnumerable<string> UserIds { get; set; }
    }

    public class RemoveSelectedUsersSuccessAction
    {
        public IEnumerable<string> UserIds { get; set; }
    }

    public class ToggleAllUserCredentialOffersAction
    {
        public bool IsSelected { get; set; }
    }

    public class ToggleUserCredentialOfferAction
    {
        public bool IsSelected { get; set; }
        public string CredentialOfferId { get; set; }
        public string UserId { get; set; }
    }

    public class RemoveSelectedUserCredentialOffersAction
    {
        public ICollection<string> CredentialOffersId { get; set; }
        public string UserId { get; set; }
    }

    public class RemoveSelectedUserCredentialOffersSuccessAction
    {
        public ICollection<string> CredentialOffersId { get; set; }
    }

    public class ShareCredentialOfferAction
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string CredentialTemplateId { get; set; }
        public string ClientId { get; set; }
    }

    public class ShareCredentialOfferSuccessAction
    {
        public string Picture { get; set; }
        public string CredentialOffer { get; set; }
    }

    public class ShareCredentialOfferFailureAction
    {
        public string ErrorMessage { get; set; }
    }

    public class AddCredentialOfferSuccessAction
    {
        public UserCredentialOffer CredentialOffer { get; set; }
    }

    public class GenerateDIDEthrAction
    {
        public string UserId { get; set; }
        public string PublicKey { get; set; }
        public string NetworkName { get; set; }
    }

    public class GenerateDIDEthrSuccessAction
    {
        public string UserId { get; set; }
        public string Did { get; set; }
        public string DidPrivateHex { get; set; }
    }

    public class GenerateDIDEthrFailureAction
    {
        public string ErrorMessage { get; set; }
    }

    public class GenerateDIDKeyAction
    {
        public string UserId { get; set; }
    }

    public class GenerateDIDKeySuccessAction
    {
        public string UserId { get; set; }
        public string Did { get; set; }
        public string DidPrivateHex { get; set; }
    }

    public class GenerateDIDKeyFailureAction
    {
        public string ErrorMessage { get; set; }
    }
}
