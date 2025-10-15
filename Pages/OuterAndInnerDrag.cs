using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SeleniumDemo.Utilities;
using static SeleniumDemo.Locators.Ilocators;

namespace SeleniumDemo.Pages
{
    public class OuterAndInnerDrag
    {
        public ControlHelper controlHelper;
        public WaitHelpers waitHelpers;
        private string initialloc;
        private string afterloc;
        public OuterAndInnerDrag()
        {
            controlHelper = new ControlHelper();
            waitHelpers = new WaitHelpers();
        }
        public void DragAndDropOuterBox(string value)
        {
           var value1 = dragbox1(value);
            controlHelper.DragAndDrop(value1, targetbox);
        }
        public void validateTextInOuterBox(string value)
        {
           var exText = controlHelper.GetText(targetbox);
           Assert.IsTrue(exText.Contains(value), $"Expected text '{value}' not found in the target box. Actual text: '{exText}'");
        }

        public void DragAndDropInnerBox(string value)
        {
            var value1 = dragbox1(value);
            controlHelper.DragAndDrop(value1, targetbox1);
        }
        public void validateTextInInnerBox(string value)
        {
            var exText = controlHelper.GetText(targetbox1);
            Assert.IsTrue(exText.Contains(value), $"Expected text '{value}' not found in the inner target box. Actual text: '{exText}'");
        }
        public void DragAndDropOtherOuterBox(string value)
        {
            var value1 = dragbox1(value);
            controlHelper.DragAndDrop(value1, targetbox2);
        }
        public void validateTextInOtherOuterBox(string value)
        {
            var exText = controlHelper.GetText(targetbox2);
            Assert.IsTrue(exText.Contains(value), $"Expected text '{value}' not found in the other outer target box. Actual text: '{exText}'");
        }
        public void DragAndDropOtherInnerBox(string value)
        {
            Thread.Sleep(4000);
            var value1 = dragbox1(value);
            controlHelper.ScrollToElement(targetbox3);
            controlHelper.DragAndDrop(value1, targetbox3);
        }
        public void validateTextInOtherInnerBox(string value)
        {
            var exText = controlHelper.GetText(targetbox3);
            Assert.IsTrue(exText.Contains(value), $"Expected text '{value}' not found in the other inner target box. Actual text: '{exText}'");
        }

        public void dragRevertable(string value)
        {
            initialloc = waitHelpers.WaitForElement(dragbox1(value)).Location.ToString();
            controlHelper.DragAndDrop(dragbox1(value), dropBox_3);
            afterloc = waitHelpers.WaitForElement(dragbox1(value)).Location.ToString();
        }
        public void VerifyRevertableDrag()
        {
            Thread.Sleep(5000); // wait for revert animation
            var element = waitHelpers.WaitForElement(dragbox1("Will Revert"));
            var after = element.Location;

            // Allow a small tolerance
            int tolerance = 5;
            Assert.IsTrue(Math.Abs(after.X - element.Location.X) <= tolerance &&
                          Math.Abs(after.Y - element.Location.Y) <= tolerance,
                          $"Drag and Drop operation failed - element did not revert. Initial: {initialloc}, After: {after}");
        }

        public void validateTextInRevertableBox(string value)
        {
            var exText = controlHelper.GetText(dropBox__3);
            Assert.IsTrue(exText.Contains(value), $"Expected text '{value}' not found in the revertable box. Actual text: '{exText}'");
        }

    }
}
