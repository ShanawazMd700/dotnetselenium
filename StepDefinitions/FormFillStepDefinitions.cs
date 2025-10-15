using System;
using Reqnroll;
using SeleniumDemo.Pages;

namespace SeleniumDemo.StepDefinitions
{
    [Binding]
    public class FormFillStepDefinitions
    {
        public static Formfill formfill = new Formfill();
        [When("We enter the user's {string} as {string}")]
        public void WhenWeEnterTheUsersAs(string firstname, string name)
        {
            formfill.EnterFullName(firstname, name);
        }
        [When("we enter the user's email as {string}")]
        public void WhenWeEnterTheUsersEmailAs(string p0)
        {
            formfill.EnterEmail(p0);
        }

        [When("We select gender as {string}")]
        public void WhenWeSelectGenderAs(string male)
        {
            formfill.SelectGender(male);
        }

        [When("We enter the users mobile number as {string}")]
        public void WhenWeEnterTheUsersMobileNumberAs(string p0)
        {
            formfill.enterMobile(p0);   
        }

        [When("We select the subject as {string}")]
        public void WhenWeSelectTheSubjectAs(string sublect)
        {
            formfill.enterSubjects(sublect);
        }

        [When("We select the radiobutton {string}")]
        public void WhenWeSelectTheRadiobutton(string activity)
        {
            formfill.SelectGender(activity);
        }
        [When("we select the state {string}")]
        public void WhenWeSelectTheState(string area)
        {
            formfill.selectstate(area);
        }

        [When("We select the city {string}")]
        public void WhenWeSelectTheCity(string city)
        {
            formfill.selectcity(city);
        }

        [When("We select the year {string} and month {string} and the day {string}")]
        public void WhenWeSelectTheYearAndMonthAndTheDay(string year, string month, string day)
        {
            formfill.SelectYear(year);
            formfill.SelectMonth(month);
            formfill.selectdate(day);
        }

        [Then("We the text {string} should be displayed")]
        public void ThenWeTheTextShouldBeDisplayed(string text)
        {
            formfill.verifythetext(text);
        }


    }
}
