using Microsoft.Extensions.Configuration;
using NuGet.Frameworks;
using NUnit.Framework;
using SpecFlow1.Configuration;
using SpecFlow1.Drivers;
using SpecFlow1.Pages;
using System;
using System.Net;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using RestSharp;
using AventStack.ExtentReports.Model;
using RestSharp.Serializers;
using System.Collections.Generic;
using SpecFlow.Internal.Json;
using Newtonsoft.Json.Linq;

namespace SpecFlow1.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {

        private DriverHelper _driverHelper;
        HomePage homePage;
        LoginPage loginPage;
        WaitHelper waitHelper;

        ConfigurationBuilder builder;
        ConfigSetting config;
        static string configsettingpath = System.IO.Directory.GetParent(@"../../../").FullName + Path.DirectorySeparatorChar + "Configuration/configsetting.json";

        public LoginStepDefinitions(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            homePage = new HomePage(_driverHelper.Driver);
            loginPage = new LoginPage(_driverHelper.Driver);
            waitHelper = new WaitHelper(_driverHelper.Driver);            
        }
        [Given(@"I navigate to application")]
        public void GivenINavigateToApplication()
        {
            config = new ConfigSetting();
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(configsettingpath);
            IConfigurationRoot configuration = builder.Build();
            configuration.Bind(config);

            _driverHelper.Driver.Manage().Cookies.DeleteAllCookies();
            _driverHelper.Driver.Navigate().GoToUrl(config.ApplicationUrl);
            _driverHelper.Driver.Manage().Window.Maximize();
        }

        [When(@"I click on CONTACT US link")]
        public void WhenIClickOnCONTACTUSLink()
        {
            homePage.ClickContactUs();
            waitHelper.WaitUntil(_driverHelper, 1000, x => _driverHelper.Driver.Url.Contains("contact-us"));
        }

        [Then(@"I should see Contact Us page")]
        public void ThenIShouldSeeContactUsPage()
        {
            Assert.That(loginPage.IsContactUsExist(), Is.True, "Contact Us Page is displayed");
            waitHelper.WaitUntil(_driverHelper, 500, x => _driverHelper.Driver.Url.Contains("contact-us"));
        }

        [Then(@"I click on CONTACT link")]
        public void ThenIClickOnCONTACTLink()
        {
            waitHelper.ScrollToBottom();
            loginPage.ClickContact();            
        }

        [Then(@"I enter details (.*) and (.*)")]
        public void ThenIEnterDetailsNameAndEmail(String name, String email)
        {
            waitHelper.WaitUntil(_driverHelper, 500, x => _driverHelper.Driver.Url.Contains("centuryinnovations.uk"));
            loginPage.EnterNameAndEmail(name, email);           
        }

        [Then(@"I upload policy file (.*)")]
        public void ThenIUploadPolicyFile(string filePath)
        {
            loginPage.UploadPolicyFile(filePath);
        }
    }
}
