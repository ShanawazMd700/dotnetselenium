using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumDemo.Utilities;
using static SeleniumDemo.Locators.Ilocators;

namespace SeleniumDemo.Pages
{
    public class DynamicInteraction
    {
        public ControlHelper controlHelper;
        public WaitHelpers waitHelpers;
        public DynamicInteraction()
        {
            controlHelper = new ControlHelper();
            waitHelpers = new WaitHelpers();
        }
        public void clickDynamicButton(string button)
        {
            controlHelper.ButtonClick(dynamicbuttons(button));
        }

        public void wait(int time)
        {
            controlHelper.Waitfor(time);
        }

        public void validatethebuttoncolor(string button, string expectedColor)
        {
            var buttonElement = waitHelpers.WaitForElement(dynamicbuttons(button));

            // get CSS 'color' property (text color)
            string actualColor = buttonElement.GetCssValue("color");

            string normalizedExpected;

            // if user passed a hex (e.g. "#dc3545") or a named color ("red")
            if (expectedColor.StartsWith("#") || !expectedColor.StartsWith("rgba"))
            {
                Color color = ColorTranslator.FromHtml(expectedColor);
                normalizedExpected = $"rgba({color.R}, {color.G}, {color.B}, 1)";
            }
            else
            {
                // already rgba
                normalizedExpected = expectedColor;
            }

            Assert.AreEqual(normalizedExpected, actualColor,
                $"Expected button color {normalizedExpected} but got {actualColor}");
        }
    }
}
