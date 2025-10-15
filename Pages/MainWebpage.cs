using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumDemo.Utilities;
using static SeleniumDemo.Locators.Ilocators;

namespace SeleniumDemo.Pages
{
    public class MainWebpage
    {
        public ControlHelper controlHelper;
        public MainWebpage()
        {
            controlHelper = new ControlHelper();
        }
        public void  NavigateToMainWebpage(string value)
        {
            controlHelper.NavigateToUrl(value);
        }
        public void ClickOnElement(string value)
        {
            //controlHelper.ButtonClick(selectoption(value));
            controlHelper.Click(selectoption(value));
        }
        public void ClickOnOption(string value)
        {
            controlHelper.ScrollToElement(selectslideroption(value));
            controlHelper.ButtonClick(selectslideroption(value));
        }
        public void ClickOnCheckboxOption()
        {
            controlHelper.Click(checkboxoption);
        }
    }
}
