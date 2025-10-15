using System;
using Reqnroll;
using SeleniumDemo.Pages;

namespace SeleniumDemo.StepDefinitions
{
    [Binding]
    public class LinksInteractionStepDefinitions
    {
        public static Link link = new Link();
        [When("We click on the link with the text Home")]
        public void WhenWeClickOnTheLinkWithTheTextHome()
        {
            link.clickhome();
        }

        [Then("We should be redirected to the page {string}")]
        public void ThenWeShouldBeRedirectedToThePage(string p0)
        {
            link.validateclickhome1();
        }

        [When("We click on the link with the text {string}")]
        public void WhenWeClickOnTheLinkWithTheText(string value)
        {
            link.selectlinkoptions(value);
        }

        [Then("The text {string} is shown")]
        public void ThenTheTextIsShown(string p0)
        {
            
        }
    }
}
