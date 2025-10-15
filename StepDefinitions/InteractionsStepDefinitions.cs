using System;
using Reqnroll;
using SeleniumDemo.Pages;

namespace SeleniumDemo.StepDefinitions
{
    [Binding]
    public class InteractionsStepDefinitions
    {
        public static OuterAndInnerDrag outerAndInnerDrag = new OuterAndInnerDrag();
        public static Resize resize = new Resize();
        public static Select select = new Select();
        public static Sort sort = new Sort();
        [When("We drag the element with the text {string} into the outer box")]
        public void WhenWeDragTheElementWithTheTextIntoTheOuterBox(string p0)
        {
            outerAndInnerDrag.DragAndDropOuterBox(p0);
        }

        [Then("Verify if the dropping is done for the outer box and the text {string} is displayed")]
        public void ThenVerifyIfTheDroppingIsDoneForTheOuterBoxAndTheTextIsDisplayed(string p0)
        {
            outerAndInnerDrag.validateTextInOuterBox(p0);
        }
        [When("We drag the element with the text {string} into the inner box")]
        public void WhenWeDragTheElementWithTheTextIntoTheInnerBox(string p0)
        {
           outerAndInnerDrag.DragAndDropInnerBox(p0);
        }

        [Then("Verify if the dropping is done for the inner box and the text {string} is displayed")]
        public void ThenVerifyIfTheDroppingIsDoneForTheInnerBoxAndTheTextIsDisplayed(string p0)
        {
            outerAndInnerDrag.validateTextInInnerBox(p0);
        }
        [When("We drag the element with the text {string} into other outer box")]
        public void WhenWeDragTheElementWithTheTextIntoOtherOuterBox(string p0)
        {
            outerAndInnerDrag.DragAndDropOtherOuterBox(p0);
        }

        [Then("Verify if the dropping is done for the other outer box and the text {string} is displayed")]
        public void ThenVerifyIfTheDroppingIsDoneForTheOtherOuterBoxAndTheTextIsDisplayed(string p0)
        {
            outerAndInnerDrag.validateTextInOtherOuterBox(p0);
        }
        [When("We drag the element with the text {string} into other inner box")]
        public void WhenWeDragTheElementWithTheTextIntoOtherInnerBox(string p0)
        {
           outerAndInnerDrag.DragAndDropOtherInnerBox(p0);
        }

        [Then("Verify if the dropping is done for the other inner box and the text {string} is displayed")]
        public void ThenVerifyIfTheDroppingIsDoneForTheOtherInnerBoxAndTheTextIsDisplayed(string p0)
        {
            outerAndInnerDrag.validateTextInOtherInnerBox(p0);
        }
        [When("We drag the element with text {string} into the box with the text Drop here")]
        public void WhenWeDragTheElementWithTextIntoTheBoxWithTheTextDropHere(string p0)
        {
            outerAndInnerDrag.dragRevertable(p0);
        }

        [Then("Verify if the text {string} is displayed in the box")]
        public void ThenVerifyIfTheTextIsDisplayedInTheBox(string p0)
        {
            outerAndInnerDrag.validateTextInRevertableBox(p0);
        }

        [Then("Verify if the element with the text Will Revert has reverted back to its original position")]
        public void ThenVerifyIfTheElementWithTheTextWillRevertHasRevertedBackToItsOriginalPosition()
        {
            outerAndInnerDrag.VerifyRevertableDrag();
        }
        [When("We resize the box with x cordinates {string} and y coordinates {string}")]
        public void WhenWeResizeTheBoxWithXCordinatesAndYCoordinates(int p0, int p1)
        {
            resize.Resizeto(p0, p1);
        }

        [Then("Verify if the resizing is done with x coordinates {string} and y coordinates {string}")]
        public void ThenVerifyIfTheResizingIsDoneWithXCoordinatesAndYCoordinates(int p0, int p1)
        {
           resize.VerifySlided(p0, p1);
        }
        [When("We resize thee other box with the X coordinate {string} and Y coordinate {string}")]
        public void WhenWeResizeTheeOtherBoxWithTheXCoordinateAndYCoordinate(string p0, string p1)
        {
            resize.ResizeOtherelement(int.Parse(p0), int.Parse(p1));
        }
        [Then("Verify if the resizing is done for the other box with x coordinates {string} and y coordinates {string}")]
        public void ThenVerifyIfTheResizingIsDoneForTheOtherBoxWithXCoordinatesAndYCoordinates(int p0, int p1)
        {
           resize.VerifySlidedOther(p0, p1);
        }

        [When("We select the item with the text {string}")]
        public void WhenWeSelectTheItemWithTheText(string p0)
        {
            select.selectoption(p0);
        }

        [Then("Verify if the item with the text {string} is selected")]
        public void ThenVerifyIfTheItemWithTheTextIsSelected(string p0)
        {
            select.verifyselected(p0);
        }
        [When("We sort the item with text {string} to the position of item {string}")]
        public void WhenWeSortTheItemWithTextToThePositionOfItem(string one, string four)
        {
            sort.performsort(one, four);   
        }
        [When("We sort the item with text  {string} to the position of item {string}")]
        public void WhenWeSortTheItemWithTextToThePositionOfItem1(string one, string four)
        {
            sort.performothersort(one, four);
        }


        [Then("Verify if the item with text {string} is in the position of item {string}")]
        public void ThenVerifyIfTheItemWithTextIsInThePositionOfItem(string p0, string p1)
        {
            
        }


    }
}
