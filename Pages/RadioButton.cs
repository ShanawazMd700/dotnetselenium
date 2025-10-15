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
    public class RadioButton
    {
        public ControlHelper controlHelper;
        public WaitHelpers waitHelpers;
        public RadioButton()
        {
            controlHelper = new ControlHelper();
            waitHelpers = new WaitHelpers();
        }   
        public void selectRadioButton(string value)
        {
            Thread.Sleep(3000); // Adding a delay to ensure the page is fully loaded before clicking
            //controlHelper.ButtonClick(radiobutton(value));
            controlHelper.Click(radiobutton(value));    
        }

        public void validateRadiobutton(string value)
        {
            var radiobuttonElement = waitHelpers.WaitForElement(radiobuttonvalidationtext(value));
            //Assert.IsTrue(radiobuttonElement.Selected,$"Expected radio button '{value}' to be selected, but it was not.");
            if (radiobuttonElement.Text.Equals(value))
            {
                Console.WriteLine($"Radio button '{value}' is selected.");
            }
            else
            {
                Assert.Fail($"Expected radio button '{value}' to be selected, but it was not.");
            }
        }
    }
}
