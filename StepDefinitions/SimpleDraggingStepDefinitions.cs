using System;
using Reqnroll;
using SeleniumDemo.Pages;

namespace SeleniumDemo.StepDefinitions
{
    [Binding]
    public class SimpleDraggingStepDefinitions
    {
        public static SimpleDrag simpleDrag = new SimpleDrag();
        [When("We drag the element with the text {string} into the box")]
        public void WhenWeDragTheElementWithTheTextIntoTheBox(string p0)
        {
            simpleDrag.simpledrag(p0);
        }

        [Then("Verify if the dragging is done for the element with the text {string}")]
        public void ThenVerifyIfTheDraggingIsDoneForTheElementWithTheText(string p0)
        {
            simpleDrag.validate_drag();
        }

    }
}
