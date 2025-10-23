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

            // Scroll both elements into view
            ((IJavaScriptExecutor)driver).ExecuteScript(
                "arguments[0].scrollIntoView(true); arguments[1].scrollIntoView(true);", source, target);
            Thread.Sleep(500);

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
            Thread.Sleep(1000);

            // Store for separate assertion
            afterloc = target.Text.Trim();
        }

        public void validate_dragdrop()
        {
            Assert.IsTrue(afterloc.Contains("Dropped"), $"❌ Drag and Drop failed - text is '{afterloc}'");
        }
    }
}
