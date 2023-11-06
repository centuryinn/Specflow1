using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SpecFlow1.Drivers
{
    public class WaitHelper
    {
        private static int defaultTimeoutMillisecs = 10000;
        private IWebDriver _driver;
        public WaitHelper(IWebDriver driver)
        {
            _driver = driver;
        }
        public WebDriverWait Wait(IWebDriver driver, Type[] ignoreExceptions, object timeout = null)
        {
            timeout ??= defaultTimeoutMillisecs;
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromMilliseconds((int)timeout));
            if (ignoreExceptions != null)
                w.IgnoreExceptionTypes(ignoreExceptions);
            return w;
        }

        public void WaitUntil(DriverHelper driver, int timeoutInMilliSecs, Func<IWebDriver, bool> condition)
        {
            Wait(_driver, null, timeoutInMilliSecs).Until(condition);
        }

        public void WaitUntil(IWebDriver driver, int timeoutInMilliSecs, Type[] ignoreExceptions,
            Func<IWebDriver, bool> condition)
        {
            Wait(driver, ignoreExceptions, timeoutInMilliSecs).Until(condition);
        }

        public void ScrollToBottom()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
        }
    }
}
