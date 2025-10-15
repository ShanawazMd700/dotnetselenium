using System;
using Reqnroll;
using SeleniumDemo.Pages;

namespace SeleniumDemo.StepDefinitions
{
    [Binding]
    public class BrokenLinkInteractionStepDefinitions
    {
        public static Brokenlink1 brokenlink1 = new Brokenlink1();
        [When("We opened the link containing {string}")]
        public void WhenWeOpenedTheLinkContaining(string p0)
        {
            brokenlink1.clickonlink(p0);
        }

        [Then("We should redirect to the main page {string}")]
        public void ThenWeShouldRedirectToTheMainPage(string p0)
        {
            brokenlink1.validatelink(p0);
        }

    }
}
