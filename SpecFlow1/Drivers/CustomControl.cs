using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SpecFlow1.Configuration;

namespace SpecFlow1.Drivers
{
    public class CustomControl
    {

        private IWebDriver _driver;
        public CustomControl(IWebDriver driver)
        {
            _driver = driver;
        }

        ConfigurationBuilder builder;
        ConfigSetting config;
        static string configsettingpath = System.IO.Directory.GetParent(@"../../../").FullName + Path.DirectorySeparatorChar + "Configuration/configsetting.json";

        public void EnterText(IWebElement webElement, string value) => webElement.SendKeys(value);

        public void Click(IWebElement webElement) => webElement.Click();

        public void SelectByValue(IWebElement webElement, string value)
        {
            SelectElement selectElement = new SelectElement(webElement);
            selectElement.SelectByValue(value);
        }

        public void SelectByText(IWebElement webElement, string text)
        {
            SelectElement selectElement = new SelectElement(webElement);
            selectElement.SelectByText(text);
        }

        public void FileUpload(IWebElement webElement, string fileUploadPath)
        {
            config = new ConfigSetting();
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(configsettingpath);
            IConfigurationRoot configuration = builder.Build();
            configuration.Bind(config);
            webElement.SendKeys(config.FileUploadPath);
        }
    }
}
