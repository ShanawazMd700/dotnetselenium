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
    public class SimpleDrag
    {
        public ControlHelper controlHelper;
        public WaitHelpers waitHelpers;
        private string initialloc;
        private string afterloc;

        public SimpleDrag()
        {
            controlHelper = new ControlHelper();
            waitHelpers = new WaitHelpers();
        }

        public void simpledrag(string dragBox)
        {
            var driver = drivers.Driver;
            var source = waitHelpers.WaitForElement(simpledrag_box1(dragBox));

            // Scroll element into view
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", source);
            Thread.Sleep(500);

            // Store initial location
            initialloc = $"{source.Location.X},{source.Location.Y}";

            try
            {
                Actions actions = new Actions(driver);
                actions.ClickAndHold(source)
                       .MoveByOffset(50, 30) // safe offset
                       .Pause(TimeSpan.FromMilliseconds(300))
                       .Release()
                       .Perform();
            }
            catch (MoveTargetOutOfBoundsException)
            {
                Console.WriteLine("⚠️ Drag offset too large, retrying with smaller movement...");
                Actions actions = new Actions(driver);
                actions.ClickAndHold(source)
                       .MoveByOffset(20, 20)
                       .Release()
                       .Perform();
            }

            Thread.Sleep(1000);

            // Re-fetch element after drag
            var moved = waitHelpers.WaitForElement(simpledrag_box1(dragBox));
            afterloc = $"{moved.Location.X},{moved.Location.Y}";
        }



        public void validate_drag()
        {
            Assert.IsNotNull(afterloc, "❌ Drag operation failed - element location is null");
            Assert.AreNotEqual(initialloc, afterloc, $"❌ Drag operation failed - element did not move. Before: {initialloc}, After: {afterloc}");

        }

    }
}
