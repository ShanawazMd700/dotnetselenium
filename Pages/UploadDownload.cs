using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SeleniumDemo.Utilities;
using static SeleniumDemo.Locators.Ilocators;

namespace SeleniumDemo.Pages
{
    public class UploadDownload
    {
        public ControlHelper controlHelper;
        public WaitHelpers waitHelpers;
        public UploadDownload()
        {
            controlHelper = new ControlHelper();
            waitHelpers = new WaitHelpers();
        }
        public void uploadFile(string path)
        {            
            var fileInput = waitHelpers.WaitForElement(uploadButton);
            fileInput.SendKeys(path);
        }
        public void clickdownloadFile()
        {
            controlHelper.ButtonClick(downloadButton);
        }
        public void VerifyFileDownloaded()
        {
            string downloadPath = @"C:\Users\iray\Downloads\";
            string fileName = "sampleFile.jpeg";
            string fullPath = Path.Combine(downloadPath, fileName);

            // wait for the file to appear (max 30 seconds)
            int retries = 30;
            while (retries > 0 && !File.Exists(fullPath))
            {
                Thread.Sleep(1000);
                retries--;
            }

            Assert.IsTrue(File.Exists(fullPath), $"File '{fileName}' was not downloaded.");
        }
        public void verifyUploadSuccess(string expectedText)
        {
            // Verify the upload was successful by checking the response text
            string actualText = controlHelper.GetText(uploadResponse);
            Assert.IsTrue(actualText.Contains(expectedText), $"Expected text '{expectedText}' not found in response: {actualText}");
        }
    }
}
