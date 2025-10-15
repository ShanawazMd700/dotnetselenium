using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumDemo.Utilities;
using static SeleniumDemo.Locators.Ilocators;

namespace SeleniumDemo.Pages
{
    public class BrowserWindows
    {
        public ControlHelper controlHelper;
        public WaitHelpers waitHelpers;
        public BrowserWindows()
        {
            controlHelper = new ControlHelper();
            waitHelpers = new WaitHelpers();
        }
        public void ValidateNewTab(string value)
        {
            var driver = drivers.Driver;
            string originalWindow = driver.CurrentWindowHandle;
            // Wait until a new tab is opened
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.WindowHandles.Count > 1);
            // Switch to the new tab
            var newWindowHandle = driver.WindowHandles.First(h => h != originalWindow);
            driver.SwitchTo().Window(newWindowHandle);
            // Wait for the h1 element in the new tab
            var headerElement = waitHelpers.WaitForElement(newtabHeader(value));
            // Assert element text
            Assert.AreEqual(value, headerElement.Text,
                $"Expected header text 'This is a sample page' but got '{headerElement.Text}'");
            // Close the new tab
            driver.Close();
            driver.SwitchTo().Window(originalWindow);
        }
        public void ValidateBody(string expectedMessage)
        {
            var driver = drivers.Driver;
            string originalWindow = driver.CurrentWindowHandle;

            // Wait until a new window/tab is opened
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.WindowHandles.Count > 1);

            // Switch to the new window
            var newWindowHandle = driver.WindowHandles.First(h => h != originalWindow);
            driver.SwitchTo().Window(newWindowHandle);

            // Get the entire page source (works for about:blank text windows)
            string pageContent = driver.PageSource;

            // Assert that the expected message is present
            Assert.IsTrue(pageContent.Contains(expectedMessage),
                $"Expected message '{expectedMessage}' but got '{pageContent}'");

            // Close the new window
            driver.Close();
            driver.SwitchTo().Window(originalWindow);
        }

        public void ValidateNewTab1(string expectedText)
        {
            var driver = drivers.Driver;
            string originalWindow = driver.CurrentWindowHandle;

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.WindowHandles.Count > 1);

            // Switch to new window/tab
            var newWindowHandle = driver.WindowHandles.First(h => h != originalWindow);
            driver.SwitchTo().Window(newWindowHandle);

            string actualText = string.Empty;

            try
            {
                // Try to find <h1>
                var headerElement = waitHelpers.WaitForElement(By.XPath("//h1"), 3);
                actualText = headerElement.Text.Trim();
            }
            catch
            {
                try
                {
                    // Try <body>
                    var bodyElement = waitHelpers.WaitForElement(By.XPath("//body"), 3);
                    actualText = bodyElement.Text.Trim();
                }
                catch
                {
                    // If neither exist, fallback to PageSource (used by "New Window Message")
                    actualText = driver.PageSource.Trim();
                }
            }

            Assert.AreEqual(expectedText, actualText,
                $"Expected '{expectedText}' but got '{actualText}'");

            //driver.Close();
            driver.SwitchTo().Window(originalWindow);
        }



    }
}
