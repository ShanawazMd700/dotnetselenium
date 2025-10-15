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
    public class LoginUser
    {
        public ControlHelper controlHelper;
        public WaitHelpers waitHelpers;
        public LoginUser()
        {
            controlHelper = new ControlHelper();
            waitHelpers = new WaitHelpers();
        }
        public void VerifyUserName(string userName)
        {
           var actualUsername= controlHelper.GetText(user_header(userName));
            Assert.AreEqual(userName, actualUsername, $"Expected username '{userName}' does not match actual username '{actualUsername}'");
        }
    }
}
