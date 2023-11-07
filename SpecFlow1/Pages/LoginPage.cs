using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SpecFlow1.Configuration;
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
        CustomControl customControl;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            customControl = new CustomControl(_driver);
        }
        ConfigurationBuilder builder;
        ConfigSetting config;
        static string configsettingpath = System.IO.Directory.GetParent(@"../../../").FullName + Path.DirectorySeparatorChar + "Configuration/configsetting.json";


        IWebElement txtName => _driver.FindElement(By.CssSelector("input[data-aid=CONTACT_FORM_NAME]"));
        IWebElement txtEmail => _driver.FindElement(By.CssSelector("input[data-aid=CONTACT_FORM_EMAIL]"));
        IWebElement txtMsg => _driver.FindElement(By.CssSelector("textarea[data-aid=CONTACT_FORM_MESSAGE]"));
        IWebElement lnkContactUs => _driver.FindElement(By.LinkText("CONTACT US"));
        IWebElement btnContact => _driver.FindElement(By.XPath("//*[@id=\"bs-4\"]/span/div/div[2]/div/div[2]/button"));


        public void EnterNameAndEmail(string name, string email)
        {
            config = new ConfigSetting();
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(configsettingpath);
            IConfigurationRoot configuration = builder.Build();
            configuration.Bind(config);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            customControl.EnterText(txtName, name);
            //txtName.SendKeys(config.UserName);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            customControl.EnterText(txtEmail, email);
            //txtEmail.SendKeys(config.Email);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            Thread.Sleep(1000);
        }

        public bool IsContactUsExist() => lnkContactUs.Displayed;

        public void ClickContact()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            btnContact.Click();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        public void UploadPolicyFile(string filePath)
        {
            txtMsg.Click();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            customControl.FileUpload(txtMsg, filePath);           
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            Thread.Sleep(1000);
        }
    }
}