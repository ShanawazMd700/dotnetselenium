using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SeleniumDemo.Utilities
{
    public class ControlHelper
    {
        private readonly WaitHelpers waitHelpers;

        public ControlHelper()
        {
            waitHelpers = new WaitHelpers();
        }

        public void ButtonClick(By Locator)
        {
            waitHelpers.WaitForElement(Locator).Click();
        }
        public void DoubleClick(By locator)
        {
            var driver = drivers.Driver;
            var element = waitHelpers.WaitForElement(locator);

            int attempts = 2;
            while (attempts > 0)
            {
                try
                {
                    new Actions(driver).DoubleClick(element).Perform();
                    return;
                }
                catch (ElementClickInterceptedException)
                {
                    HandleDoubleClickFallback(driver, element);
                }
                catch (ElementNotInteractableException)
                {
                    HandleDoubleClickFallback(driver, element);
                }

                Waitfor(1);
                attempts--;
            }

            throw new Exception($"❌ Failed to double-click element: {locator}");
        }

        private void HandleDoubleClickFallback(IWebDriver driver, IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript(
                "var evt = new MouseEvent('dblclick', {bubbles:true,cancelable:true}); arguments[0].dispatchEvent(evt);",
                element
            );
        }

        /** ✅ Robust right-click with JS fallback */
        public void RightClick(By locator)
        {
            var driver = drivers.Driver;
            var element = waitHelpers.WaitForElement(locator);

            int attempts = 2;
            while (attempts > 0)
            {
                try
                {
                    new Actions(driver).ContextClick(element).Perform();
                    return;
                }
                catch (ElementClickInterceptedException)
                {
                    HandleRightClickFallback(driver, element);
                }
                catch (ElementNotInteractableException)
                {
                    HandleRightClickFallback(driver, element);
                }

                Waitfor(1);
                attempts--;
            }

            throw new Exception($"❌ Failed to right-click element: {locator}");
        }

        private void HandleRightClickFallback(IWebDriver driver, IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript(
                "var evt = new MouseEvent('contextmenu', {bubbles:true,cancelable:true}); arguments[0].dispatchEvent(evt);",
                element
            );
        }

        public void EnterText(By Locator, string text)
        {
            var element = waitHelpers.WaitForElement(Locator);
            element.Clear();
            element.SendKeys(text);
        }
        public void NavigateToUrl(string url)
        {
            drivers.Driver.Navigate().GoToUrl(url);
        }
        public string GetText(By Locator)
        {
            var element = waitHelpers.WaitForElement(Locator);
            return element.Text;
        }
        public void validateText(By Locator, string expectedText)
        {
            var element = waitHelpers.WaitForElement(Locator);
            string actualText;
            string tagName = element.TagName.ToLower();
            if (tagName == "input" || tagName == "textarea")
            {
                actualText = element.GetAttribute("value");
            }
            else
            {
                actualText = element.Text;
            }

            Assert.IsTrue(actualText.Contains(expectedText),
                $"Expected text '{expectedText}' not found in actual text '{actualText}'");
        }
        public void Click(By Locator)
        {
            var driver = drivers.Driver;
            var element = waitHelpers.WaitForElement(Locator);
            ((IJavaScriptExecutor)driver).ExecuteScript(
                "arguments[0].scrollIntoView(true); window.scrollBy(0, -100);", element
            );
            element.Click();
        }
        public void ScrollToElement(By Locator)
        {
            var driver = drivers.Driver;
            var element = waitHelpers.WaitForElement(Locator);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
        public void Waitfor(int time)
        {
            Thread.Sleep(time * 1000);
        }
        public void DragAndDrop(By sourceLocator, By targetLocator)
        {
            var driver = drivers.Driver;
            var sourceElement = waitHelpers.WaitForElement(sourceLocator);
            var targetElement = waitHelpers.WaitForElement(targetLocator);
            var actions = new OpenQA.Selenium.Interactions.Actions(driver);
            actions.DragAndDrop(sourceElement, targetElement).Perform();
        }
        public void ResizeElement(By handleLocator, int xOffset, int yOffset)
        {
            var driver = drivers.Driver;
            var handle = waitHelpers.WaitForElement(handleLocator);

            Actions actions = new Actions(driver);
            actions.ClickAndHold(handle)
                   .MoveByOffset(xOffset, yOffset)
                   .Release()
                   .Perform();
        }
        public string GetText(IWebElement element)
        {
            return element.Text;
        }
        public static void RemoveAds(IWebDriver driver)
        {
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript(@"
            const adSelectors = [
                'iframe[id*=""ad""]',
                'div[id*=""ad""]',
                'div[class*=""ad""]',
                'div[class*=""popup""]',
                'div[id*=""popup""]',
                'div[class*=""banner""]',
                'div[id*=""banner""]'
            ];
            adSelectors.forEach(sel => {
                document.querySelectorAll(sel).forEach(e => e.remove());
            });
        ");
            }
            catch { }
        }


    }
}
