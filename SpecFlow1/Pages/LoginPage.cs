﻿using OpenQA.Selenium;
using SpecFlow1.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlow1.Pages
{
    public class LoginPage
    {
        private IWebDriver _driver;

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
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            txtName.SendKeys(name);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            txtEmail.SendKeys(email);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        public bool IsContactUsExist() => lnkContactUs.Displayed;

        public void ClickContact()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            btnContact.Click();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);           
        }
    }
}
