using NUnit.Framework;
using SpecFlow1.Drivers;
using SpecFlow1.Pages;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlow1.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {

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
            _driverHelper.Driver.Navigate().GoToUrl("https://centuryinnovations.uk/");
        }

        [When(@"I click on CONTACT US link")]
        public void WhenIClickOnCONTACTUSLink()
        {
            homePage.ClickContactUs();
        }

        [Then(@"I should see Contact Us page")]
        public void ThenIShouldSeeContactUsPage()
        {
            Assert.That(loginPage.IsContactUsExist(), Is.True, "Contact Us Page is displayed");
        }

        [Then(@"I click on CONTACT link")]
        public void ThenIClickOnCONTACTLink()
        {
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
