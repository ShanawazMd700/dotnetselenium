using System;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;
using SeleniumDemo.Pages;
using SeleniumDemo.Utilities;

namespace SeleniumDemo.StepDefinitions
{
    [Binding]
    public class CheckboxInteractionStepDefinitions
    {
        public static MainWebpage mainWebpage = new MainWebpage();
        public static CheckBox checkBox = new CheckBox();   

        [When("We click on the element with text {string}")]
        public void WhenWeClickOnTheElementWithText(string p0)
        {
           mainWebpage.ClickOnCheckboxOption();
        }
        [When("we click the togglebutton {string}")]
        public void WhenWeClickTheTogglebutton(string p0)
        {
            checkBox.selectToggleButton(1);
            Thread.Sleep(6000);
        }


        [When("We click on the element with  text {string}")]
        public void WhenWeClickOnTheElementWithText1(string home)
        {
            checkBox.selectcheckbox(home);
            Thread.Sleep(6000); 
        }


        [Then("The checkbox with the text {string} should be checked")]
        public void ThenTheCheckboxWithTheTextShouldBeChecked(string home)
        {
           var ele =  checkBox.isCheckboxSelected(home);
            Assert.IsTrue(ele, "checkbox is not selected...");
        }

    }
}
