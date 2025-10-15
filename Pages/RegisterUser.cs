using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumDemo.Utilities;
using static SeleniumDemo.Locators.Ilocators;

namespace SeleniumDemo.Pages
{
    public class RegisterUser
    {
        public ControlHelper controlHelper;
        public WaitHelpers waitHelpers;
        public RegisterUser()
        {
            controlHelper = new ControlHelper();
            waitHelpers = new WaitHelpers();
        }
        public void EnterName(string nametype,string name)
        {
            controlHelper.EnterText(registration_name(nametype), name);
        }

    }
}
