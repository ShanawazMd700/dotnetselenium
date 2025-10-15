using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using OpenQA.Selenium;

namespace SeleniumDemo.Utilities
{
    public class ExtentReport
    {
        public static ExtentReports _extentReports;
        public static ExtentTest _feature;
        public static ExtentTest _scenario;

        public static String dir = AppDomain.CurrentDomain.BaseDirectory;
        public static String testResultPath = Path.Combine(dir.Replace("bin\\Debug\\net6.0", "TestResults"), DateTime.Now.ToString("yyyyMMdd_HHmmss"));

        public static void ExtentReportInit()
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HH_mm_ss");
            string uniqueTestResultPath = Path.Combine(testResultPath, timestamp);

            // Ensure the directory exists
            Directory.CreateDirectory(uniqueTestResultPath);

            var htmlReporter = new ExtentHtmlReporter(uniqueTestResultPath);
            htmlReporter.Config.ReportName = "Automation Status Report";
            htmlReporter.Config.DocumentTitle = "Automation Status Report";
            htmlReporter.Config.Theme = Theme.Standard;
            htmlReporter.Start();

            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(htmlReporter);
            _extentReports.AddSystemInfo("Application", "ApiDemos-debug.apk");
            _extentReports.AddSystemInfo("OS", "Android 11");
        }

        public static void ExtentReportTearDown()
        {
            _extentReports.Flush();
        }
        public string addScreenshot(IWebDriver driver, ScenarioContext scenarioContext)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string screenshotDir = Path.Combine(testResultPath, "Screenshots");
            Directory.CreateDirectory(screenshotDir);

            // Sanitize scenario name
            string safeScenarioName = string.Join("_", scenarioContext.ScenarioInfo.Title.Split(Path.GetInvalidFileNameChars()));

            string screenshotPath = Path.Combine(screenshotDir, safeScenarioName + ".png");

            // Save screenshot manually
            File.WriteAllBytes(screenshotPath, screenshot.AsByteArray);

            return screenshotPath;
        }
    }
    }

