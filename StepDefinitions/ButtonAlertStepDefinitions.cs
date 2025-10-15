using System;
using Reqnroll;
using SeleniumDemo.Pages;

namespace SeleniumDemo.StepDefinitions
{
    [Binding]
    public class ButtonAlertStepDefinitions
    {
        public static Alert alertPage= new Alert();

        [When("We click on the Click me button with the text {string}")]
        public void WhenWeClickOnTheClickMeButtonWithTheText(string p0)
        {
            alertPage.clickalertButton(p0);
        }


        [When("We click on the Click me button {string}")]
        public void WhenWeClickOnTheClickMeButton(string p0)
        {
            alertPage.clickAlertButton(p0);
        }

        [Then("The alert should be displayed with the text {string}")]
        public void ThenTheAlertShouldBeDisplayedWithTheText(string p0)
        {
            alertPage.VerifyAlertText(p0);
        }
    }
}
