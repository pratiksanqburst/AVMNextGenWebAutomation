using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Reflection;
namespace AVMNextGenWebAutomation
{
    public class ExtentReportHelper
    {
        public ExtentReports extent { get; set; }
        public ExtentHtmlReporter? reporter { get; set; }
        public ExtentTest? test { get; set; }
        public ExtentReportHelper()
        {
            extent = new ExtentReports();
            extent.AddSystemInfo("Application Under Test", "Netstar Fleet Lite");
            extent.AddSystemInfo("Environment", "UAT");
            extent.AddSystemInfo("Machine", Environment.MachineName);
            extent.AddSystemInfo("OS", Environment.OSVersion.VersionString);
        }
        public string ScreenCaptureAsBase64String(IWebDriver driver)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            return screenshot.AsBase64EncodedString;
        }
        public string TakeScreenshot(IWebDriver driver)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string path1 = AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug\\net6.0", "AVMNextGenScreenshots");
            string path = path1 + DateTime.Now.ToString("ddMMyyyyhss") + ".png";
            screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
            return path;
        }
        public ExtentTest CreateTest(string testName)
        {
            test = extent.CreateTest(testName);
            return test;
        }
        public void AttachReporter(ExtentHtmlReporter reporter)
        {
            extent.AttachReporter(reporter);
        }
        public void SetStepStatusPass(string stepDescription)
        {
            test.Log(Status.Pass, stepDescription);
        }
        public void SetStepStatusWarning(string stepDescription)
        {
            test.Log(Status.Warning, stepDescription);
        }
        public void SetTestStatusPass()
        {
            test.Pass("Test Executed Sucessfully!");
        }
        public void SetTestStatusFail(string message = null)
        {
            var printMessage = "<p><b>Test FAILED!</b></p>";
            if (!string.IsNullOrEmpty(message))
            {
                printMessage += $"Message: <br>{message}<br>";
            }
            test.Fail(printMessage);
        }
        public void AddTestFailureScreenshot(string base64ScreenCapture)
        {
            test.AddScreenCaptureFromBase64String(base64ScreenCapture, "Screenshot on Error:");
        }
        public void AddTestFailureScreenshotsaved(string path)
        {
            test.AddScreenCaptureFromPath(path);
        }
        public void SetTestStatusSkipped()
        {
            test.Skip("Test skipped!");
        }
        public void Close()
        {
            extent.Flush();
        }
    }
}