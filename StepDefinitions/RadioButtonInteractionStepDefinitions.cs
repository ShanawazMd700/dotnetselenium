using System;
using Reqnroll;
using SeleniumDemo.Pages;

namespace SeleniumDemo.StepDefinitions
{
    [Binding]
    public class RadioButtonInteractionStepDefinitions
    {
        public static RadioButton radioButton = new RadioButton();
        [When("We click on  the element with text {string}")]
        public void WhenWeClickOnTheElementWithText(string yes)
        {
            radioButton.selectRadioButton(yes);
        }

        [Then("The radio button with the text {string} should be checked")]
        public void ThenTheRadioButtonWithTheTextShouldBeChecked(string yes)
        {
            radioButton.validateRadiobutton(yes);
        }
    }
}
