using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumDemo.Utilities;
using static SeleniumDemo.Locators.Ilocators;

namespace SeleniumDemo.Pages
{
    public class CheckBox
    {
        public ControlHelper controlHelper;
        public WaitHelpers waitHelpers;
        public CheckBox()
        {
            controlHelper = new ControlHelper();
            waitHelpers = new WaitHelpers();
        }
        public void selectcheckbox(string value)
        {
            controlHelper.Click(checkbox(value));
        }
        public void selectToggleButton(int value)
        {
            controlHelper.ButtonClick(checkboxToggle(value));
        }
        public bool isCheckboxSelected(string value)
        {
            
            var checkboxElement = waitHelpers.WaitForElement(checkbox(value));
            bool check = checkboxElement.GetAttribute("class").Contains("check");
            
            if (check)
            {
                return true;
            }
            return false;
        }
    }
}
