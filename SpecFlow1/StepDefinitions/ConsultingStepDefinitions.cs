using NUnit.Framework;
using SpecFlow1.Drivers;
using SpecFlow1.Pages;
using System;
using TechTalk.SpecFlow;

namespace SpecFlow1.StepDefinitions
{
    [Binding]
    public class ConsultingStepDefinitions
    {
        private DriverHelper _driverHelper;
        HomePage homePage;
        LoginPage loginPage;
        ConsultingPage consultingPage;
        WaitHelper waitHelper;

        public ConsultingStepDefinitions(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            homePage = new HomePage(_driverHelper.Driver);
            loginPage = new LoginPage(_driverHelper.Driver);
            consultingPage = new ConsultingPage(_driverHelper.Driver);
            waitHelper = new WaitHelper(_driverHelper.Driver);
        }

        [When(@"I click on Consulting link")]
        public void WhenIClickOnConsultingLink()
        {
            consultingPage.ClickConsulting();
            waitHelper.WaitUntil(_driverHelper, 500, x => _driverHelper.Driver.Url.Contains("centuryinnovations.uk"));
        }

        [Then(@"I should see Consulting page")]
        public void ThenIShouldSeeConsultingPage()
        {
            Assert.That(consultingPage.IsConsultingExist(), Is.True, "Consulting Page is displayed");
            waitHelper.WaitUntil(_driverHelper, 500, x => _driverHelper.Driver.Url.Contains("centuryinnovations.uk"));
        }
    }
}
