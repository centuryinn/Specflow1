using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlow1.Drivers
{
    public class CustomControl
    {

        private IWebDriver _driver;
        public CustomControl(IWebDriver driver)
        {
            _driver = driver;
        }
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
            webElement.SendKeys(fileUploadPath);
        }

    }
}
