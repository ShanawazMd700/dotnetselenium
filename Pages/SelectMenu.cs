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
    public class SelectMenu
    {
        public ControlHelper controlHelper;
        public WaitHelpers waitHelpers;
        public SelectMenu()
        {
            controlHelper = new ControlHelper();
            waitHelpers = new WaitHelpers();
        }
        public void SelectDropdownOption(string optionText)
        {
            var driver = drivers.Driver;
            controlHelper.ButtonClick(firstDropdown);
            
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.FindElement(By.XPath($"//div[contains(@class,'css-1uccc91-singleValue') or contains(@class,'css-1n7v3ny-option') and text()='{optionText}']")));
            
            var option = driver.FindElement(By.XPath($"//div[contains(@class,'css-1n7v3ny-option') and text()='{optionText}']"));
            option.Click();
        }

        public void verifyselectedoption(string option)
        {
            IWebElement dropdownSelectOption = drivers.Driver.FindElement(By.XPath($"(//div[contains(@class,'css-1uccc91-singleValue') and text()='{option}'])[1]"));
            string actText = controlHelper.GetText(dropdownSelectOption);
            Assert.AreEqual(option, actText, "The selected option does not match the expected option.");
        }
        public void selectsecondoption(string optionText)
        {
            var driver = drivers.Driver;
            controlHelper.ScrollToElement(secondDropdown);
            controlHelper.ButtonClick(secondDropdown);
            // Step 2: Wait for the dropdown options to be visible
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.FindElement(By.XPath($"//div[contains(@class,'css-1uccc91-singleValue') or contains(@class,'css-1n7v3ny-option') and text()='{optionText}']")));
            // Step 3: Click the option dynamically
            var option = driver.FindElement(By.XPath($"//div[contains(@class,'css-1n7v3ny-option') and text()='{optionText}']"));
            option.Click();
        }

        public void selectStandardoption(string option)
        {
            var dropdownElement = waitHelpers.WaitForElement(standardDropdown);
            var selectElement = new SelectElement(dropdownElement);
            selectElement.SelectByText(option);
        }
        public void verifyStandardoption(string option)
        {
            var dropdownElement = waitHelpers.WaitForElement(standardDropdown);
            var selectElement = new SelectElement(dropdownElement);
            string selectedOption = selectElement.SelectedOption.Text;
            Assert.AreEqual(option, selectedOption, "The selected option does not match the expected option.");
        }

        public void SelectMultiDropdownOptions(params string[] optionTexts)
        {
            var driver = drivers.Driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            controlHelper.ScrollToElement(By.XPath("(//div[contains(@class,'css-1hwfws3')])[3]"));
            // Step 1: Click dropdown to expand
            var dropdown = driver.FindElement(By.XPath("(//div[contains(@class,'css-1hwfws3')])[3]"));
            dropdown.Click();

            // Step 2: Loop through all values
            foreach (var optionText in optionTexts)
            {
                // Wait until the option is visible
                wait.Until(d => d.FindElement(By.XPath($"//div[contains(@class,'css-1n7v3ny-option') and normalize-space(text())='{optionText}']")));

                // Click the option
                var option = driver.FindElement(By.XPath($"//div[contains(@class,'css-1n7v3ny-option') and normalize-space(text())='{optionText}']"));
                option.Click();
            }

            // (Optional) Click outside dropdown to close it
            dropdown.Click();
        }

        public void SelectDropdownColor(string colorName)
        {
            var driver = drivers.Driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            controlHelper.ScrollToElement(By.XPath("(//div[contains(@class,'css-1hwfws3')])[3]"));
            // Step 1: Click dropdown
            var dropdown = driver.FindElement(By.XPath("(//div[contains(@class,'css-1hwfws3')])[3]"));
            dropdown.Click();

            // Step 2: Wait for options to appear
            wait.Until(d => d.FindElement(By.XPath($"//div[contains(@class,'css-1n7v3ny-option') and normalize-space(text())='{colorName}']")));

            // Step 3: Click option
            var option = driver.FindElement(By.XPath($"//div[contains(@class,'css-1n7v3ny-option') and normalize-space(text())='{colorName}']"));
            option.Click();
        }

    }

}
