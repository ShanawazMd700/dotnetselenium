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

            // Scroll element into view just in case
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", source);
            Thread.Sleep(500);

            var initial = source.Location;

            Actions actions = new Actions(driver);
            try
            {
                actions.ClickAndHold(source)
                       .MoveByOffset(80, 40)  // ✅ smaller offset within visible bounds
                       .Pause(TimeSpan.FromMilliseconds(300))
                       .Release()
                       .Perform();
            }
            catch (MoveTargetOutOfBoundsException)
            {
                Console.WriteLine("⚠️ Drag offset too large, retrying with smaller movement...");
                actions.ClickAndHold(source)
                       .MoveByOffset(30, 30)
                       .Release()
                       .Perform();
            }

            Thread.Sleep(1000);

            var after = source.Location;
            Assert.AreNotEqual(initial, after, "Drag operation failed - element position did not change.");
        }



        public void validate_drag()
        {
            Assert.AreNotEqual(initialloc, afterloc, "Drag operation failed - element position did not change.");
        }

    }
}
