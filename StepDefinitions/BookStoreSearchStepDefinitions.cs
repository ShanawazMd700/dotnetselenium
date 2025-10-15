using System;
using Reqnroll;
using SeleniumDemo.Pages;

namespace SeleniumDemo.StepDefinitions
{
    [Binding]
    public class BookStoreSearchStepDefinitions
    {
        public static BookSearch bookSearch = new BookSearch();
        [When("We search for the title {string}")]
        public void WhenWeSearchForTheTitle(string p0)
        {
            bookSearch.SearchForBook(p0);
        }

        [Then("The title {string} should be seen")]
        public void ThenTheTitleShouldBeSeen(string p0)
        {
            bookSearch.IsBookTitleVisible(p0);
        }
    }
}
