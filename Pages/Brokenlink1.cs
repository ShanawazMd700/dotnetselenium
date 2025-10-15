using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumDemo.Utilities;
using static SeleniumDemo.Locators.Ilocators;

namespace SeleniumDemo.Pages
{
    public class Brokenlink1
    {
        public ControlHelper controlHelper;
        public WaitHelpers waitHelpers;
        public Brokenlink1()
        {
            controlHelper = new ControlHelper();
            waitHelpers = new WaitHelpers();
        }
        public void clickonlink(string value)
        {
            controlHelper.ButtonClick(Links1(value));
        }

        public void validatelink(string url)
        {
            var driver = drivers.Driver;
            string expectedUrl = url;           
            waitHelpers.WaitForElement(By.XPath("//div[@class='home-banner']"));
            string actualUrl = driver.Url;
            Assert.AreEqual(expectedUrl, actualUrl,
                $"Expected URL '{expectedUrl}' but got '{actualUrl}'");

        }
    }
}
