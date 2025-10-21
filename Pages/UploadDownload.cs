using System;
using System.IO;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumDemo.Utilities;
using static SeleniumDemo.Locators.Ilocators;

namespace SeleniumDemo.Pages
{
    public class UploadDownload
    {
        private readonly ControlHelper controlHelper;
        private readonly WaitHelpers waitHelpers;
        private readonly IWebDriver driver;

        public UploadDownload()
        {
            driver = drivers.Driver;
            controlHelper = new ControlHelper();
            waitHelpers = new WaitHelpers();
        }

        /** ✅ Robust file upload supporting both pages */
        public void UploadFile(string path)
        {
            // Resolve file path
            var filePath = Path.IsPathRooted(path) ? path : Path.Combine(Directory.GetCurrentDirectory(), path);

            if (!File.Exists(filePath))
            {
                // Create dummy file if it doesn’t exist
                Directory.CreateDirectory(Path.GetDirectoryName(filePath) ?? Directory.GetCurrentDirectory());
                using (var fs = File.Create(filePath)) { }
                Console.WriteLine($"✅ Dummy file created: {filePath}");
            }

            By uploadLocator;

            string currentUrl = driver.Url.ToLower();
            if (currentUrl.Contains("upload-download"))
            {
                uploadLocator = By.Id("uploadFile"); // ⚡ Make sure this points to <input type="file">
            }
            else if (currentUrl.Contains("automation-practice-form"))
            {
                uploadLocator = By.Id("uploadPicture");
            }
            else
            {
                throw new Exception($"Unknown page: {currentUrl}");
            }

            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                var uploadInput = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(uploadLocator));

                // Send file path to input
                uploadInput.SendKeys(filePath);
                Console.WriteLine($"✅ File uploaded successfully: {filePath}");
            }
            catch (Exception e)
            {
                throw new Exception($"❌ Failed to upload file: {filePath}", e);
            }
        }


        /** ✅ Download button click with scroll and wait */
        public void ClickDownloadFile()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                var button = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(downloadButton));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", button);
                button.Click();
                Console.WriteLine(" Download button clicked successfully.");
            }
            catch (Exception e)
            {
                throw new Exception(" Failed to click Download button.", e);
            }
        }

        /** ✅ Verifies downloaded file in default user Downloads folder */
        public void VerifyFileDownloaded(string fileName = "sampleFile.jpeg")
        {
            string downloadPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", fileName);
            int retries = 60;

            Console.WriteLine($"Checking for downloaded file at: {downloadPath}");
            while (retries-- > 0 && !File.Exists(downloadPath))
            {
                Thread.Sleep(1000);
                Console.Write(".");
            }
            Console.WriteLine();

            Assert.IsTrue(File.Exists(downloadPath),
                $" File '{fileName}' was not downloaded. Checked path: {downloadPath}");

            Console.WriteLine($" File downloaded successfully: {downloadPath}");
        }

        /** ✅ Verify upload confirmation text */
        public void VerifyUploadSuccess(string expectedText)
        {
            string actualText = controlHelper.GetText(uploadResponse);
            Assert.IsTrue(actualText.Contains(expectedText),
                $" Expected text '{expectedText}' not found in response. Actual: {actualText}");
        }
    }
}
