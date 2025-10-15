using System;
using System.IO;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumDemo.Utilities;
using Reqnroll;
using AventStack.ExtentReports.Gherkin.Model;


namespace SeleniumDemo.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private readonly ScenarioContext _scenarioContext;

        public static ExtentReports _extentReports;
        public static ExtentTest _feature;
        public static ExtentTest _scenario;

        // Base directory for test results
        public static string Dir = AppDomain.CurrentDomain.BaseDirectory;
        public static string TestResultPath = Path.Combine(
            Dir.Replace("bin\\Debug\\net9.0", "TestResults"),
            DateTime.Now.ToString("yyyyMMdd_HHmmss")
        );

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Directory.CreateDirectory(TestResultPath);
            var htmlReporter = new ExtentHtmlReporter(TestResultPath);
            htmlReporter.Config.DocumentTitle = "Automation Status Report";
            htmlReporter.Config.ReportName = "Automation Status Report";
            htmlReporter.Config.Theme = Theme.Standard;

            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(htmlReporter);
            _extentReports.AddSystemInfo("OS", Environment.OSVersion.ToString());
            _extentReports.AddSystemInfo("Browser", "Chrome/Edge");
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            _extentReports.Flush();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            _feature = _extentReports.CreateTest<AventStack.ExtentReports.Gherkin.Model.Feature>(
                featureContext.FeatureInfo.Title
            );
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _scenario = _feature.CreateNode<AventStack.ExtentReports.Gherkin.Model.Scenario>(
       _scenarioContext.ScenarioInfo.Title
   );

            var options = new ChromeOptions();

            // ✅ Enable new-style headless mode for Chrome 109+
            options.AddArgument("--headless=new");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--window-size=1920,1080");
            options.AddArgument("--disable-popup-blocking");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--disable-infobars");
            options.AddArgument("--disable-notifications");
            options.AddArgument("--enable-features=NetworkServiceInProcess");
            options.AddArgument("--disable-features=VizDisplayCompositor");

            // ✅ Optional: Set download preferences for CI/CD
            string downloadPath = Path.Combine(TestResultPath, "Downloads");
            Directory.CreateDirectory(downloadPath);
            var prefs = new Dictionary<string, object>
            {
                ["download.default_directory"] = downloadPath,
                ["download.prompt_for_download"] = false,
                ["download.directory_upgrade"] = true,
                ["safebrowsing.enabled"] = true
            };
            options.AddUserProfilePreference("prefs", prefs);

            // ✅ Launch Chrome with configured options
            var driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            // ✅ Remove ads or popups automatically
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript(@"
            const adSelectors = [
                'iframe[id*=""ad""]',
                'div[id*=""ad""]',
                'div[class*=""ad""]',
                'div[class*=""popup""]',
                'div[id*=""popup""]',
                'div[class*=""banner""]',
                'div[id*=""banner""]'
            ];
            adSelectors.forEach(sel => {
                document.querySelectorAll(sel).forEach(e => e.remove());
            });
        ");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not remove ads automatically: {e.Message}");
            }

            _scenarioContext["driver"] = driver;
            drivers.Driver = driver;
        }

        [AfterStep]
        public void AfterStep()
        {
            var driver = (IWebDriver)_scenarioContext["driver"];
            string stepName = _scenarioContext.StepContext.StepInfo.Text;
            string stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();

            if (_scenarioContext.TestError == null)
            {
                switch (stepType)
                {
                    case "Given": _scenario.CreateNode<Given>(stepName); break;
                    case "When": _scenario.CreateNode<When>(stepName); break;
                    case "Then": _scenario.CreateNode<Then>(stepName); break;
                    case "And": _scenario.CreateNode<And>(stepName); break;
                }
            }
            else
            {
                string screenshotPath = AddScreenshot(driver, _scenarioContext);
                switch (stepType)
                {
                    case "Given":
                        _scenario.CreateNode<Given>(stepName)
                            .Fail(_scenarioContext.TestError.Message,
                                  MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
                        break;
                    case "When":
                        _scenario.CreateNode<When>(stepName)
                            .Fail(_scenarioContext.TestError.Message,
                                  MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
                        break;
                    case "Then":
                        _scenario.CreateNode<Then>(stepName)
                            .Fail(_scenarioContext.TestError.Message,
                                  MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
                        break;
                    case "And":
                        _scenario.CreateNode<And>(stepName)
                            .Fail(_scenarioContext.TestError.Message,
                                  MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build());
                        break;
                }
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var driver = (IWebDriver)_scenarioContext["driver"];
            driver.Quit();
        }

        private string AddScreenshot(IWebDriver driver, ScenarioContext scenarioContext)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string screenshotDir = Path.Combine(TestResultPath, "Screenshots");
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
