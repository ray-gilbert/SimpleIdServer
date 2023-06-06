﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SimpleIdServer.IdServer.Host.Acceptance.Tests.Features.GrantTypes
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class AlternativeScenariosFeature : object, Xunit.IClassFixture<AlternativeScenariosFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "AlternativeScenarios.feature"
#line hidden
        
        public AlternativeScenariosFeature(AlternativeScenariosFeature.FixtureData fixtureData, SimpleIdServer_IdServer_Host_Acceptance_Tests_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/GrantTypes", "AlternativeScenarios", "\tExecute alternative scenarios", ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public void TestInitialize()
        {
        }
        
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="User-agent is redirected to the login page when elapsed time > authentication tim" +
            "e + default client max age")]
        [Xunit.TraitAttribute("FeatureTitle", "AlternativeScenarios")]
        [Xunit.TraitAttribute("Description", "User-agent is redirected to the login page when elapsed time > authentication tim" +
            "e + default client max age")]
        public void User_AgentIsRedirectedToTheLoginPageWhenElapsedTimeAuthenticationTimeDefaultClientMaxAge()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User-agent is redirected to the login page when elapsed time > authentication tim" +
                    "e + default client max age", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 4
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 5
 testRunner.Given("authenticate a user and add \'-10\' seconds to the authentication time", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table210 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table210.AddRow(new string[] {
                            "response_type",
                            "id_token"});
                table210.AddRow(new string[] {
                            "client_id",
                            "thirtyFourClient"});
                table210.AddRow(new string[] {
                            "state",
                            "state"});
                table210.AddRow(new string[] {
                            "response_mode",
                            "query"});
                table210.AddRow(new string[] {
                            "scope",
                            "openid email role"});
                table210.AddRow(new string[] {
                            "redirect_uri",
                            "http://localhost:8080"});
                table210.AddRow(new string[] {
                            "nonce",
                            "nonce"});
                table210.AddRow(new string[] {
                            "display",
                            "popup"});
#line 6
 testRunner.When("execute HTTP GET request \'http://localhost/authorization\'", ((string)(null)), table210, "When ");
#line hidden
#line 17
 testRunner.Then("redirection url contains \'http://localhost/pwd/Authenticate\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="User-agent is redirected to the login page when elapsed time > authentication tim" +
            "e + max age")]
        [Xunit.TraitAttribute("FeatureTitle", "AlternativeScenarios")]
        [Xunit.TraitAttribute("Description", "User-agent is redirected to the login page when elapsed time > authentication tim" +
            "e + max age")]
        public void User_AgentIsRedirectedToTheLoginPageWhenElapsedTimeAuthenticationTimeMaxAge()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("User-agent is redirected to the login page when elapsed time > authentication tim" +
                    "e + max age", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 19
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 20
 testRunner.Given("authenticate a user and add \'-10\' seconds to the authentication time", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table211 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table211.AddRow(new string[] {
                            "response_type",
                            "id_token"});
                table211.AddRow(new string[] {
                            "client_id",
                            "thirtyFiveClient"});
                table211.AddRow(new string[] {
                            "state",
                            "state"});
                table211.AddRow(new string[] {
                            "response_mode",
                            "query"});
                table211.AddRow(new string[] {
                            "scope",
                            "openid email role"});
                table211.AddRow(new string[] {
                            "redirect_uri",
                            "http://localhost:8080"});
                table211.AddRow(new string[] {
                            "nonce",
                            "nonce"});
                table211.AddRow(new string[] {
                            "display",
                            "popup"});
                table211.AddRow(new string[] {
                            "max_age",
                            "2"});
#line 21
 testRunner.When("execute HTTP GET request \'http://localhost/authorization\'", ((string)(null)), table211, "When ");
#line hidden
#line 33
 testRunner.Then("redirection url contains \'http://localhost/pwd/Authenticate\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="auth_time claim is returned in the identity token when it is marked as essential " +
            "claim")]
        [Xunit.TraitAttribute("FeatureTitle", "AlternativeScenarios")]
        [Xunit.TraitAttribute("Description", "auth_time claim is returned in the identity token when it is marked as essential " +
            "claim")]
        public void Auth_TimeClaimIsReturnedInTheIdentityTokenWhenItIsMarkedAsEssentialClaim()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("auth_time claim is returned in the identity token when it is marked as essential " +
                    "claim", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 35
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 36
 testRunner.Given("authenticate a user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table212 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table212.AddRow(new string[] {
                            "response_type",
                            "id_token"});
                table212.AddRow(new string[] {
                            "client_id",
                            "thirtyFiveClient"});
                table212.AddRow(new string[] {
                            "state",
                            "state"});
                table212.AddRow(new string[] {
                            "response_mode",
                            "query"});
                table212.AddRow(new string[] {
                            "scope",
                            "openid email role"});
                table212.AddRow(new string[] {
                            "redirect_uri",
                            "http://localhost:8080"});
                table212.AddRow(new string[] {
                            "nonce",
                            "nonce"});
                table212.AddRow(new string[] {
                            "display",
                            "popup"});
                table212.AddRow(new string[] {
                            "claims",
                            "{ \"id_token\": { \"auth_time\": { \"essential\" : true } } }"});
#line 37
 testRunner.When("execute HTTP GET request \'http://localhost/authorization\'", ((string)(null)), table212, "When ");
#line hidden
#line 49
 testRunner.And("extract parameter \'id_token\' from redirect url", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 50
 testRunner.And("extract payload from JWT \'$id_token$\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 52
 testRunner.Then("JWT contains \'auth_time\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="amr and acr are returned in the identity token when acr_values is passed")]
        [Xunit.TraitAttribute("FeatureTitle", "AlternativeScenarios")]
        [Xunit.TraitAttribute("Description", "amr and acr are returned in the identity token when acr_values is passed")]
        public void AmrAndAcrAreReturnedInTheIdentityTokenWhenAcr_ValuesIsPassed()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("amr and acr are returned in the identity token when acr_values is passed", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 54
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 55
 testRunner.Given("authenticate a user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table213 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table213.AddRow(new string[] {
                            "response_type",
                            "id_token"});
                table213.AddRow(new string[] {
                            "client_id",
                            "thirtyFiveClient"});
                table213.AddRow(new string[] {
                            "state",
                            "state"});
                table213.AddRow(new string[] {
                            "response_mode",
                            "query"});
                table213.AddRow(new string[] {
                            "scope",
                            "openid email role"});
                table213.AddRow(new string[] {
                            "redirect_uri",
                            "http://localhost:8080"});
                table213.AddRow(new string[] {
                            "nonce",
                            "nonce"});
                table213.AddRow(new string[] {
                            "display",
                            "popup"});
                table213.AddRow(new string[] {
                            "acr_values",
                            "sid-load-01"});
#line 56
 testRunner.When("execute HTTP GET request \'http://localhost/authorization\'", ((string)(null)), table213, "When ");
#line hidden
#line 68
 testRunner.And("extract parameter \'id_token\' from redirect url", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 69
 testRunner.And("extract payload from JWT \'$id_token$\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 71
 testRunner.Then("JWT contains \'amr\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 72
 testRunner.Then("JWT contains \'acr\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 73
 testRunner.Then("JWT has \'amr\'=\'pwd\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 74
 testRunner.Then("JWT has \'acr\'=\'sid-load-01\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="when using offline_scope the client can access to the userinfo even if the end-us" +
            "er is not authenticated")]
        [Xunit.TraitAttribute("FeatureTitle", "AlternativeScenarios")]
        [Xunit.TraitAttribute("Description", "when using offline_scope the client can access to the userinfo even if the end-us" +
            "er is not authenticated")]
        public void WhenUsingOffline_ScopeTheClientCanAccessToTheUserinfoEvenIfTheEnd_UserIsNotAuthenticated()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("when using offline_scope the client can access to the userinfo even if the end-us" +
                    "er is not authenticated", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 76
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 77
 testRunner.Given("authenticate a user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table214 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table214.AddRow(new string[] {
                            "response_type",
                            "code"});
                table214.AddRow(new string[] {
                            "client_id",
                            "thirtySixClient"});
                table214.AddRow(new string[] {
                            "state",
                            "state"});
                table214.AddRow(new string[] {
                            "response_mode",
                            "query"});
                table214.AddRow(new string[] {
                            "scope",
                            "openid email role offline_access"});
                table214.AddRow(new string[] {
                            "redirect_uri",
                            "http://localhost:8080"});
                table214.AddRow(new string[] {
                            "nonce",
                            "nonce"});
                table214.AddRow(new string[] {
                            "display",
                            "popup"});
#line 78
 testRunner.When("execute HTTP GET request \'http://localhost/authorization\'", ((string)(null)), table214, "When ");
#line hidden
#line 89
 testRunner.And("extract parameter \'refresh_token\' from redirect url", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 90
 testRunner.And("disconnect the user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table215 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table215.AddRow(new string[] {
                            "grant_type",
                            "refresh_token"});
                table215.AddRow(new string[] {
                            "refresh_token",
                            "$refresh_token$"});
                table215.AddRow(new string[] {
                            "client_id",
                            "thirtySixClient"});
                table215.AddRow(new string[] {
                            "client_secret",
                            "password"});
#line 92
 testRunner.And("execute HTTP POST request \'http://localhost/token\'", ((string)(null)), table215, "And ");
#line hidden
#line 99
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 100
 testRunner.And("extract parameter \'access_token\' from JSON body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table216 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table216.AddRow(new string[] {
                            "Authorization",
                            "Bearer $access_token$"});
#line 102
 testRunner.And("execute HTTP GET request \'http://localhost/userinfo\'", ((string)(null)), table216, "And ");
#line hidden
#line 106
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 108
 testRunner.Then("HTTP status code equals to \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 109
 testRunner.Then("JSON \'sub\'=\'user\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 110
 testRunner.Then("JSON \'$.role[0]\'=\'role1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 111
 testRunner.Then("JSON \'$.role[1]\'=\'role2\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 112
 testRunner.Then("JSON \'email\'=\'email@outlook.fr\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                AlternativeScenariosFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                AlternativeScenariosFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
