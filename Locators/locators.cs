using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumDemo.Locators
{
    public interface Ilocators
    {
        // Locators for the elements on the page
        public static string website = "https://demoqa.com/";
        public static By fullname = By.XPath("//input[@id='userName']");
        public static By email = By.XPath("//input[@id='userEmail']");  
        public static By currentAddress = By.XPath("//textarea[@id='currentAddress']");
        public static By permanentAddress = By.XPath("//textarea[@id='permanentAddress']");
        public static By textsubmitButton = By.XPath("//button[@id='submit']");
        public static By addButtonTables = By.XPath("//button[text()='Add']");
        public static By firstname => By.Id("firstName");
        public static By lastname => By.Id("lastName");
        public static By useremail = By.Id("userEmail");
        public static By age = By.Id("age");
        public static By salary = By.Id("salary");
        public static By department = By.Id("department");
        public static By dob_box = By.Id("dateOfBirthInput");
        public static By submitButton = By.XPath("//button[@id='submit']");
        //links
        public static By links_link1 = By.XPath("//a[@id = 'simpleLink']"); 
        public static By links_link2 = By.XPath("//a[@id = 'dynamicLink']");
        public static By uploadButton = By.XPath("//div[@class='form-file']/input['uploadFile']");
        public static By downloadButton= By.XPath("//a[@id='downloadButton']"); // download button
        public static string uploadFilePath = @"C:\Users\YourUser\Downloads\sampleFile.jpg"; // path to the file to upload
        public static By uploadResponse = By.XPath("//p[@id='uploadedFilePath']"); // upload file input
        public static By linkoptions(string value) => By.XPath($"//a[text()='{value}']");
        public static By link_response = By.XPath("//p[@id='linkResponse']"); // response for the link
        //public static By selectoption(string value) => By.XPath($"//h5[text() = '{value}']");// main webpage option
        public static By selectoption(string value) => By.XPath($"//h5[contains(text(),'{value}')]");// main webpage option
        public static By selectslideroption(string value) => By.XPath($"//li[@class='btn btn-light ']/span[text()='{value}']");// slider option to select textbox.
        public static By checkboxoption = By.XPath("//span[text()='Check Box']"); 
        public static By checkboxToggle(int index) => By.XPath($"(//button[@title='Toggle'])[{index}]"); 
        public static By checkbox(string value) => By.XPath($"//span[text()='{value}']/preceding-sibling::span[contains(@class, 'checkbox')]"); // checkbox element  
        public static By radiobutton(string value) => By.XPath($"//label[text()='{value}']"); // checkbox element
        public static By radiobuttonvalidationtext(string value) => By.XPath($"//p[@class='mt-3']/span[text()='{value}']"); 
        public static By textvalidation(string value) => By.XPath($"//div[@class='rt-tr-group']/descendant::div[@class = 'rt-td' and text() = '{value}']"); // text validation element
        public static By button(string value) => By.XPath($"//button[text()='{value}']"); 
        public static By buttonActiontext(string value) => By.XPath($"//p[text()='{value}']"); // button action text element
        public static By Links1(string value) => By.XPath($"//a[text()='{value}']"); 
        public static By dynamicbuttons(string value) => By.XPath($"//button[text()='{value}']"); // dynamic button element
        //forms
        public static By name_registration(string value) => By.XPath($"//div[@class ='col-md-4 col-sm-6']/input[@placeholder='{value}']"); // registration name input
        public static By email_registration = By.XPath("//input[@id='userEmail']");
        public static By formRadiobutton(string value) => By.XPath($"//label[text() = '{value}']"); // form radio button
        public static By datePick(string value1,string value2) => By.XPath($"//div[contains(@aria-label,'{value1}') and text() = '{value2}']");
        public static By monthPick(string value) => By.XPath($"//select[@class = 'react-datepicker__month-select']/option[contains(text(),'{value}')]"); // month picker
        public static By yearbase= By.XPath("//select[@class='react-datepicker__year-select']"); // year base
        public static By monthbase = By.XPath("//select[@class='react-datepicker__month-select']"); // month base
        public static By mobilenumber = By.XPath("//input[@id='userNumber']"); // mobile number input
        public static By subjectsInput = By.XPath("//input[@id='subjectsInput']"); // mobile number input
        public static By state_input = By.Id("react-select-3-input");
        public static By city_input = By.Id("react-select-4-input");
        public  static By newtabHeader(string value)=> By.XPath($"//h1[text()='{value}']"); // new tab header
        public static By header_text(string value) => By.XPath($"//div[text()='{value}']");
        public static By body_text(string value) => By.XPath($"//body[contains(text(),'{value}')]"); // body text
        public static By alert_button(string value) => By.XPath($"(//button[text()='Click me'])[{value}]"); // alert button
        public static By alert_buttons(string value) => By.XPath($"//span[contains(text(),'{value}')]/ancestor::div[@class='mt-4 row']//button[text()='Click me']"); // alert text
        //registration
        public static By registration_name(string value) => By.XPath($"//div[@class ='col-md-9 col-sm-12']/input[@placeholder='{value}']"); // registration name input
        public static By user_header(string value) => By.XPath($"//label[contains(text(),'{value}')]"); // registration email input
        public static By bookstore_searchbox = By.XPath("//input[@id='searchBox']"); // registration email input
        public static By books_title(string value) => By.XPath($"//div[@class='action-buttons']//a[contains(translate(text(),'ABCDEFGHIJKLMNOPQRSTUVWXYZ','abcdefghijklmnopqrstuvwxyz'),'{value}')]"); // book title
        public static By simpledrag_box1(string value) => By.XPath($"//div[text()='{value}']"); // box1 for simple drag
        public static By dropbox = By.XPath("//div[@style='border: 1px solid rgb(229, 229, 229); margin-top: 50px; padding: 50px;']"); // drop box for simple drag
        public static By dragbox = By.XPath("//div[@id='draggable']"); // drag box for drag and drop
        public static By dropbox_1(string value) => By.XPath($"//div[@id='droppable']/p[text()='{value}']"); // drag box for drag and drop
        public static By acceptable = By.Id("acceptable"); // acceptable box for multiple drag and drop
        public static By notacceptable = By.XPath("//div[@id='notAcceptable' and normalize-space(text())='Not Acceptable']"); // acceptable box for multiple drag and drop
        public static By dropbox_2 = By.XPath("(//div[@id='droppable']/p[text()='Drop here'])[2]"); // drop box for multiple drag and drop
        public static By select_dropOptions(string value) => By.XPath($"//nav[@class='nav nav-tabs']/a[text()='{value}']"); // frames link
        public static By dragbox1(string value) => By.XPath($"//div[text()='{value}']"); // drag box for drag and drop
        public static By targetbox = By.XPath(" //div[@id='notGreedyDropBox']/p"); // drag box for drag and drop
        public static By targetbox1 = By.XPath(" //div[@id='notGreedyInnerDropBox']/p"); // drag box for drag and drop
        public static By targetbox2 = By.XPath("//div[@id='greedyDropBox']/p"); // drag box for drag and drop
        public static By targetbox3 = By.XPath("//div[@id='greedyDropBoxInner']/p"); // drag box for drag and drop
        public static By dropBox_3 = By.XPath("(//div[@id='droppable']/p[text()='Drop here'])[3]"); // drop box 
        public static By dropBox__3 = By.XPath("(//div[@id='droppable']/p)[3]"); // drop box 
        public static By anchor = By.Id("resizableBoxWithRestriction"); // drop box 
        public static By resize_handle = By.CssSelector("#resizableBoxWithRestriction .react-resizable-handle-se"); // resize anchor
        public static By resize_handle1 = By.CssSelector("#resizable .react-resizable-handle-se"); // resize anchor

        public static By select(string value) => By.XPath($"//li[normalize-space(text())='{value}']");
        public static By sortable_list(string value) => By.XPath($"//div[@class='vertical-list-container mt-4']/div[text()='{value}']");//div[@class='vertical-list-container mt-4']/div[text()='One']
        public static By sortable_list1(string value) => By.XPath($"//div[@class='create-grid']/div[text()='{value}']");//div[@class='vertical-list-container mt-4']/div[text()='One']
        public static By firstDropdown = By.XPath("(//div[contains(@class,'css-1hwfws3')])[1]"); 
        public static By secondDropdown = By.XPath("(//div[contains(@class,'css-1hwfws3')])[2]"); 
        public static By thirdropdown = By.XPath("(//div[@class=' css-1hwfws3'])[3]"); 
        public static By standardDropdown = By.Id("oldSelectMenu");
        //  public static By dropdownSelectOption(string value) => By.XPath($"(//div[contains(@class,'css-1uccc91-singleValue') and text()='{value}'])[1]");

    }
}
// This code defines an interface `locators` that contains static properties representing locators for various web elements.