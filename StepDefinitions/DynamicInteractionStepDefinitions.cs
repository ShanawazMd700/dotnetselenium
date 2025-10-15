using System;
using Reqnroll;
using SeleniumDemo.Pages;

namespace SeleniumDemo.StepDefinitions
{
    [Binding]
    public class DynamicInteractionStepDefinitions
    {
        public static DynamicInteraction dynamicInteraction = new DynamicInteraction();
        [When("We wait for {string} seconds")]
        public void WhenWeWaitForSeconds(int p0)
        {
            dynamicInteraction.wait(p0);
        }

        [When("We click on the button with the text {string}")]
        public void WhenWeClickOnTheButtonWithTheText(string p0)
        {
            dynamicInteraction.clickDynamicButton(p0);
        }
        [Then("verify the button {string} is {string}")]
        public void ThenVerifyTheButtonIs(string button, string color)
        {
            dynamicInteraction.validatethebuttoncolor(button, color);
        }

    }
}
