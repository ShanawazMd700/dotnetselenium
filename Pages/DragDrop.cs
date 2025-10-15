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
    public class DragDrop
    {
        public ControlHelper controlHelper;
        public WaitHelpers waitHelpers;
        private string initialloc;
        private string afterloc;
        public DragDrop()
        {
            controlHelper = new ControlHelper();
            waitHelpers = new WaitHelpers();
        }

        public void dragdrop(string dragBox,string dropbox)
        {
            var source = waitHelpers.WaitForElement(simpledrag_box1(dragBox));
            initialloc = source.Location.ToString();
            var destination = waitHelpers.WaitForElement(dropbox_1(dropbox));
            var driver = drivers.Driver;
            Actions actions = new Actions(driver);
            actions.DragAndDrop(source, destination).Build().Perform();
            afterloc = source.Location.ToString();
        }

        public void validate_dragdrop()
        {
            Assert.AreNotEqual(initialloc, afterloc, "Drag and Drop operation failed - element position did not change.");
        }
    }
}
