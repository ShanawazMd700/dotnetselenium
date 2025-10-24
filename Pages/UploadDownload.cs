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

       
        public void UploadFile(string relativePath)
        {

            var driver = drivers.Driver;

            // Ensure driver is alive
            if (driver == null)
                throw new InvalidOperationException("WebDriver is not initialized or has been disposed.");

            // Resolve file path robustly
            string binDirPath = Path.Combine(Directory.GetCurrentDirectory(), relativePath);
            string projectDir = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));
            string projectFilePath = Path.Combine(projectDir, relativePath);
            string filePath = File.Exists(binDirPath) ? binDirPath : projectFilePath;

            if (!File.Exists(filePath))
                throw new FileNotFoundException($"File does not exist in either location: {binDirPath} or {projectFilePath}");

            // Determine upload input based on current URL
            string currentUrl;
            try
            {
                currentUrl = driver.Url.ToLower();
            }
            catch (ObjectDisposedException)
            {
                throw new InvalidOperationException("WebDriver was disposed before file upload could complete.");
            }

            By uploadLocator;
            if (currentUrl.Contains("practice-form"))
                uploadLocator = By.Id("uploadPicture");
            else if (currentUrl.Contains("upload-download"))
                uploadLocator = By.Id("uploadFile");
            else
                throw new InvalidOperationException($"Unknown page: cannot determine upload input for URL: {currentUrl}");

            try
            {
                // Wait until upload element is clickable
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                var uploadElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(uploadLocator));

                // Scroll into view
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", uploadElement);
                Thread.Sleep(200); // allow scroll to settle

                // Send file path
                uploadElement.SendKeys(filePath);

                // Wait until the input value reflects uploaded file
                wait.Until(d =>
                {
                    var val = uploadElement.GetAttribute("value");
                    return !string.IsNullOrEmpty(val) && val.Contains(Path.GetFileName(filePath));
                });

                Console.WriteLine($"✅ File uploaded successfully: {filePath}");
            }
            catch (WebDriverException ex)
            {
                throw new InvalidOperationException($"Failed to upload file: {filePath}. Exception: {ex.Message}", ex);
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
