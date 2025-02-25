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
    public partial class AuthorizationCodeGrantTypeFeature : object, Xunit.IClassFixture<AuthorizationCodeGrantTypeFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "AuthorizationCodeGrantType.feature"
#line hidden
        
        public AuthorizationCodeGrantTypeFeature(AuthorizationCodeGrantTypeFeature.FixtureData fixtureData, SimpleIdServer_IdServer_Host_Acceptance_Tests_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/GrantTypes", "AuthorizationCodeGrantType", "\tCheck all the alternatives scenarios in code grant-type\t", ProgrammingLanguage.CSharp, featureTags);
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
        
        [Xunit.SkippableFactAttribute(DisplayName="resource parameter can be overridden and scopes \'admin\', \'calendar\' are returned")]
        [Xunit.TraitAttribute("FeatureTitle", "AuthorizationCodeGrantType")]
        [Xunit.TraitAttribute("Description", "resource parameter can be overridden and scopes \'admin\', \'calendar\' are returned")]
        public void ResourceParameterCanBeOverriddenAndScopesAdminCalendarAreReturned()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("resource parameter can be overridden and scopes \'admin\', \'calendar\' are returned", null, tagsOfScenario, argumentsOfScenario, featureTags);
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
 testRunner.Given("authenticate a user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table227 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table227.AddRow(new string[] {
                            "response_type",
                            "code"});
                table227.AddRow(new string[] {
                            "client_id",
                            "fortySixClient"});
                table227.AddRow(new string[] {
                            "state",
                            "state"});
                table227.AddRow(new string[] {
                            "response_mode",
                            "query"});
                table227.AddRow(new string[] {
                            "redirect_uri",
                            "http://localhost:8080"});
                table227.AddRow(new string[] {
                            "nonce",
                            "nonce"});
                table227.AddRow(new string[] {
                            "resource",
                            "https://cal.example.com"});
#line 6
 testRunner.When("execute HTTP GET request \'https://localhost:8080/authorization\'", ((string)(null)), table227, "When ");
#line hidden
#line 16
 testRunner.And("extract parameter \'code\' from redirect url", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table228 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table228.AddRow(new string[] {
                            "client_id",
                            "fortySixClient"});
                table228.AddRow(new string[] {
                            "client_secret",
                            "password"});
                table228.AddRow(new string[] {
                            "grant_type",
                            "authorization_code"});
                table228.AddRow(new string[] {
                            "code",
                            "$code$"});
                table228.AddRow(new string[] {
                            "redirect_uri",
                            "http://localhost:8080"});
                table228.AddRow(new string[] {
                            "resource",
                            "https://cal.example.com"});
                table228.AddRow(new string[] {
                            "resource",
                            "https://contacts.example.com"});
#line 18
 testRunner.And("execute HTTP POST request \'https://localhost:8080/token\'", ((string)(null)), table228, "And ");
#line hidden
#line 28
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 30
 testRunner.Then("HTTP status code equals to \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 32
 testRunner.And("JSON \'scope\'=\'admin calendar\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 33
 testRunner.And("access_token audience contains \'https://cal.example.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 34
 testRunner.And("access_token audience contains \'https://contacts.example.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 35
 testRunner.And("access_token contains the claim \'scope\'=\'admin\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 36
 testRunner.And("access_token contains the claim \'scope\'=\'calendar\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="scope of a resource can be filtered")]
        [Xunit.TraitAttribute("FeatureTitle", "AuthorizationCodeGrantType")]
        [Xunit.TraitAttribute("Description", "scope of a resource can be filtered")]
        public void ScopeOfAResourceCanBeFiltered()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("scope of a resource can be filtered", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 38
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 39
 testRunner.Given("authenticate a user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table229 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table229.AddRow(new string[] {
                            "response_type",
                            "code"});
                table229.AddRow(new string[] {
                            "client_id",
                            "fortySixClient"});
                table229.AddRow(new string[] {
                            "state",
                            "state"});
                table229.AddRow(new string[] {
                            "response_mode",
                            "query"});
                table229.AddRow(new string[] {
                            "redirect_uri",
                            "http://localhost:8080"});
                table229.AddRow(new string[] {
                            "nonce",
                            "nonce"});
                table229.AddRow(new string[] {
                            "resource",
                            "https://cal.example.com"});
#line 40
 testRunner.When("execute HTTP GET request \'https://localhost:8080/authorization\'", ((string)(null)), table229, "When ");
#line hidden
#line 50
 testRunner.And("extract parameter \'code\' from redirect url", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table230 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table230.AddRow(new string[] {
                            "client_id",
                            "fortySixClient"});
                table230.AddRow(new string[] {
                            "client_secret",
                            "password"});
                table230.AddRow(new string[] {
                            "grant_type",
                            "authorization_code"});
                table230.AddRow(new string[] {
                            "code",
                            "$code$"});
                table230.AddRow(new string[] {
                            "redirect_uri",
                            "http://localhost:8080"});
                table230.AddRow(new string[] {
                            "resource",
                            "https://cal.example.com"});
                table230.AddRow(new string[] {
                            "resource",
                            "https://contacts.example.com"});
                table230.AddRow(new string[] {
                            "scope",
                            "admin"});
#line 52
 testRunner.And("execute HTTP POST request \'https://localhost:8080/token\'", ((string)(null)), table230, "And ");
#line hidden
#line 63
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 65
 testRunner.Then("HTTP status code equals to \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 66
 testRunner.And("access_token audience contains \'https://cal.example.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 67
 testRunner.And("access_token audience contains \'https://contacts.example.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 68
 testRunner.And("access_token contains the claim \'scope\'=\'admin\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 69
 testRunner.And("access_token doesn\'t contain the claim \'scope\'=\'calendar\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="scopes \'admin\', \'calendar\' are returned thanks to the original request")]
        [Xunit.TraitAttribute("FeatureTitle", "AuthorizationCodeGrantType")]
        [Xunit.TraitAttribute("Description", "scopes \'admin\', \'calendar\' are returned thanks to the original request")]
        public void ScopesAdminCalendarAreReturnedThanksToTheOriginalRequest()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("scopes \'admin\', \'calendar\' are returned thanks to the original request", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 71
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 72
 testRunner.Given("authenticate a user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table231 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table231.AddRow(new string[] {
                            "response_type",
                            "code"});
                table231.AddRow(new string[] {
                            "client_id",
                            "fortySixClient"});
                table231.AddRow(new string[] {
                            "state",
                            "state"});
                table231.AddRow(new string[] {
                            "response_mode",
                            "query"});
                table231.AddRow(new string[] {
                            "redirect_uri",
                            "http://localhost:8080"});
                table231.AddRow(new string[] {
                            "nonce",
                            "nonce"});
                table231.AddRow(new string[] {
                            "resource",
                            "https://cal.example.com"});
#line 73
 testRunner.When("execute HTTP GET request \'https://localhost:8080/authorization\'", ((string)(null)), table231, "When ");
#line hidden
#line 83
 testRunner.And("extract parameter \'code\' from redirect url", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table232 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table232.AddRow(new string[] {
                            "client_id",
                            "fortySixClient"});
                table232.AddRow(new string[] {
                            "client_secret",
                            "password"});
                table232.AddRow(new string[] {
                            "grant_type",
                            "authorization_code"});
                table232.AddRow(new string[] {
                            "code",
                            "$code$"});
                table232.AddRow(new string[] {
                            "redirect_uri",
                            "http://localhost:8080"});
#line 85
 testRunner.And("execute HTTP POST request \'https://localhost:8080/token\'", ((string)(null)), table232, "And ");
#line hidden
#line 93
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 95
 testRunner.Then("JSON \'scope\'=\'admin calendar\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 96
 testRunner.And("access_token audience contains \'https://cal.example.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 97
 testRunner.And("access_token contains the claim \'scope\'=\'admin\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 98
 testRunner.And("access_token contains the claim \'scope\'=\'calendar\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="authorization_details are returned")]
        [Xunit.TraitAttribute("FeatureTitle", "AuthorizationCodeGrantType")]
        [Xunit.TraitAttribute("Description", "authorization_details are returned")]
        public void Authorization_DetailsAreReturned()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("authorization_details are returned", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 100
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 101
 testRunner.Given("authenticate a user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table233 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table233.AddRow(new string[] {
                            "response_type",
                            "code token"});
                table233.AddRow(new string[] {
                            "client_id",
                            "fiftyFiveClient"});
                table233.AddRow(new string[] {
                            "state",
                            "state"});
                table233.AddRow(new string[] {
                            "response_mode",
                            "query"});
                table233.AddRow(new string[] {
                            "redirect_uri",
                            "http://localhost:8080"});
                table233.AddRow(new string[] {
                            "nonce",
                            "nonce"});
                table233.AddRow(new string[] {
                            "authorization_details",
                            "{ \"type\" : \"firstDetails\", \"actions\": [ \"read\" ] }"});
#line 103
 testRunner.When("execute HTTP GET request \'http://localhost/authorization\'", ((string)(null)), table233, "When ");
#line hidden
#line 113
 testRunner.And("extract parameter \'code\' from redirect url", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table234 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table234.AddRow(new string[] {
                            "client_id",
                            "fiftyFiveClient"});
                table234.AddRow(new string[] {
                            "client_secret",
                            "password"});
                table234.AddRow(new string[] {
                            "grant_type",
                            "authorization_code"});
                table234.AddRow(new string[] {
                            "code",
                            "$code$"});
                table234.AddRow(new string[] {
                            "redirect_uri",
                            "http://localhost:8080"});
#line 115
 testRunner.And("execute HTTP POST request \'https://localhost:8080/token\'", ((string)(null)), table234, "And ");
#line hidden
#line 123
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 124
 testRunner.And("extract parameter \'access_token\' from JSON body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 125
 testRunner.And("extract payload from JWT \'$access_token$\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 127
 testRunner.Then("JWT has authorization_details type \'firstDetails\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 128
 testRunner.And("JWT has authorization_details action \'read\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="only one authorization_details is returned because there is one resource paramete" +
            "r")]
        [Xunit.TraitAttribute("FeatureTitle", "AuthorizationCodeGrantType")]
        [Xunit.TraitAttribute("Description", "only one authorization_details is returned because there is one resource paramete" +
            "r")]
        public void OnlyOneAuthorization_DetailsIsReturnedBecauseThereIsOneResourceParameter()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("only one authorization_details is returned because there is one resource paramete" +
                    "r", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 130
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 131
 testRunner.Given("authenticate a user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table235 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table235.AddRow(new string[] {
                            "response_type",
                            "code token"});
                table235.AddRow(new string[] {
                            "client_id",
                            "fiftyFiveClient"});
                table235.AddRow(new string[] {
                            "state",
                            "state"});
                table235.AddRow(new string[] {
                            "response_mode",
                            "query"});
                table235.AddRow(new string[] {
                            "redirect_uri",
                            "http://localhost:8080"});
                table235.AddRow(new string[] {
                            "nonce",
                            "nonce"});
                table235.AddRow(new string[] {
                            "authorization_details",
                            "{ \"type\" : \"secondDetails\", \"locations\": [ \"https://cal.example.com\" ], \"actions\"" +
                                ": [ \"read\" ] }"});
#line 133
 testRunner.When("execute HTTP GET request \'http://localhost/authorization\'", ((string)(null)), table235, "When ");
#line hidden
#line 143
 testRunner.And("extract parameter \'code\' from redirect url", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table236 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table236.AddRow(new string[] {
                            "client_id",
                            "fiftyFiveClient"});
                table236.AddRow(new string[] {
                            "client_secret",
                            "password"});
                table236.AddRow(new string[] {
                            "grant_type",
                            "authorization_code"});
                table236.AddRow(new string[] {
                            "code",
                            "$code$"});
                table236.AddRow(new string[] {
                            "resource",
                            "https://cal.example.com"});
                table236.AddRow(new string[] {
                            "redirect_uri",
                            "http://localhost:8080"});
#line 145
 testRunner.And("execute HTTP POST request \'https://localhost:8080/token\'", ((string)(null)), table236, "And ");
#line hidden
#line 154
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 155
 testRunner.And("extract parameter \'access_token\' from JSON body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 156
 testRunner.And("extract payload from JWT \'$access_token$\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 158
 testRunner.Then("JWT has authorization_details type \'secondDetails\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 159
 testRunner.And("JWT has authorization_details action \'read\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="access token contains authorization_details with openid_credential")]
        [Xunit.TraitAttribute("FeatureTitle", "AuthorizationCodeGrantType")]
        [Xunit.TraitAttribute("Description", "access token contains authorization_details with openid_credential")]
        public void AccessTokenContainsAuthorization_DetailsWithOpenid_Credential()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("access token contains authorization_details with openid_credential", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 161
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 162
 testRunner.Given("authenticate a user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table237 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table237.AddRow(new string[] {
                            "response_type",
                            "code token"});
                table237.AddRow(new string[] {
                            "client_id",
                            "fiftyEightClient"});
                table237.AddRow(new string[] {
                            "state",
                            "state"});
                table237.AddRow(new string[] {
                            "response_mode",
                            "query"});
                table237.AddRow(new string[] {
                            "redirect_uri",
                            "http://localhost:8080"});
                table237.AddRow(new string[] {
                            "nonce",
                            "nonce"});
                table237.AddRow(new string[] {
                            "authorization_details",
                            "{ \"type\" : \"openid_credential\", \"format\": \"jwt_vc_json\", \"types\": [ \"VerifiableCr" +
                                "edential\", \"UniversityDegreeCredential\" ], \"locations\" : [ \"http://localhost\" ] " +
                                "}"});
#line 164
 testRunner.When("execute HTTP GET request \'http://localhost/authorization\'", ((string)(null)), table237, "When ");
#line hidden
#line 174
 testRunner.And("extract parameter \'code\' from redirect url", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table238 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table238.AddRow(new string[] {
                            "client_id",
                            "fiftyEightClient"});
                table238.AddRow(new string[] {
                            "client_secret",
                            "password"});
                table238.AddRow(new string[] {
                            "grant_type",
                            "authorization_code"});
                table238.AddRow(new string[] {
                            "code",
                            "$code$"});
                table238.AddRow(new string[] {
                            "redirect_uri",
                            "http://localhost:8080"});
#line 176
 testRunner.And("execute HTTP POST request \'https://localhost:8080/token\'", ((string)(null)), table238, "And ");
#line hidden
#line 184
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 185
 testRunner.And("extract parameter \'access_token\' from JSON body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 186
 testRunner.And("extract payload from JWT \'$access_token$\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 188
 testRunner.Then("JWT has authorization_details type \'openid_credential\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
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
                AuthorizationCodeGrantTypeFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                AuthorizationCodeGrantTypeFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
