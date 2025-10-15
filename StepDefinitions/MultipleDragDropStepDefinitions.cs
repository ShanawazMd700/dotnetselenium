using System;
using Reqnroll;
using SeleniumDemo.Pages;

namespace SeleniumDemo.StepDefinitions
{
    [Binding]
    public class MultipleDragDropStepDefinitions
    {
        public static MultipleDragDrop multipleDragDrop = new MultipleDragDrop();

        [When("We select the side option as {string}")]
        public void WhenWeSelectTheSideOptionAs(string accept)
        {
            multipleDragDrop.selectsideoption(accept);
        }

        [When("We drag the first box")]
        public void WhenWeDragTheFirstBox()
        {
            multipleDragDrop.first_dragdrop();
        }

        [Then("verify the first drag")]
        public void ThenVerifyTheFirstDrag()
        {
            multipleDragDrop.VerifyFristDrag();
        }

        [When("We drag second box")]
        public void WhenWeDragSecondBox()
        {
            multipleDragDrop.second_dragdrop();
        }

        [Then("verify the second drag")]
        public void ThenVerifyTheSecondDrag()
        {
            multipleDragDrop.VerifySecondDrag();
        }
    }
}
