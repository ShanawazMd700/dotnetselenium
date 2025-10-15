using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SeleniumDemo.Locators;
using SeleniumDemo.Utilities;
using static SeleniumDemo.Locators.Ilocators;


namespace SeleniumDemo.Pages
{
    public class Select
    {
        public ControlHelper controlHelper;
        public WaitHelpers waitHelpers;
        private string afterbgColor;
        private string beforebgColor;
        private string ActualText;
        public Select()
        {
            controlHelper = new ControlHelper();
            waitHelpers = new WaitHelpers();
        }
        public void selectoption(string option)
        {
            var firstItem = waitHelpers.WaitForElement(select(option));
            beforebgColor = firstItem.GetCssValue("background-color");

            // Click
            controlHelper.ButtonClick(select(option));

            // Re-locate element after click
            var clickedItem = waitHelpers.WaitForElement(select(option));
            afterbgColor = clickedItem.GetCssValue("background-color");
            ActualText = controlHelper.GetText(select(option));
        }
        public void verifyselected(string expectedText)
        {
            Assert.Multiple(() =>
            {
                Assert.AreNotEqual(beforebgColor, afterbgColor,
                    "Background color did not change after click");

                Assert.AreEqual(expectedText, ActualText,
                    "The selected option text does not match the expected text.");
            });
        }
    }
}
