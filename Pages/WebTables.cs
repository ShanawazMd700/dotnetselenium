using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumDemo.Utilities;
using static SeleniumDemo.Locators.Ilocators;

namespace SeleniumDemo.Pages
{
    public class WebTables
    {
        public ControlHelper controlHelper;
        public WaitHelpers waitHelpers;
        public WebTables()
        {
            controlHelper = new ControlHelper();
            waitHelpers = new WaitHelpers();
        }
        public void clickAddButton()
        {
            controlHelper.ButtonClick(addButtonTables);
        }
        public void fillFirstName(string firstName)
        {
            controlHelper.EnterText(firstname, firstName);
        }
        public void fillLastName(string lastName)
        {
            controlHelper.EnterText(lastname, lastName);
        }   
        public void fillEmail(string email1)
        {
            controlHelper.EnterText(email, email1);
        }
        public void fillAge(string age1)
        {
            controlHelper.EnterText(age, age1);
        }
        public void fillSalary(string salary1)
        {
            controlHelper.EnterText(salary, salary1);
        }
        public void fillDepartment(string department1)
        {
            controlHelper.EnterText(department, department1);
        }
        public void clickSubmitButton()
        {
            controlHelper.ButtonClick(submitButton);
        } 
        public void validatethefirstname(string expectedName)
        {
             var exname = waitHelpers.WaitForElement(textvalidation(expectedName));
                if (exname.Text.Equals(expectedName))
                {
                    Console.WriteLine($"First name '{expectedName}' is present in the table.");
                }
                else
                {
                    throw new Exception($"Expected first name '{expectedName}' not found in the table.");            
                }
        }

    }
}
