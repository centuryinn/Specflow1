using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlow1.Pages
{
    public class ConsultingPage
    {
        private IWebDriver _driver;
        public ConsultingPage(IWebDriver driver)
        {
            _driver = driver;
        }

        IWebElement txtName => _driver.FindElement(By.CssSelector("input[data-aid=CONTACT_FORM_NAME]"));
        IWebElement txtEmail => _driver.FindElement(By.CssSelector("input[data-aid=CONTACT_FORM_EMAIL]"));
        IWebElement lnkConsulting => _driver.FindElement(By.LinkText("CONSULTING"));

        public bool IsConsultingExist() => lnkConsulting.Displayed;

        public void ClickConsulting()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            lnkConsulting.Click();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }
    }
}