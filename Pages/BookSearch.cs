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
    public class BookSearch
    {
        public ControlHelper controlHelper;
        public WaitHelpers waitHelpers;
        public BookSearch()
        {
            controlHelper = new ControlHelper();
            waitHelpers = new WaitHelpers();
        }

        public void SearchForBook(string bookTitle)
        {
            controlHelper.EnterText(bookstore_searchbox, bookTitle);
        }
        public void IsBookTitleVisible(string bookTitle)
        {
            var bookElement = controlHelper.GetText(books_title(bookTitle));

            Assert.IsTrue(
                bookElement.Contains(bookTitle, StringComparison.OrdinalIgnoreCase),
                $"Expected book title '{bookTitle}' not found in the search results. Actual: '{bookElement}'"
            );

        }
    }
}
