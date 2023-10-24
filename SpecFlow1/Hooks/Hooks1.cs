using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using TechTalk.SpecFlow;

namespace SpecFlow1.Hooks
{
    [Binding]
    public sealed class Hooks1
    {
        private DriverHelper _driverHelper;
        //Global Variable for Extent report
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;
        public Hooks1(DriverHelper driverHelper) => _driverHelper = driverHelper;

        [BeforeTestRun]
        public static void InitializeReport()
        {
            //Initialize Extent report before test starts
            var htmlReporter = new ExtentJsonFormatter(@"C:\yug\ExtentReport.html");
            extent = new ExtentReports();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            //Create dynamic feature name
            featureName = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void InitializeBrowser()
        {
            OpenQA.Selenium.Chrome.ChromeOptions options = new OpenQA.Selenium.Chrome.ChromeOptions();
            //options.AddArgument("--headless");
            new DriverManager().SetUpDriver(new ChromeConfig());
            Console.WriteLine("Setup");
            _driverHelper.Driver = new ChromeDriver(options);
            //Using TestProject OpenSDK replacing the existing WebDriverManager
            //Note: Here the Token is taken from the .runsettings file
            //_driverHelper.Driver = new FirefoxDriver();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driverHelper.Driver.Quit();
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            //Flush report once test completes
            extent.Flush();
        }

        /*      [AfterStep]
              public void InsertReportingSteps()
              {

                  var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

                  PropertyInfo pInfo = typeof(ScenarioContext).GetProperty("TestStatus", BindingFlags.Instance | BindingFlags.NonPublic);
                  MethodInfo getter = pInfo.GetGetMethod(nonPublic: true);
                  object TestResult = getter.Invoke(ScenarioContext.Current, null);

                  if (ScenarioContext.Current.TestError == null)
                  {
                      if (stepType == "Given")
                          scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                      else if (stepType == "When")
                          scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                      else if (stepType == "Then")
                          scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                      else if (stepType == "And")
                          scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
                  }
                  else if (ScenarioContext.Current.TestError != null)
                  {
                      if (stepType == "Given")
                          scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                      else if (stepType == "When")
                          scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                      else if (stepType == "Then")
                          scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                  }

                  //Pending Status
                  if (TestResult.ToString() == "StepDefinitionPending")
                  {
                      if (stepType == "Given")
                          scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                      else if (stepType == "When")
                          scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                      else if (stepType == "Then")
                          scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");

                  }
        */

    }
    }

