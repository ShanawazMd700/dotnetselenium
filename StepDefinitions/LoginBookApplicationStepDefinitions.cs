using System;
using Reqnroll;
using SeleniumDemo.Pages;

namespace SeleniumDemo.StepDefinitions
{
    [Binding]
    public class LoginBookApplicationStepDefinitions
    {
        public static LoginUser loginUser = new LoginUser();
        [Then("The User Name {string} should be displayed")]
        public void ThenTheUserNameShouldBeDisplayed(string name)
        {
            loginUser.VerifyUserName(name);
        }
    }
}
