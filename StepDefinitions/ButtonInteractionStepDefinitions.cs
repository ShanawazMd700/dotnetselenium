using System;
using Reqnroll;
using SeleniumDemo.Pages;

namespace SeleniumDemo.StepDefinitions
{
    [Binding]
    public class ButtonInteractionStepDefinitions
    {
        public static Button button = new Button(); 
        [When("We click on the  button with the text {string}")]
        public void WhenWeClickOnTheButtonWithTheText(string p0)
        {
            button.ClickOnButton(p0);
        }

        [Then("The message {string} should be displayed")]
        public void ThenTheMessageShouldBeDisplayed(string p0)
        {
            button.ValidateButtonActionMessage(p0);
        }

        [When("We double click on the button with the text {string}")]
        public void WhenWeDoubleClickOnTheButtonWithTheText(string p0)
        {
            button.DoubleClickOnButton(p0);
        }

        [When("We right click on the button with the text {string}")]
        public void WhenWeRightClickOnTheButtonWithTheText(string p0)
        {
            button.RightClickOnButton(p0);
        }
    }
}
