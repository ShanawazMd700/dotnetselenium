using System;
using Reqnroll;
using SeleniumDemo.Pages;

namespace SeleniumDemo.StepDefinitions
{
    [Binding]
    public class WebTableInteractionStepDefinitions
    {
        public static WebTables webTables = new WebTables();
        [When("We click on the button with the text Add")]
        public void WhenWeClickOnTheButtonWithTheTextAdd()
        {
            webTables.clickAddButton();
        }

        [When("We fill in the field with the label First Name with the value {string}")]
        public void WhenWeFillInTheFieldWithTheLabelFirstNameWithTheValue(string john)
        {
            webTables.fillFirstName(john);
        }

        [When("We fill in the field with the label Last Name with the value {string}")]
        public void WhenWeFillInTheFieldWithTheLabelLastNameWithTheValue(string doe)
        {
            webTables.fillLastName(doe);
        }

        [When("We fill in the field with the label emailID with the value {string}")]
        public void WhenWeFillInTheFieldWithTheLabelEmailIDWithTheValue(string p0)
        {
            webTables.fillEmail(p0);
        }

        [When("We fill in the field with the label Age with the value {string}")]
        public void WhenWeFillInTheFieldWithTheLabelAgeWithTheValue(string p0)
        {
            webTables.fillAge(p0);
        }

        [When("We fill in the field with the label Salary with the value {string}")]
        public void WhenWeFillInTheFieldWithTheLabelSalaryWithTheValue(string p0)
        {
            webTables.fillSalary(p0);
        }

        [When("We fill in the field with the label Department with the value {string}")]
        public void WhenWeFillInTheFieldWithTheLabelDepartmentWithTheValue(string engineering)
        {
            webTables.fillDepartment(engineering);
        }

        [When("We click on the submit Button")]
        public void WhenWeClickOnTheSubmitButton()
        {
            webTables.clickSubmitButton();
        }

        [Then("The firstname {string} should be added to the WebTable")]
        public void ThenTheFirstnameShouldBeAddedToTheWebTable(string john)
        {
            webTables.validatethefirstname(john);
        }
    }
}
