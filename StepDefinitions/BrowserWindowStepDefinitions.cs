using System;
using Reqnroll;
using SeleniumDemo.Pages;

namespace SeleniumDemo.StepDefinitions
{
    [Binding]
    public class BrowserWindowStepDefinitions
    {
        public static BrowserWindows browserWindows = new BrowserWindows();
        [Then("The title of the page should be {string}")]
        public void ThenTheTitleOfThePageShouldBe(string p0)
        {
            browserWindows.ValidateNewTab(p0);
        }
        [Then("The body of the page should be {string}")]
        public void ThenTheBodyOfThePageShouldBe(string p0)
        {
            browserWindows.ValidateNewTab1(p0);
        }

    }
}
