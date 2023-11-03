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
        IWebElement btnContact => _driver.FindElement(By.XPath("//*[@id=\"bs-4\"]/span/div/div[2]/div/div[2]/button"));


        public void EnterNameAndEmail(string name, string email)
        {
            Thread.Sleep(2000);
            txtName.SendKeys(name);
            Thread.Sleep(2000);
            txtEmail.SendKeys(email);
            Thread.Sleep(2000);
        }

        public bool IsConsultingExist() => lnkConsulting.Displayed;

        public void ClickConsulting()
        {
            Thread.Sleep(5000);
            lnkConsulting.Click();
            Thread.Sleep(5000);

        }
    }
}