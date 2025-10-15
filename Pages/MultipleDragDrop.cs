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
    public class MultipleDragDrop
    {
        public ControlHelper controlHelper;
        public WaitHelpers waitHelpers;
        private string initialloc;
        private string initialloc1;
        private string afterloc;
        private string afterloc1;
        public MultipleDragDrop()
        {
            controlHelper = new ControlHelper();
            waitHelpers = new WaitHelpers();
        }
        public void selectsideoption(string option)
        {
            controlHelper.ButtonClick(select_dropOptions(option));
        }

        public void first_dragdrop()
        {
            var source = waitHelpers.WaitForElement(acceptable);
            initialloc = source.Location.ToString();
            var destination = waitHelpers.WaitForElement(dropbox_2);
            var driver = drivers.Driver;
            Actions actions = new Actions(driver);
            actions.DragAndDrop(source, destination).Build().Perform();
            afterloc = source.Location.ToString();
        }
        public void second_dragdrop()
        {
            var source1 = waitHelpers.WaitForElement(notacceptable);
            initialloc1 = source1.Location.ToString();
            var destination1 = waitHelpers.WaitForElement(dropbox_2);
            var driver = drivers.Driver;
            Actions actions = new Actions(driver);
            actions.DragAndDrop(source1, destination1).Build().Perform();
            afterloc1 = source1.Location.ToString();
        }
        public void VerifyFristDrag()
        {
            Assert.AreNotEqual(initialloc, afterloc, "Drag and Drop operation failed - element position did not change.");
        }
        public void VerifySecondDrag()
        {
            Assert.AreNotEqual(initialloc1, afterloc1, "Drag and Drop operation failed - element position changed.");
        }
    }
}
