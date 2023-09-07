using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Resources;
using System.Configuration;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using AventStack.ExtentReports;
using Microsoft.Extensions.Configuration;

namespace AVMNextGenWebAutomation
{
    [TestFixture]
    public abstract class AVMNextGenBase
    {
        public static IWebDriver driver;
        public static WebDriverWait wait;
        public static ExtentReportHelper extent;
        public static ExtentTest test;
        public ExtentHtmlReporter? reporter;
        public static IConfiguration config = new ConfigurationBuilder().AddJsonFile(TestContext.CurrentContext.TestDirectory+"\\appsettings.json").Build();
        public static string environment = config["AppSettings:Environment"];
        static ResourceManager rm = new ResourceManager($"AVMNextGenWebAutomation.TestData{environment}",
                Assembly.GetExecutingAssembly());
        public static string userName = rm.GetString("Username");
        public static string password = rm.GetString("Password");
        public static string adminUser = rm.GetString("AdminUser");
        public static string adminPassword = rm.GetString("AdminPassword");
        public static string adminDev = rm.GetString("AdminDev");
        public static string adminDevPassword = rm.GetString("AdminDevPassword");
        public static string loginAddress = rm.GetString("BaseAddress");
        public static string userNameFM = rm.GetString("AdminFM");
        public static string passwordFM = rm.GetString("AdminFMPassword");



        [OneTimeSetUp]
        public void ReportInitialization()
        {

            extent = new ExtentReportHelper();
            var dir = TestContext.CurrentContext.TestDirectory.Replace("bin\\Debug\\net6.0", "AVMNextGenReports") + "\\";
            string fileName = this.GetType().ToString().Replace("AVMNextGenWebAutomation.AVMNextGenRegressionTests.", "");
            reporter = new ExtentHtmlReporter(dir + fileName);
            extent.AttachReporter(reporter);
           
        }

        [SetUp]
        public void StartUpTest()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArguments("headless");
            chromeOptions.AddArguments("--window-size=1920,1080");
            driver = new ChromeDriver(chromeOptions);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            extent.SetStepStatusPass("Browser started.");
            driver.Manage().Window.Maximize();
            extent.SetStepStatusPass("Browser maximized.");
            driver.Navigate().GoToUrl(loginAddress);
            extent.SetStepStatusPass($"Browser navigated to the url.");

        }

        [TearDown]
        public void AfterTest()
        {
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var stacktrace = TestContext.CurrentContext.Result.StackTrace;
                var errorMessage = "<pre>" + TestContext.CurrentContext.Result.Message + "</pre>";
                switch (status)
                {
                    case TestStatus.Failed:
                        extent.SetTestStatusFail($"<br>{errorMessage}<br>Stack Trace: <br>{stacktrace}<br>");
                        extent.AddTestFailureScreenshotsaved(extent.TakeScreenshot(driver));
                        break;
                    case TestStatus.Skipped:
                        extent.SetTestStatusSkipped();
                        break;
                    default:
                        extent.SetTestStatusPass();
                        break;
                }
            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                driver.Close();
            }
        }
        [OneTimeTearDown]
        public void CloseBrowser()
        {
            extent.Close();
            driver.Quit();
        }
    }
}
