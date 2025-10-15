using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumDemo.Utilities;
using static SeleniumDemo.Locators.Ilocators;


namespace SeleniumDemo.Pages
{
    public class Resize
    {
        public ControlHelper controlHelper;
        public WaitHelpers waitHelpers;
        public Resize()
        {
            controlHelper = new ControlHelper();
            waitHelpers = new WaitHelpers();
        }
        public void Resizeto(int targetWidth, int targetHeight)
        {
            controlHelper.ScrollToElement(By.Id("resizableBoxWithRestriction"));
            var box = waitHelpers.WaitForElement(By.Id("resizableBoxWithRestriction"));            
            int currentWidth = (int)float.Parse(box.GetCssValue("width").Replace("px", "").Trim());
            int currentHeight = (int)float.Parse(box.GetCssValue("height").Replace("px", "").Trim());

            int xOffset = targetWidth - currentWidth;
            int yOffset = targetHeight - currentHeight;

            // Apply resize
            controlHelper.ResizeElement(resize_handle, xOffset, yOffset);
        }
        public void VerifySlided(int expectedWidth, int expectedHeight)
        {
            var box = waitHelpers.WaitForElement(By.Id("resizableBoxWithRestriction"));

            int actualWidth = (int)float.Parse(box.GetCssValue("width").Replace("px", "").Trim());
            int actualHeight = (int)float.Parse(box.GetCssValue("height").Replace("px", "").Trim());

            Console.WriteLine($"Box resized to: {actualWidth} x {actualHeight}");

            Assert.AreEqual(expectedWidth, actualWidth, $"Expected width {expectedWidth}px but got {actualWidth}px");
            Assert.AreEqual(expectedHeight, actualHeight, $"Expected height {expectedHeight}px but got {actualHeight}px");
        }

        public void ResizeOtherelement(int targetWidth, int targetHeight)
        {
            controlHelper.ScrollToElement(By.Id("resizable"));
            var box = waitHelpers.WaitForElement(By.Id("resizable"));
            int currentWidth = (int)float.Parse(box.GetCssValue("width").Replace("px", "").Trim());
            int currentHeight = (int)float.Parse(box.GetCssValue("height").Replace("px", "").Trim());

            int xOffset = targetWidth - currentWidth;
            int yOffset = targetHeight - currentHeight;

            controlHelper.ResizeElement(resize_handle1, xOffset, yOffset);
        }
        public void VerifySlidedOther(int expectedWidth, int expectedHeight)
        {
            var box = waitHelpers.WaitForElement(By.Id("resizable"));
            int actualWidth = (int)float.Parse(box.GetCssValue("width").Replace("px", "").Trim());
            int actualHeight = (int)float.Parse(box.GetCssValue("height").Replace("px", "").Trim());
            Console.WriteLine($"Box resized to: {actualWidth} x {actualHeight}");
            Assert.AreEqual(expectedWidth, actualWidth, $"Expected width {expectedWidth}px but got {actualWidth}px");
            Assert.AreEqual(expectedHeight, actualHeight, $"Expected height {expectedHeight}px but got {actualHeight}px");
        }
    }
}
