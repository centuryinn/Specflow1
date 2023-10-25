using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlow1.Drivers
{
    public class CustomControl : DriverHelper
    {

        public static void EnterText(IWebElement webElement, string value) => webElement.SendKeys(value);

        public static void Click(IWebElement webElement) => webElement.Click();

        public static void SelectByValue(IWebElement webElement, string value)
        {
            SelectElement selectElement = new SelectElement(webElement);
            selectElement.SelectByValue(value);
        }

        public static void SelectByText(IWebElement webElement, string text)
        {
            SelectElement selectElement = new SelectElement(webElement);
            selectElement.SelectByText(text);
        }
    }
}
