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
    public class Alert
    {
        public ControlHelper controlHelper;
        public WaitHelpers waitHelpers;
        //private IWebDriver driver;
        public Alert()
        {
            controlHelper = new ControlHelper();
            waitHelpers = new WaitHelpers();
        }
        public void VerifyAlertText(string expectedText)
        {
            IAlert alert = drivers.Driver.SwitchTo().Alert();
            string actualText = alert.Text;
            Assert.AreEqual(expectedText, actualText, "Alert text does not match!");
            alert.Accept();
        }

        public void enterTextInAlert(string text)
        {
            IAlert alert = drivers.Driver.SwitchTo().Alert();
            alert.SendKeys(text);
            alert.Accept();
        }
        public void clickAlertButton(string value)
        {
            controlHelper.ButtonClick(alert_button(value));
        }
        public void clickalertButton(string value)
        {
            controlHelper.ButtonClick(alert_buttons(value));

        }
        public void entertextAlert(string value)
        {
            IAlert alert = drivers.Driver.SwitchTo().Alert();
            // Enter text in the prompt
            alert.SendKeys(value);
            alert.Accept();

        }
    }
}
