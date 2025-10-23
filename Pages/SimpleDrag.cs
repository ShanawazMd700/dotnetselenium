using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
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
            var source = waitHelpers.WaitForElement(simpledrag_box1(dragBox));
            var destination = waitHelpers.WaitForElement(dropbox);
            var driver = drivers.Driver;

            var initial = source.Location;

            Actions actions = new Actions(driver);
            actions.ClickAndHold(source)
                   .MoveByOffset(150, 100) // offset sufficient for DemoQA layout
                   .Pause(TimeSpan.FromMilliseconds(300))
                   .Release()
                   .Perform();

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
