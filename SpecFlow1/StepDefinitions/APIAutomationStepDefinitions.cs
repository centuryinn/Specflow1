using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using SpecFlow1.Configuration;
using SpecFlow1.Drivers;
using SpecFlow1.Pages;
using System;
using System.Net;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace SpecFlow1.StepDefinitions
{

    [Binding]
    public class APIAutomationStepDefinitions
    {
        private DriverHelper _driverHelper;
        HomePage homePage;
        LoginPage loginPage;
        WaitHelper waitHelper;

        ConfigurationBuilder builder;
        ConfigSetting config;
        static string configsettingpath = System.IO.Directory.GetParent(@"../../../").FullName + Path.DirectorySeparatorChar + "Configuration/configsetting.json";

        public APIAutomationStepDefinitions(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            homePage = new HomePage(_driverHelper.Driver);
            loginPage = new LoginPage(_driverHelper.Driver);
            waitHelper = new WaitHelper(_driverHelper.Driver);
        }

        [Given(@"The test case title is '([^']*)'")]
        public void GivenTheTestCaseTitleIs(string testcase)
        { }

        [When(@"User makes a '([^']*)' call at the '([^']*)'")]
        public void WhenUserMakesACallAtThe(string method, string endpoint)
        {
            APIHelper.endpoint = endpoint;
            APIHelper.method = method;

            RestSharpManager.MakeRequest(method);
        }

        [When(@"User makes a '([^']*)' call at the '([^']*)' for '([^']*)'")]
        public void WhenUserMakesACallAtTheFor(string method, string endpoint, string body)
        {
            APIHelper.endpoint = endpoint;
            APIHelper.body = body;
            APIHelper.method = method;

            RestSharpManager.MakeRequest(method);
        }

        [When(@"User sets '([^']*)' query param value as '([^']*)'")]
        public void WhenUserSetsQueryParamValueAs(string queryParam, string queryParamValue)
        {
            RestSharpManager.SetQueryParam(queryParam, queryParamValue);
        }

        [When(@"User executes the api call")]
        public void WhenUserExecutesTheApiCall()
        {
            RestSharpManager.ExecuteRequest();
        }

        [Then(@"User enters api data userName and email")]
        public void ThenUserEntersApiDataUserNameAndEmail()
        {
            int actualResponseCode = (int)(HttpStatusCode)APIHelper.response.StatusCode;
            Assert.AreEqual(actualResponseCode, 200, "Respose code is 200");
            string content = APIHelper.response.Content;
            dynamic userData = JObject.Parse(content);
            string uName = userData.data.first_name.ToString();
            string uEmail = userData.data.email.ToString();

            loginPage.EnterNameAndEmail(uName, uEmail);
        }

        [Then(@"User should expect '([^']*)' response code")]
        public void ThenUserShouldExpectResponseCode(int responseCode)
        {
            int actualResponseCode = (int)(HttpStatusCode)APIHelper.response.StatusCode;
            if (responseCode != actualResponseCode)
            {
                if (APIHelper.method.Equals("get") || APIHelper.method.Equals("delete"))
                {
                    Assert.Fail("Request Endpoint: {0}{1} \n Request Method: {2} \n Expected Response Code: {3} \n Actual Response Code: {4}", APIHelper.baseURL, APIHelper.endpoint, APIHelper.method.ToUpper(), responseCode, actualResponseCode);
                }
                else
                {
                    Assert.Fail("Request Endpoint: {0}{1} \n Request Method: {2} \n Request body: {3} \n Expected Response Body: {4} \n Actual Response Body: {5} \n Expected Response Code: {6} \n Actual Response Code: {7}", APIHelper.baseURL, APIHelper.endpoint, APIHelper.method.ToUpper(), APIHelper.body, actualResponseCode, APIHelper.response.Content, responseCode, actualResponseCode);
                }
            }
        }
    }
}
