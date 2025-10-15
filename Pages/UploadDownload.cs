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
            FileInfo file;

            // Resolve file path (absolute or relative to project)
            if (Path.IsPathRooted(path))
            {
                file = new FileInfo(path);
            }
            else
            {
                file = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), path));
            }

            // Ensure file exists or create dummy one
            if (!file.Exists)
            {
                try
                {
                    Directory.CreateDirectory(file.DirectoryName ?? Directory.GetCurrentDirectory());
                    using (var fs = File.Create(file.FullName)) { }
                    Console.WriteLine($"✅ Dummy upload file created: {file.FullName}");
                }
                catch (Exception e)
                {
                    throw new Exception($"❌ Failed to create file: {file.FullName}", e);
                }
            }

            try
            {
                // Detect current page
                string currentUrl = driver.Url.ToLower();
                By uploadLocator;

                if (currentUrl.Contains("upload-download"))
                {
                    uploadLocator = uploadButton; // Locator from Ilocators
                }
                else if (currentUrl.Contains("automation-practice-form"))
                {
                    uploadLocator = By.Id("uploadPicture");
                }
                else
                {
                    throw new Exception($"❌ Unknown page: cannot determine upload locator from URL: {currentUrl}");
                }

                // Wait until visible and clickable
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                var uploadElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(uploadLocator));

                // Scroll and interact
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", uploadElement);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(uploadLocator));

                uploadElement.SendKeys(file.FullName);
                Console.WriteLine($" File uploaded successfully: {file.FullName} via locator: {uploadLocator}");
            }
            catch (WebDriverTimeoutException e)
            {
                throw new Exception(" Upload input not found or clickable after waiting.", e);
            }
            catch (Exception e)
            {
                throw new Exception($" Failed to upload file: {path}", e);
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
