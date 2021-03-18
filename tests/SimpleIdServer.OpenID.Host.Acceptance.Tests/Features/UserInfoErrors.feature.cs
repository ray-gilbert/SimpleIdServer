﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.7.0.0
//      SpecFlow Generator Version:3.7.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SimpleIdServer.OpenID.Host.Acceptance.Tests.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.7.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class UserInfoErrorsFeature : object, Xunit.IClassFixture<UserInfoErrorsFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "UserInfoErrors.feature"
#line hidden
        
        public UserInfoErrorsFeature(UserInfoErrorsFeature.FixtureData fixtureData, SimpleIdServer_OpenID_Host_Acceptance_Tests_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "UserInfoErrors", "\tCheck the errors returned by the UserInfo endpoint", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Error is returned when the token is missing (HTTP GET)")]
        [Xunit.TraitAttribute("FeatureTitle", "UserInfoErrors")]
        [Xunit.TraitAttribute("Description", "Error is returned when the token is missing (HTTP GET)")]
        public virtual void ErrorIsReturnedWhenTheTokenIsMissingHTTPGET()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Error is returned when the token is missing (HTTP GET)", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 4
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table262 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
#line 5
 testRunner.When("execute HTTP GET request \'http://localhost/userinfo\'", ((string)(null)), table262, "When ");
#line hidden
#line 8
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 10
 testRunner.Then("JSON \'error\'=\'invalid_request\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 11
 testRunner.Then("JSON \'error_description\'=\'missing token\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Error is returned when the token is missing (HTTP POST + FORMURLENCODED)")]
        [Xunit.TraitAttribute("FeatureTitle", "UserInfoErrors")]
        [Xunit.TraitAttribute("Description", "Error is returned when the token is missing (HTTP POST + FORMURLENCODED)")]
        public virtual void ErrorIsReturnedWhenTheTokenIsMissingHTTPPOSTFORMURLENCODED()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Error is returned when the token is missing (HTTP POST + FORMURLENCODED)", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 13
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table263 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
#line 14
 testRunner.When("execute HTTP POST request \'http://localhost/userinfo\'", ((string)(null)), table263, "When ");
#line hidden
#line 17
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 19
 testRunner.Then("JSON \'error\'=\'invalid_request\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 20
 testRunner.Then("JSON \'error_description\'=\'missing token\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Error is returned when the token is missing (HTTP POST + JSON)")]
        [Xunit.TraitAttribute("FeatureTitle", "UserInfoErrors")]
        [Xunit.TraitAttribute("Description", "Error is returned when the token is missing (HTTP POST + JSON)")]
        public virtual void ErrorIsReturnedWhenTheTokenIsMissingHTTPPOSTJSON()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Error is returned when the token is missing (HTTP POST + JSON)", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 22
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table264 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
#line 23
 testRunner.When("execute HTTP POST JSON request \'http://localhost/userinfo\'", ((string)(null)), table264, "When ");
#line hidden
#line 26
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 28
 testRunner.Then("JSON \'error\'=\'invalid_request\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 29
 testRunner.Then("JSON \'error_description\'=\'the content-type is not correct\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Error is returned when token is incorrect")]
        [Xunit.TraitAttribute("FeatureTitle", "UserInfoErrors")]
        [Xunit.TraitAttribute("Description", "Error is returned when token is incorrect")]
        public virtual void ErrorIsReturnedWhenTokenIsIncorrect()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Error is returned when token is incorrect", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 31
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table265 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table265.AddRow(new string[] {
                            "Authorization",
                            "Bearer tst tst"});
#line 32
 testRunner.When("execute HTTP GET request \'http://localhost/userinfo\'", ((string)(null)), table265, "When ");
#line hidden
#line 36
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 38
 testRunner.Then("JSON \'error\'=\'invalid_request\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 39
 testRunner.Then("JSON \'error_description\'=\'missing token\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Error is returned when token is not well formatted")]
        [Xunit.TraitAttribute("FeatureTitle", "UserInfoErrors")]
        [Xunit.TraitAttribute("Description", "Error is returned when token is not well formatted")]
        public virtual void ErrorIsReturnedWhenTokenIsNotWellFormatted()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Error is returned when token is not well formatted", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 41
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table266 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table266.AddRow(new string[] {
                            "Authorization",
                            "Bearer tst"});
#line 42
 testRunner.When("execute HTTP GET request \'http://localhost/userinfo\'", ((string)(null)), table266, "When ");
#line hidden
#line 46
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 48
 testRunner.Then("JSON \'error\'=\'invalid_token\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 49
 testRunner.Then("JSON \'error_description\'=\'bad token\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Error is returned when the user is unknown")]
        [Xunit.TraitAttribute("FeatureTitle", "UserInfoErrors")]
        [Xunit.TraitAttribute("Description", "Error is returned when the user is unknown")]
        public virtual void ErrorIsReturnedWhenTheUserIsUnknown()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Error is returned when the user is unknown", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 51
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table267 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table267.AddRow(new string[] {
                            "redirect_uris",
                            "[https://web.com]"});
                table267.AddRow(new string[] {
                            "scope",
                            "email"});
#line 52
 testRunner.When("execute HTTP POST JSON request \'http://localhost/register\'", ((string)(null)), table267, "When ");
#line hidden
#line 57
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 58
 testRunner.And("extract parameter \'client_id\' from JSON body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table268 = new TechTalk.SpecFlow.Table(new string[] {
                            "Type",
                            "Kid",
                            "AlgName"});
                table268.AddRow(new string[] {
                            "SIG",
                            "1",
                            "ES256"});
#line 60
 testRunner.And("add JSON web key to Authorization Server and store into \'jwks\'", ((string)(null)), table268, "And ");
#line hidden
                TechTalk.SpecFlow.Table table269 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table269.AddRow(new string[] {
                            "sub",
                            "unknown"});
                table269.AddRow(new string[] {
                            "aud",
                            "aud"});
#line 64
 testRunner.And("use \'1\' JWK from \'jwks\' to build JWS and store into \'accesstoken\'", ((string)(null)), table269, "And ");
#line hidden
                TechTalk.SpecFlow.Table table270 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table270.AddRow(new string[] {
                            "Authorization",
                            "Bearer $accesstoken$"});
#line 69
 testRunner.And("execute HTTP GET request \'http://localhost/userinfo\'", ((string)(null)), table270, "And ");
#line hidden
#line 73
 testRunner.Then("HTTP status code equals to \'401\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Error is returned when there is not valid audience in the token")]
        [Xunit.TraitAttribute("FeatureTitle", "UserInfoErrors")]
        [Xunit.TraitAttribute("Description", "Error is returned when there is not valid audience in the token")]
        public virtual void ErrorIsReturnedWhenThereIsNotValidAudienceInTheToken()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Error is returned when there is not valid audience in the token", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 75
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table271 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table271.AddRow(new string[] {
                            "redirect_uris",
                            "[https://web.com]"});
                table271.AddRow(new string[] {
                            "scope",
                            "email"});
#line 76
 testRunner.When("execute HTTP POST JSON request \'http://localhost/register\'", ((string)(null)), table271, "When ");
#line hidden
#line 81
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 82
 testRunner.And("extract parameter \'client_id\' from JSON body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table272 = new TechTalk.SpecFlow.Table(new string[] {
                            "Type",
                            "Kid",
                            "AlgName"});
                table272.AddRow(new string[] {
                            "SIG",
                            "1",
                            "ES256"});
#line 84
 testRunner.And("add JSON web key to Authorization Server and store into \'jwks\'", ((string)(null)), table272, "And ");
#line hidden
                TechTalk.SpecFlow.Table table273 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table273.AddRow(new string[] {
                            "sub",
                            "administrator"});
                table273.AddRow(new string[] {
                            "aud",
                            "aud"});
#line 88
 testRunner.And("use \'1\' JWK from \'jwks\' to build JWS and store into \'accesstoken\'", ((string)(null)), table273, "And ");
#line hidden
                TechTalk.SpecFlow.Table table274 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table274.AddRow(new string[] {
                            "Authorization",
                            "Bearer $accesstoken$"});
#line 93
 testRunner.And("execute HTTP GET request \'http://localhost/userinfo\'", ((string)(null)), table274, "And ");
#line hidden
#line 97
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 99
 testRunner.Then("HTTP status code equals to \'400\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 100
 testRunner.Then("JSON \'error\'=\'invalid_client\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 101
 testRunner.Then("JSON \'error_description\'=\'invalid audiences\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Error is returned when no consent has been accepted")]
        [Xunit.TraitAttribute("FeatureTitle", "UserInfoErrors")]
        [Xunit.TraitAttribute("Description", "Error is returned when no consent has been accepted")]
        public virtual void ErrorIsReturnedWhenNoConsentHasBeenAccepted()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Error is returned when no consent has been accepted", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 103
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table275 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table275.AddRow(new string[] {
                            "redirect_uris",
                            "[https://web.com]"});
                table275.AddRow(new string[] {
                            "scope",
                            "email"});
#line 104
 testRunner.When("execute HTTP POST JSON request \'http://localhost/register\'", ((string)(null)), table275, "When ");
#line hidden
#line 109
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 110
 testRunner.And("extract parameter \'client_id\' from JSON body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table276 = new TechTalk.SpecFlow.Table(new string[] {
                            "Type",
                            "Kid",
                            "AlgName"});
                table276.AddRow(new string[] {
                            "SIG",
                            "1",
                            "ES256"});
#line 112
 testRunner.And("add JSON web key to Authorization Server and store into \'jwks\'", ((string)(null)), table276, "And ");
#line hidden
                TechTalk.SpecFlow.Table table277 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table277.AddRow(new string[] {
                            "sub",
                            "administrator"});
                table277.AddRow(new string[] {
                            "aud",
                            "$client_id$"});
                table277.AddRow(new string[] {
                            "scope",
                            "[openid,profile]"});
#line 116
 testRunner.And("use \'1\' JWK from \'jwks\' to build JWS and store into \'accesstoken\'", ((string)(null)), table277, "And ");
#line hidden
                TechTalk.SpecFlow.Table table278 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table278.AddRow(new string[] {
                            "Authorization",
                            "Bearer $accesstoken$"});
#line 122
 testRunner.And("execute HTTP GET request \'http://localhost/userinfo\'", ((string)(null)), table278, "And ");
#line hidden
#line 126
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 128
 testRunner.Then("HTTP status code equals to \'400\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 129
 testRunner.Then("JSON \'error\'=\'invalid_request\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 130
 testRunner.Then("JSON \'error_description\'=\'no consent has been accepted\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="If access token is rejected then userinfo endpoint cannot be accessed")]
        [Xunit.TraitAttribute("FeatureTitle", "UserInfoErrors")]
        [Xunit.TraitAttribute("Description", "If access token is rejected then userinfo endpoint cannot be accessed")]
        public virtual void IfAccessTokenIsRejectedThenUserinfoEndpointCannotBeAccessed()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("If access token is rejected then userinfo endpoint cannot be accessed", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 132
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                TechTalk.SpecFlow.Table table279 = new TechTalk.SpecFlow.Table(new string[] {
                            "Type",
                            "Kid",
                            "AlgName"});
                table279.AddRow(new string[] {
                            "SIG",
                            "1",
                            "RS256"});
#line 133
 testRunner.When("add JSON web key to Authorization Server and store into \'jwks\'", ((string)(null)), table279, "When ");
#line hidden
                TechTalk.SpecFlow.Table table280 = new TechTalk.SpecFlow.Table(new string[] {
                            "Type",
                            "Kid",
                            "AlgName"});
                table280.AddRow(new string[] {
                            "ENC",
                            "2",
                            "RSA1_5"});
#line 137
 testRunner.And("build JSON Web Keys, store JWKS into \'jwks\' and store the public keys into \'jwks_" +
                        "json\'", ((string)(null)), table280, "And ");
#line hidden
                TechTalk.SpecFlow.Table table281 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table281.AddRow(new string[] {
                            "redirect_uris",
                            "[https://web.com]"});
                table281.AddRow(new string[] {
                            "grant_types",
                            "[implicit,authorization_code]"});
                table281.AddRow(new string[] {
                            "response_types",
                            "[token,id_token,code]"});
                table281.AddRow(new string[] {
                            "scope",
                            "email role"});
                table281.AddRow(new string[] {
                            "subject_type",
                            "public"});
                table281.AddRow(new string[] {
                            "id_token_signed_response_alg",
                            "RS256"});
                table281.AddRow(new string[] {
                            "id_token_encrypted_response_alg",
                            "RSA1_5"});
                table281.AddRow(new string[] {
                            "id_token_encrypted_response_enc",
                            "A256CBC-HS512"});
                table281.AddRow(new string[] {
                            "jwks",
                            "$jwks_json$"});
                table281.AddRow(new string[] {
                            "token_endpoint_auth_method",
                            "client_secret_post"});
#line 141
 testRunner.When("execute HTTP POST JSON request \'http://localhost/register\'", ((string)(null)), table281, "When ");
#line hidden
#line 154
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 155
 testRunner.And("extract parameter \'client_id\' from JSON body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 156
 testRunner.And("extract parameter \'client_secret\' from JSON body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 157
 testRunner.And("add user consent : user=\'administrator\', scope=\'email role\', clientId=\'$client_id" +
                        "$\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table282 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table282.AddRow(new string[] {
                            "response_type",
                            "id_token token code"});
                table282.AddRow(new string[] {
                            "client_id",
                            "$client_id$"});
                table282.AddRow(new string[] {
                            "state",
                            "state"});
                table282.AddRow(new string[] {
                            "response_mode",
                            "query"});
                table282.AddRow(new string[] {
                            "scope",
                            "openid email role"});
                table282.AddRow(new string[] {
                            "redirect_uri",
                            "https://web.com"});
                table282.AddRow(new string[] {
                            "ui_locales",
                            "en fr"});
                table282.AddRow(new string[] {
                            "nonce",
                            "nonce"});
#line 159
 testRunner.And("execute HTTP GET request \'http://localhost/authorization\'", ((string)(null)), table282, "And ");
#line hidden
#line 170
 testRunner.And("extract \'id_token\' from callback", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 171
 testRunner.And("extract \'code\' from callback", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table283 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table283.AddRow(new string[] {
                            "client_id",
                            "$client_id$"});
                table283.AddRow(new string[] {
                            "client_secret",
                            "$client_secret$"});
                table283.AddRow(new string[] {
                            "grant_type",
                            "authorization_code"});
                table283.AddRow(new string[] {
                            "code",
                            "$code$"});
                table283.AddRow(new string[] {
                            "redirect_uri",
                            "https://web.com"});
#line 173
 testRunner.And("execute HTTP POST request \'http://localhost/token\'", ((string)(null)), table283, "And ");
#line hidden
#line 181
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 182
 testRunner.And("extract parameter \'access_token\' from JSON body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table284 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table284.AddRow(new string[] {
                            "client_id",
                            "$client_id$"});
                table284.AddRow(new string[] {
                            "client_secret",
                            "$client_secret$"});
                table284.AddRow(new string[] {
                            "grant_type",
                            "authorization_code"});
                table284.AddRow(new string[] {
                            "code",
                            "$code$"});
                table284.AddRow(new string[] {
                            "redirect_uri",
                            "https://web.com"});
#line 184
 testRunner.And("execute HTTP POST request \'http://localhost/token\'", ((string)(null)), table284, "And ");
#line hidden
                TechTalk.SpecFlow.Table table285 = new TechTalk.SpecFlow.Table(new string[] {
                            "Key",
                            "Value"});
                table285.AddRow(new string[] {
                            "Authorization",
                            "Bearer $access_token$"});
#line 192
 testRunner.And("execute HTTP GET request \'http://localhost/userinfo\'", ((string)(null)), table285, "And ");
#line hidden
#line 196
 testRunner.And("extract JSON from body", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 198
 testRunner.Then("HTTP status code equals to \'400\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 199
 testRunner.Then("JSON \'error\'=\'invalid_token\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 200
 testRunner.Then("JSON \'error_description\'=\'access token has been rejected\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.7.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                UserInfoErrorsFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                UserInfoErrorsFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
