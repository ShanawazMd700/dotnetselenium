using System;
using Reqnroll;
using SeleniumDemo.Pages;

namespace SeleniumDemo.StepDefinitions
{
    [Binding]
    public class DragAndDropStepDefinitions
    {
        public static DragDrop dragDrop = new DragDrop();
        [When("We drag the element with the text {string} into the box with the text {string}")]
        public void WhenWeDragTheElementWithTheTextIntoTheBoxWithTheText(string p0, string p1)
        {
            dragDrop.dragdrop(p0, p1);
        }

        [Then("Verify if the dropping is done for the box with the text {string}")]
        public void ThenVerifyIfTheDroppingIsDoneForTheBoxWithTheText(string p0)
        {
            dragDrop.validate_dragdrop();
        }
    }
}
