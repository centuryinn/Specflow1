using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlow1.Pages
{
    class HomePage
    {
        private IWebDriver _driver;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        IWebElement lnkContactUs => _driver.FindElement(By.LinkText("CONTACT US"));

        public void ClickContactUs() => lnkContactUs.Click();
    }
}
