using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Text;
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

        public void dragdrop(string sourceText, string targetText)
        {
            var driver = drivers.Driver;
            var source = waitHelpers.WaitForElement(By.XPath($"//*[text()='{sourceText}']"));
            var target = waitHelpers.WaitForElement(By.XPath($"//*[text()='{targetText}']"));

            ((IJavaScriptExecutor)driver).ExecuteScript(@"
        function simulateDragDrop(sourceNode, destinationNode) {
            const dataTransfer = new DataTransfer();
            sourceNode.dispatchEvent(new DragEvent('dragstart', { dataTransfer }));
            destinationNode.dispatchEvent(new DragEvent('drop', { dataTransfer }));
            sourceNode.dispatchEvent(new DragEvent('dragend', { dataTransfer }));
        }
        simulateDragDrop(arguments[0], arguments[1]);
    ", source, target);

            Thread.Sleep(1000);

            var dropText = target.Text;
            Assert.IsTrue(dropText.Contains("Dropped"), $"❌ Drag and Drop failed - text is '{dropText}'");
        }

        public void validate_dragdrop()
        {
            Assert.AreNotEqual(initialloc, afterloc, "Drag and Drop operation failed - element position did not change.");
        }
    }
}
