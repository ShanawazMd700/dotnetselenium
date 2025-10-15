using System;
using Reqnroll;
using SeleniumDemo.Pages;

namespace SeleniumDemo.StepDefinitions
{
    [Binding]
    public class WidgetsStepDefinitions
    {
        public static SelectMenu selectmenu = new SelectMenu();
        [When("We select the option {string} from the first dropdown")]
        public void WhenWeSelectTheOptionFromTheFirstDropdown(string p0)
        {
            selectmenu.SelectDropdownOption(p0);
        }

        [Then("Verify if the option {string} is selected in the first dropdown")]
        public void ThenVerifyIfTheOptionIsSelectedInTheFirstDropdown(string p0)
        {
           selectmenu.verifyselectedoption(p0);
        }
        [When("We select the option {string} from the second dropdown")]
        public void WhenWeSelectTheOptionFromTheSecondDropdown(string p0)
        {
            selectmenu.selectsecondoption(p0);
        }
        [Then("We select {string} from the standard dropdown")]
        public void ThenWeSelectFromTheStandardDropdown(string option)
        {
            selectmenu.selectStandardoption(option);
        }

        [Then("Verify if {string} is selected in the standard dropdown")]
        public void ThenVerifyIfIsSelectedInTheStandardDropdown(string option)
        {
           selectmenu.verifyStandardoption(option);
        }
        [Then("We select {string} from the third dropdown")]
        public void ThenWeSelectFromTheThirdDropdown(string color)
        {
            //selectmenu.selectthirdoption(color);
            selectmenu.SelectMultiDropdownOptions(color);
        }

    }
}
