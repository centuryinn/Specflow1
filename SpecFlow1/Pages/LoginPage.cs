using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecFlow1.Helper;

namespace SpecFlow1.Pages
{
    public class LoginPage
    {
        private IWebDriver _driver;
        private static readonly Log logger = new Log(typeof(LoginPage));

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        IWebElement txtName => _driver.FindElement(By.CssSelector("input[data-aid=CONTACT_FORM_NAME]"));
        IWebElement txtEmail => _driver.FindElement(By.CssSelector("input[data-aid=CONTACT_FORM_EMAIL]"));
        IWebElement lnkContactUs => _driver.FindElement(By.LinkText("CONTACT US"));
        IWebElement btnContact => _driver.FindElement(By.XPath("//*[@id=\"bs-4\"]/span/div/div[2]/div/div[2]/button"));
        

        public void EnterNameAndEmail(string name, string email)
        {
            Thread.Sleep(2000);
            txtName.SendKeys(name);
            Thread.Sleep(2000);
            txtEmail.SendKeys(email);
            Thread.Sleep(2000);
        }

        public bool IsContactUsExist() => lnkContactUs.Displayed;

        public void ClickContact()
        {
            Thread.Sleep(5000);
            btnContact.Click();
            logger.Debug("Click Contact button");
        }
    }
}
