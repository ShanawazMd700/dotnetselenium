using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using SeleniumDemo.Utilities;
using static SeleniumDemo.Locators.Ilocators;

namespace SeleniumDemo.Pages
{
    public class Link
    {
        public ControlHelper controlHelper;
        public WaitHelpers waitHelpers;
        public Link()
        {
            controlHelper = new ControlHelper();
            waitHelpers = new WaitHelpers();
        }
        public void clickhome()
        {
            controlHelper.ButtonClick(links_link1);
        }
        public void clickhome2()
        {
            controlHelper.ButtonClick(links_link2);
        }
        public void validateclickhome1()
        {
            var driver = drivers.Driver;
            string expectedUrl = "https://demoqa.com/";
            // Store the original window handle
            string originalWindow = driver.CurrentWindowHandle;
            // Wait until a new window/tab is opened
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.WindowHandles.Count > 1);
            // Switch to the new window/tab
            var newWindowHandle = driver.WindowHandles.First(h => h != originalWindow);
            driver.SwitchTo().Window(newWindowHandle);
            // Validate the URL
            string actualUrl = driver.Url;
            Assert.AreEqual(expectedUrl, actualUrl,
                $"Expected URL '{expectedUrl}' but got '{actualUrl}'");
            // Close the new tab
            driver.Close();
            // Switch back to the original tab
            driver.SwitchTo().Window(originalWindow);
        }

        public void selectlinkoptions(string value)
        {
            controlHelper.ButtonClick(linkoptions(value));
        }
        public void validatetheclick(string value)
        {
            controlHelper.validateText(link_response,value);
        }
    }
}
