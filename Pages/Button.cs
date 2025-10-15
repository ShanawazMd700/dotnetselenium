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
    public class Button
    {
        public ControlHelper controlHelper;
        public WaitHelpers waitHelpers;
        public Button()
        {
            controlHelper = new ControlHelper();
            waitHelpers = new WaitHelpers();
        }
        public void ClickOnButton(string value)
        {
            controlHelper.ButtonClick(button(value));
        }
        public void DoubleClickOnButton(string value)
        {
            controlHelper.DoubleClick(button(value));
        }
        public void RightClickOnButton(string value)
        {
            controlHelper.RightClick(button(value));
        }
        public void ValidateButtonActionMessage(string expectedMessage)
        {
            var messageElement = waitHelpers.WaitForElement(buttonActiontext(expectedMessage));
            Assert.That(messageElement.Text, Is.EqualTo(expectedMessage),
                $"Expected message '{expectedMessage}' but found '{messageElement.Text}'");
        }

    }
}
