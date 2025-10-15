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
    public class Formfill
    {
        public ControlHelper controlHelper;
        public WaitHelpers waitHelpers;
        private string Month;
        public Formfill()
        {
            controlHelper = new ControlHelper();
            waitHelpers = new WaitHelpers();
        }

        public void EnterFullName(string nametype, string value)
        {
            controlHelper.EnterText(name_registration(nametype), value);
        }
        public void EnterEmail(string email)
        {
            controlHelper.ScrollToElement(email_registration);
            controlHelper.EnterText(email_registration, email);
        }
        public void SelectGender(string value)
        {

            controlHelper.ButtonClick(formRadiobutton(value));
        }
        public void enterMobile(string value)
        {
            controlHelper.EnterText(mobilenumber, value);
        }
        public void enterSubjects(string value)
        {
            controlHelper.ScrollToElement(subjectsInput);
            var element = waitHelpers.WaitForElement(subjectsInput);
            element.SendKeys(value);
            element.SendKeys(Keys.Enter);
        }
        public void SelectYear(string year)
        {
            controlHelper.ButtonClick(dob_box);
            var yearDropdown = waitHelpers.WaitForElement(yearbase);
            var optionElement = yearDropdown.FindElement(By.XPath($".//option[text()='{year}']"));

            // Scroll the option into view
            ((IJavaScriptExecutor)drivers.Driver).ExecuteScript("arguments[0].scrollIntoView(true);", optionElement);

            // Then select it
            var select = new SelectElement(yearDropdown);
            select.SelectByText(year);
        }
        public void SelectMonth(string month) 
        {
            month = Month;
            controlHelper.ButtonClick(monthbase);
            controlHelper.ButtonClick(monthPick(month));
        }
        public void selectdate(string value2)
        {
            controlHelper.ButtonClick(datePick(Month, value2));
        }
        public void selectstate(string state)
        {
            controlHelper.EnterText(state_input, state + Keys.ArrowDown +Keys.Tab);
        }
        public void selectcity(string city)
        {
            controlHelper.EnterText(city_input, city + Keys.ArrowDown + Keys.Tab);
        }
        public void verifythetext(string expectedtext)
        {
            var actualText = controlHelper.GetText(header_text(expectedtext));
            Assert.IsTrue(actualText.Contains(expectedtext), 
                $"Expected text '{expectedtext}' not found in header: {actualText}");

        }
    }
}
