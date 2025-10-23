using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
        private string value1;
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
            var source = waitHelpers.WaitForElement(dragbox1(value));
            var target = waitHelpers.WaitForElement(targetbox1);
            controlHelper.ScrollToElement(target);

            var driver = drivers.Driver;

            string script = @"
    function simulateDragDrop(sourceNode, destinationNode) {
        const dataTransfer = new DataTransfer();
        const fireEvent = (type, node) => {
            const event = new DragEvent(type, {
                bubbles: true,
                cancelable: true,
                dataTransfer: dataTransfer
            });
            node.dispatchEvent(event);
        };
        fireEvent('dragstart', sourceNode);
        fireEvent('dragenter', destinationNode);
        fireEvent('dragover', destinationNode);
        fireEvent('drop', destinationNode);
        fireEvent('dragend', sourceNode);
    }
    simulateDragDrop(arguments[0], arguments[1]);
    ";

            ((IJavaScriptExecutor)driver).ExecuteScript(script, source, target);
            Thread.Sleep(1000); // wait for text update
        }

        public void validateTextInInnerBox(string expected)
        {
            var innerTarget = waitHelpers.WaitForElement(targetbox1);
            string actualText = innerTarget.Text.Trim();
            Assert.IsTrue(actualText.Contains(expected), $"Expected text '{expected}' not found in the inner target box. Actual text: '{actualText}'");
        }

        public void DragAndDropOtherOuterBox(string value)
        {
            var source = waitHelpers.WaitForElement(dragbox1(value));
            var target = waitHelpers.WaitForElement(targetbox2);
            controlHelper.ScrollToElement(target);

            var driver = drivers.Driver;
            Actions actions = new Actions(driver);
            actions
                .MoveToElement(source)
                .ClickAndHold()
                .MoveToElement(target, 5, 5)
                .Pause(TimeSpan.FromMilliseconds(500))
                .Release()
                .Perform();

        }

        public void validateTextInOtherOuterBox(string value)
        {
            var exText = controlHelper.GetText(targetbox2);
            Assert.IsTrue(exText.Contains(value),
                $"Expected text 'Dropped!' not found in the other outer target box. Actual text: '{exText}'");
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
            value1 = value;
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
            if (value1 == "Will Revert")
            {
                var exText1 = controlHelper.GetText(dropBox__3);
                Assert.IsTrue(exText1.Contains(value), $"Expected text '{value}' not found in the revertable box. Actual text: '{exText1}'");
            }
            else
            {
                var exText = controlHelper.GetText(dropBox__3);
                Assert.IsTrue(exText.Contains(value), $"Expected text '{value}' not found in the revertable box. Actual text: '{exText}'");
            }
        }

    }
}
