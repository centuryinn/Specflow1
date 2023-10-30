using NUnit.Framework;
using SpecFlow1.Drivers;
using SpecFlow1.Pages;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.IO;
using SpecFlow1.Helper;

namespace SpecFlow1.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private static readonly Log logger = new Log(typeof(LoginSteps));
        private DriverHelper _driverHelper;
        HomePage homePage;
        LoginPage loginPage;

        public LoginSteps(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            homePage = new HomePage(_driverHelper.Driver);
            loginPage = new LoginPage(_driverHelper.Driver);
        }
        [Given(@"I navigate to application")]
        public void GivenINavigateToApplication()
        {
            logger.Debug("Navigate to the website.");
            _driverHelper.Driver.Navigate().GoToUrl("https://centuryinnovations.uk/");
        }

        [When(@"I click on CONTACT US link")]
        public void WhenIClickOnCONTACTUSLink()
        {
            logger.Info("Clicking the ContactUs link");
            homePage.ClickContactUs();
        }

        [Then(@"I should see Contact Us page")]
        public void ThenIShouldSeeContactUsPage()
        {
            logger.Debug("Clicking the ContactUs link");
            Assert.That(loginPage.IsContactUsExist(), Is.True, "Contact Us Page is displayed");
        }

        [Then(@"I click on CONTACT link")]
        public void ThenIClickOnCONTACTLink()
        {
            logger.Info("Clicking the Contact link");
            loginPage.ClickContact();
        }

        //[Then(@"I enter Name and Email")]
        //public void ThenIEnterNameAndEmail(Table table)
        //{
        //    var details = table.CreateSet<EmployeeDetails>();
        //    foreach (EmployeeDetails emp in details)
        //    {
        //        loginPage.EnterNameAndEmail(emp.Name, emp.Email);
        //    }

        //}

        [Then(@"I enter details (.*) and (.*)")]
        public void ThenIEnterDetailsNameAndEmail(String name, String email)
        {
            logger.Info("Enter the name and email");
            loginPage.EnterNameAndEmail(name, email);
           

            //List<EmployeeDetails> empDetails = new List<EmployeeDetails>();
            //{
            //    new EmployeeDetails()
            //    {
            //        Name = name,
            //        Email = email
            //    };
            //    ScenarioContext.Current.Add("EmpDetails", empDetails);
            //    var emplist = ScenarioContext.Current.Get<IEnumerable<EmployeeDetails>>("EmpDetails");
                
            //    foreach (EmployeeDetails emp in emplist) 
            //    {
            //        loginPage.EnterNameAndEmail(emp.Name, emp.Email);
            //    }
            //}

        }
    }
}
