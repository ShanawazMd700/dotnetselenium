using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumDemo.Locators;
using SeleniumDemo.Utilities;
using static SeleniumDemo.Locators.Ilocators;

namespace SeleniumDemo.Pages
{
    public class SubmitDetails
    {
        public ControlHelper controlHelper;
        public string Fullname;
        public string Email;
        public string CurrentAddress;
        public string PermanentAddress;
        public SubmitDetails()
        {
            controlHelper = new ControlHelper();
        }
        public void EnterFullName(string fullName1)
        {
            controlHelper.EnterText(fullname, fullName1);
            Fullname = fullName1;
        }
        public void EnterEmail(string emailID)
        {
            controlHelper.EnterText(email, emailID);
            Email = emailID;
        }
        public void EnterCurrentAddress(string currentAddress1)
        {
            controlHelper.EnterText(currentAddress, currentAddress1);
            CurrentAddress = currentAddress1;
        }
        public void EnterPermanentAddress(string permanentAddress1)
        {
            controlHelper.EnterText(permanentAddress, permanentAddress1);
            PermanentAddress = permanentAddress1;
        }
        public void validateTheTexts()
        {
            controlHelper.ScrollToElement(email);
            controlHelper.Click(textsubmitButton);
            controlHelper.validateText(fullname, Fullname);
            controlHelper.validateText(email, Email);
            controlHelper.validateText(currentAddress, CurrentAddress); 
            controlHelper.validateText(permanentAddress, PermanentAddress);

        }
    }
}
