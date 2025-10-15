using System;
using Reqnroll;
using SeleniumDemo.Pages;

namespace SeleniumDemo.StepDefinitions
{
    [Binding]
    public class CreateUserBookApplicationStepDefinitions
    {
        public static RegisterUser registerUser = new RegisterUser();
        [When("We enter the {string} as {string}")]
        public void WhenWeEnterTheAs(string nametype, string name)
        {
            registerUser.EnterName(nametype, name);
        }
    }
}
