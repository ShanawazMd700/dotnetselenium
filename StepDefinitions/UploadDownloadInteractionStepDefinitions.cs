using System;
using Reqnroll;
using SeleniumDemo.Pages;

namespace SeleniumDemo.StepDefinitions
{
    [Binding]
    public class UploadDownloadInteractionStepDefinitions
    {
        public static UploadDownload uploadDownload = new UploadDownload();
        [When("We click on the button with the text Download")]
        public void WhenWeClickOnTheButtonWithTheTextDownload()
        {
            uploadDownload.ClickDownloadFile();
            Thread.Sleep(2000); // Wait for the download to start
        }

        [Then("The file should be downloaded successfully")]
        public void ThenTheFileShouldBeDownloadedSuccessfully()
        {
            uploadDownload.VerifyFileDownloaded();
        }

        [When("We upload a file with the path {string}")]
        public void WhenWeUploadAFileWithThePath(string p0)
        {
            uploadDownload.UploadFile(p0);
        }


        [Then("Verify the text {string} should be displayed successfully")]
        public void ThenVerifyTheTextShouldBeDisplayedSuccessfully(string p0)
        {
            uploadDownload.VerifyUploadSuccess(p0);
        }

    }
}
