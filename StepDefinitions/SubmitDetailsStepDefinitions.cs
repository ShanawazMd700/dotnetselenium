using System;
using OpenQA.Selenium;
using Reqnroll;
using SeleniumDemo.Pages;
using SeleniumDemo.Utilities;

namespace SeleniumDemo.StepDefinitions
{
    [Binding]
    public class SubmitDetailsStepDefinitions
    {
        public static SubmitDetails submitDetails = new SubmitDetails();
        public static MainWebpage mainWebpage = new MainWebpage();
        public SubmitDetailsStepDefinitions(ScenarioContext scenarioContext)
        {
            driver = (IWebDriver)scenarioContext["driver"];
        }

        private readonly IWebDriver driver;

        [Given("We go to the page {string}")]
        public void GivenWeGoToThePage(string url)
        {
            //mainWebpage.NavigateToMainWebpage(url);
            driver.Navigate().GoToUrl(url);
        }

        [Given("We click on the element with the text {string}")]
        public void GivenWeClickOnTheElementWithTheText(string elements)
        {
           mainWebpage.ClickOnElement(elements);
        }

        [When("We click on the element with the text {string}")]
        public void WhenWeClickOnTheElementWithTheText(string p0)
        {
            mainWebpage.ClickOnOption(p0);
        }

        [When("We fill in the field with the label Full Name with the value {string}")]
        public void WhenWeFillInTheFieldWithTheLabelFullNameWithTheValue(string p0)
        {
           submitDetails.EnterFullName(p0);
        }

        [When("We fill in the field with the label Email with the value {string}")]
        public void WhenWeFillInTheFieldWithTheLabelEmailWithTheValue(string p0)
        {
            submitDetails.EnterEmail(p0);
        }

        [When("We fill in the field with the label Current Address with the value {string}")]
        public void WhenWeFillInTheFieldWithTheLabelCurrentAddressWithTheValue(string p0)
        {
            submitDetails.EnterCurrentAddress(p0);
        }

        [When("We fill in the field with the label Permanent Address with the value {string}")]
        public void WhenWeFillInTheFieldWithTheLabelPermanentAddressWithTheValue(string p0)
        {
            submitDetails.EnterPermanentAddress(p0);
        }


        [Then("Validation should be done on the fields")]
        public void ThenValidationShouldBeDoneOnTheFields()
        {
            submitDetails.validateTheTexts();   
        }
    }
}
