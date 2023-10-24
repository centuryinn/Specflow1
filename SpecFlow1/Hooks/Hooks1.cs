using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter.Config;
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
using System.Collections.Concurrent;

namespace SpecFlow1.Hooks
{
    [Binding]
    public sealed class Hooks1
    {
        private DriverHelper _driverHelper;

        private static ExtentReports _extentReports;
        [ThreadStatic]
        private static ExtentTest _feature;
        [ThreadStatic]
        private static ExtentTest _scenario;

        public static String dir = AppDomain.CurrentDomain.BaseDirectory;
        public static String testResultPath = dir.Replace("bin\\Debug\\net6.0", "YugTestResults");
        private static readonly string base64ImageType = "base64";
        static string configReportPath = @$"D:\yug\ExtentReport.html";

        public Hooks1(DriverHelper driverHelper) => _driverHelper = driverHelper;

        public static ConcurrentDictionary<string, ExtentTest> FeatureDictionary = new ConcurrentDictionary<string, ExtentTest>();

        [BeforeTestRun]
        public static void InitializeReport()
        {
            //var htmlReporter = new ExtentSparkReporter(testResultPath);
            var htmlReporter = new ExtentSparkReporter(configReportPath);
            htmlReporter.Config.ReportName = "Automation Test Report";
            htmlReporter.Config.DocumentTitle = "Automation Test Report";
            htmlReporter.Config.Theme = Theme.Dark;

            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(htmlReporter);
                       
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
            FeatureDictionary.TryAdd(featureContext.FeatureInfo.Title, _feature);
        }

        [BeforeScenario]
        public void InitializeBrowser(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            OpenQA.Selenium.Chrome.ChromeOptions options = new OpenQA.Selenium.Chrome.ChromeOptions();
            //options.AddArgument("--headless");
            new DriverManager().SetUpDriver(new ChromeConfig());
            Console.WriteLine("Setup");
            _driverHelper.Driver = new ChromeDriver(options);
            //Using TestProject OpenSDK replacing the existing WebDriverManager
            //Note: Here the Token is taken from the .runsettings file
            //_driverHelper.Driver = new FirefoxDriver();
            string InBSName = featureContext.FeatureInfo.Title;
            if (FeatureDictionary.ContainsKey(InBSName))
            {
                _scenario = FeatureDictionary[InBSName].CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
            }
        }

        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext)
        {
            string resultOfImplementation = scenarioContext.ScenarioExecutionStatus.ToString();

            //Pending Status
            if (resultOfImplementation == "UndefinedStep")
            {
                // Log.StepNotDefined();
            }
            _driverHelper.Driver.Quit();
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            //Flush report once test completes
            _extentReports.Flush();
        }

        [AfterStep]
        public void InsertReportingSteps(ScenarioContext scenarioContext)
        {
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepInfo = scenarioContext.StepContext.StepInfo.Text;


            //to check if we missed to implement steps inside method
            string resultOfImplementation = scenarioContext.ScenarioExecutionStatus.ToString();


            if (scenarioContext.TestError == null && resultOfImplementation == "OK")
            {
                if (stepType == "Given")
                    _scenario.CreateNode<Given>(stepInfo);
                else if (stepType == "When")
                    _scenario.CreateNode<When>(stepInfo);
                else if (stepType == "Then")
                    _scenario.CreateNode<Then>(stepInfo);
                else if (stepType == "And")
                    _scenario.CreateNode<And>(stepInfo);
                else if (stepType == "But")
                    _scenario.CreateNode<And>(stepInfo);
            }
            else if (scenarioContext.TestError != null)
            {
                Exception? innerException = scenarioContext.TestError.InnerException;
                string? testError = scenarioContext.TestError.Message;

                if (stepType == "Given")
                    _scenario.CreateNode<Given>(stepInfo).Fail(innerException, MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64ImageType).Build());
                else if (stepType == "When")
                    _scenario.CreateNode<When>(stepInfo).Fail(innerException, MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64ImageType).Build());
                else if (stepType == "Then")
                    _scenario.CreateNode<Then>(stepInfo).Fail(testError, MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64ImageType).Build());
                else if (stepType == "And")
                    _scenario.CreateNode<Then>(stepInfo).Fail(testError, MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64ImageType).Build());
                else if (stepType == "But")
                    _scenario.CreateNode<Then>(stepInfo).Fail(testError, MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64ImageType).Build());

            }
            else if (resultOfImplementation == "StepDefinitionPending")
            {
                string errorMessage = "Step Definition is not implemented!";

                if (stepType == "Given")
                    _scenario.CreateNode<Given>(stepInfo).Fail(errorMessage, MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64ImageType).Build());
                else if (stepType == "When")
                    _scenario.CreateNode<When>(stepInfo).Fail(errorMessage, MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64ImageType).Build());
                else if (stepType == "Then")
                    _scenario.CreateNode<Then>(stepInfo).Fail(errorMessage, MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64ImageType).Build());
                else if (stepType == "But")
                    _scenario.CreateNode<Then>(stepInfo).Fail(errorMessage, MediaEntityBuilder.CreateScreenCaptureFromBase64String(base64ImageType).Build());

            }

        }
    }
    }

