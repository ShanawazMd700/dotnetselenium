using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumDemo.Utilities;
using static SeleniumDemo.Locators.Ilocators;

namespace SeleniumDemo.Pages
{
    public class Sort
    {
        public ControlHelper controlHelper;
        public WaitHelpers waitHelpers; 
        public Sort()
        {
            controlHelper = new ControlHelper();
            waitHelpers = new WaitHelpers();
        }
        public void performsort(string source, string destination)
        {
            waitHelpers.WaitForElement(sortable_list(source));
            waitHelpers.WaitForElement(sortable_list(destination));
           controlHelper.DragAndDrop(sortable_list(source), sortable_list(destination));
        }

        public void performothersort(string source, string destination)
        {
            waitHelpers.WaitForElement(sortable_list1(source));
            waitHelpers.WaitForElement(sortable_list1(destination));
            controlHelper.DragAndDrop(sortable_list1(source), sortable_list1(destination));
        }
    }
}
