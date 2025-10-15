using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumDemo.Utilities
{
    public class WaitHelpers
    {
        public IWebElement WaitForElement(By locator, int time = 20)
        {
            var wait = new WebDriverWait(drivers.Driver, TimeSpan.FromSeconds(time));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            Assert.IsTrue(element.Displayed, $"Element located by {locator} should be visible, but it is not.");
            return element;
        }
    }
}
