using MarsQA_1.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using RazorEngine.Compilation.ImpromptuInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Razor.Generator;

namespace MarsQA_1.SpecflowPages.Pages
{
    public class Profile
        {

        public Profile()
        {
            ExcelLibHelper.PopulateInCollection(@"\MarsQA-1\SpecflowTests\Data\Mars.xlsx", "Data");
        }


        //find tab elements
        public IWebElement TabLanguage => CommonDriver.Driver.FindElement(By.XPath("//a[text()='Languages']"));
        public IWebElement TabSkill => CommonDriver.Driver.FindElement(By.XPath("//a[text()='Skills']"));
        public IWebElement TabEducation => CommonDriver.Driver.FindElement(By.XPath("//a[text()='Education']"));
        public IWebElement TabCertification => CommonDriver.Driver.FindElement(By.XPath("//a[text()='Certifications']"));
        public string PopupMessage;


        //add availability type
        public string AddAvailability(string availabilityType)
        {
            CommonDriver.waitClickableElement("(//i[@class='right floated outline small write icon'])[1]");
            //click on the pen icon to add availability
            CommonDriver.Driver.FindElement(By.XPath("(//i[@class='right floated outline small write icon'])[1]")).Click();
            if (availabilityType.ToLower() == "part time")
            {
                //Part Time availability
                new SelectElement(CommonDriver.Driver.FindElement(By.XPath("//select[contains(@name,'availabiltyType')]"))).SelectByValue("0");
                Console.WriteLine("avail type added");
            }
            else if (availabilityType.ToLower() == "full time")
            {
                //Full Time availability
                new SelectElement(CommonDriver.Driver.FindElement(By.XPath("//select[contains(@name,'availabiltyType')]"))).SelectByValue("1");
                Console.WriteLine("avail type added");
            }
            return ReadPopup();
        }

        //add availability hour
        public string AddAvailabilityHour(string AvailabilityHour)
        {
            //explicit wait
            CommonDriver.waitClickableElement("(//i[contains(@class,'right floated outline small write icon')])[2]");
            //click on pen icon to add
            CommonDriver.Driver.FindElement(By.XPath("(//i[contains(@class,'right floated outline small write icon')])[2]")).Click();
            
            //check which parameter is passed and select that value from dropdown
            if (AvailabilityHour.ToLower() == "less than 30 hours")
            {
                new SelectElement(CommonDriver.Driver.FindElement(By.XPath("//select[contains(@name,'availabiltyHour')]"))).SelectByValue("0");
            }

            else if (AvailabilityHour.ToLower() == "more than 30 hours")
            {
                new SelectElement(CommonDriver.Driver.FindElement(By.XPath("//select[contains(@name,'availabiltyHour')]"))).SelectByValue("1");
            }
            else if (AvailabilityHour.ToLower() == "as needed")
            {
                new SelectElement(CommonDriver.Driver.FindElement(By.XPath("//select[contains(@name,'availabiltyHour')]"))).SelectByValue("2");
            }

            return ReadPopup();
        }

        //add earn target
        public string AddEarnTarget(string EarnTarget)
        {
            //explicit wait
            CommonDriver.waitClickableElement("(//i[@class='right floated outline small write icon'])[3]");
            //click pen icon to add value
            CommonDriver.Driver.FindElement(By.XPath("(//i[@class='right floated outline small write icon'])[3]")).Click();
            //select dropdown using the parameter passed
            if (EarnTarget.ToLower() == "less than $500")
            {
                new SelectElement(CommonDriver.Driver.FindElement(By.XPath("//select[contains(@name,'availabiltyTarget')]"))).SelectByValue("0");

            }
            else if (EarnTarget.ToLower() == "between $500 and $1000")
            {
                new SelectElement(CommonDriver.Driver.FindElement(By.XPath("//select[contains(@name,'availabiltyTarget')]"))).SelectByValue("1");
            }
            else if (EarnTarget.ToLower() == "more than $1000")
            {
                new SelectElement(CommonDriver.Driver.FindElement(By.XPath("//select[contains(@name,'availabiltyTarget')]"))).SelectByValue("2");
            }
            return ReadPopup();
        }

        //method to add text in the textbox by passing Xpath and value
        public void AddText(string path, string value)
        {
            CommonDriver.Driver.FindElement(By.XPath(path)).SendKeys(value);

        }

        //add language
        public void AddLanguage()
        {
            //CommonDriver.TurnOnWait();
            //click on language tab
            TabLanguage.Click();
            CommonDriver.TurnOnWait();
            //click add new button in language tab
            ClickAddNewButton("TabLanguage");
            //wait until textbox is visible
            CommonDriver.waitElementIsVisible("//input[@placeholder='Add Language']");
            //add language text
            AddText("//input[@placeholder='Add Language']",ExcelLibHelper.ReadData(2,"Language"));
            CommonDriver.TurnOnWait();
            //select basic level in the dropdown
            SelectDropDown("", ExcelLibHelper.ReadData(3, "Language"), "TabLanguage");
            CommonDriver.TurnOnWait();
            //click add button
            ClickAddButton("TabLanguage");
            CommonDriver.TurnOnWait();
            
        }
        //adds skill record
        public void AddSkill()
        {
            CommonDriver.TurnOnWait();
            TabSkill.Click();
            CommonDriver.TurnOnWait();
            //click addnew button on tab skill
            ClickAddNewButton("TabSkill");
            CommonDriver.TurnOnWait();
            //explicit wait
            CommonDriver.waitElementIsVisible("//input[contains(@placeholder,'Add Skill')]");
            //add skill text
            AddText("//input[contains(@placeholder,'Add Skill')]", ExcelLibHelper.ReadData(2, "Skill"));
            CommonDriver.TurnOnWait();
            SelectDropDown("", ExcelLibHelper.ReadData(3, "Skill"), "TabSkill");
            CommonDriver.TurnOnWait();
            ClickAddButton("TabSkill");
            CommonDriver.TurnOnWait();
        }
        //add education record
        public void AddEducation()
        {
            CommonDriver.TurnOnWait();
            TabEducation.Click();
            CommonDriver.TurnOnWait();
            ClickAddNewButton("TabEducation");
            CommonDriver.waitElementIsVisible("//input[@name='instituteName']");
            AddText("//input[@name='instituteName']", ExcelLibHelper.ReadData(2, "Education"));
            AddText("//input[@name='degree']", ExcelLibHelper.ReadData(3, "Education"));
            CommonDriver.TurnOnWait();
            SelectDropDown("country", ExcelLibHelper.ReadData(4, "Education"), "TabEducation");
            CommonDriver.TurnOnWait();
            SelectDropDown("title", ExcelLibHelper.ReadData(5, "Education"), "TabEducation");
            CommonDriver.TurnOnWait();
            SelectDropDown("yearOfGraduation", ExcelLibHelper.ReadData(6, "Education"), "TabEducation");
            CommonDriver.TurnOnWait();
            ClickAddButton("TabEducation");
            CommonDriver.TurnOnWait();
        }
        //add certifications
        public void AddCertification()
        {
            CommonDriver.TurnOnWait();
            TabCertification.Click();
            CommonDriver.TurnOnWait();
            ClickAddNewButton("TabCertification");
            CommonDriver.waitElementIsVisible("//input[@name='certificationName']");
            AddText("//input[@name='certificationName']", ExcelLibHelper.ReadData(2, "Certification"));
            AddText("//input[@name='certificationFrom']", ExcelLibHelper.ReadData(3, "Certification"));
            CommonDriver.TurnOnWait();
            SelectDropDown("certificationYear", ExcelLibHelper.ReadData(4, "Certification"), "TabCertification");
            CommonDriver.TurnOnWait();
            ClickAddButton("TabCertification");
        }

        //click add button of the respective tab by passing the tab name
        public void ClickAddButton(string element)
        {
            CommonDriver.TurnOnWait();
            string langxPath = "";
            if (element.Equals("TabLanguage"))
            {
                //CommonDriver.waitClickableElement("(//input[@value='Add'])[1]");
                langxPath = "//div[2]//div//div//div[3]//input[@type='button'][@value='Add']";
               
            }
                
            else if (element.Equals("TabSkill"))
            {
                //CommonDriver.waitClickableElement("(//input[@value='Add'])[2]");
                //CommonDriver.Driver.FindElement(By.XPath("(//input[@value='Add'])[2]")).Click();
                langxPath = "//span[@class='buttons-wrapper']//input[@type='button'][@value='Add']";
            }
               
            else if (element.Equals("TabEducation"))
            {
                //CommonDriver.waitClickableElement("(//input[@value='Add'])[3]");
                //CommonDriver.Driver.FindElement(By.XPath("(//input[@value='Add'])[3]")).Click();
                langxPath = "//div[2]//div//div[3]//div//input[@type='button'][@value='Add']";
            }
                
            else if (element.Equals("TabCertification"))
            {
                //CommonDriver.waitClickableElement("(//input[@value='Add'])[4]");
                //CommonDriver.Driver.FindElement(By.XPath("(//input[@value='Add'])[4]")).Click();
                langxPath = "//div[@class='ui fluid container']//div//div//div[3]//form//div[5]//div//div[2]/div//div[1]//div[3]//input[@type='button'][@value='Add']";
            }

            CommonDriver.waitClickableElement(langxPath);
            CommonDriver.Driver.FindElement(By.XPath(langxPath)).Click();
        }

        //click add new button of the respective tab by passing the tab name
        public void ClickAddNewButton(string element)
        {
            CommonDriver.TurnOnWait();
            string addNewXPath = "";
            if (element.Equals("TabLanguage"))
            {

                //CommonDriver.waitClickableElement("(//div[contains(.,'Add New')])[11]");
                //CommonDriver.Driver.FindElement(By.XPath("(//div[contains(.,'Add New')])[11]")).Click();

                addNewXPath = "//div[@class='eight wide column']/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/thead/tr/th[3]/div[1]";
            }
                
            else if (element.Equals("TabSkill"))
            {
                //CommonDriver.waitClickableElement("(//div[contains(.,'Add New')])[16]");
                //CommonDriver.Driver.FindElement(By.XPath("(//div[contains(.,'Add New')])[16]")).Click();
                addNewXPath = "//div[@class='ui teal button']";
            }
                
            else if (element.Equals("TabEducation"))
            {
                // CommonDriver.waitClickableElement("(//div[contains(.,'Add New')])[21]");
                //CommonDriver.Driver.FindElement(By.XPath("(//div[contains(.,'Add New')])[21]")).Click();
                addNewXPath = "//div[1]/div[2]/div[1]/table[1]/thead/tr/th[6]/div[1]";
            }
                
            else if (element.Equals("TabCertification"))
            {
                //CommonDriver.waitClickableElement("(//div[contains(.,'Add New')])[26]");
                //CommonDriver.Driver.FindElement(By.XPath("(//div[contains(.,'Add New')])[26]")).Click();
                addNewXPath = "//div[1]/div[2]/div[1]/table[1]/thead/tr/th[4]/div[1]";
            }

            CommonDriver.waitClickableElement(addNewXPath);
            CommonDriver.Driver.FindElement(By.XPath(addNewXPath)).Click();

        }

        //select element in dropdown from all 4 tabs
        public void SelectDropDown(string DropdownName, string value, string element)
        {
            CommonDriver.TurnOnWait();
            if (element.Equals("TabLanguage"))
            {
                //CommonDriver.waitClickableElement("(//select[contains(@name,'level')])[1]");
                //new SelectElement(CommonDriver.Driver.FindElement(By.XPath("(//select[contains(@name,'level')])[1]"))).SelectByValue(value);
                CommonDriver.waitClickableElement("//select[@class='ui dropdown']");
                new SelectElement(CommonDriver.Driver.FindElement(By.XPath("//select[@class='ui dropdown']"))).SelectByValue(value);


                CommonDriver.TurnOnWait();
            }

            else if (element.Equals("TabSkill"))
            {
                CommonDriver.TurnOnWait();
                //CommonDriver.waitClickableElement("(//select[contains(@name,'level')])[2]");
                //new SelectElement(CommonDriver.Driver.FindElement(By.XPath("(//select[contains(@name,'level')])[2]"))).SelectByValue(value);
                CommonDriver.waitClickableElement("//select[@class='ui fluid dropdown']");
                new SelectElement(CommonDriver.Driver.FindElement(By.XPath("//select[@class='ui fluid dropdown']"))).SelectByValue(value);

                
                CommonDriver.TurnOnWait();
            }

            else
            {
                CommonDriver.TurnOnWait();
                new SelectElement(CommonDriver.Driver.FindElement(By.XPath("//select[contains(@name,'" + DropdownName + "')]"))).SelectByValue(value);
                CommonDriver.TurnOnWait();
            }

        }

        //validates the newly added record can be viewed in the table
        public void ValidateAdd()
        {
            //validate language added
            CommonDriver.Driver.FindElement(By.XPath("//a[@class='item'][contains(.,'Languages')]")).Click();
            CommonDriver.waitElementIsVisible("//*[@data-tab='first']/div/div[2]/div/table/tbody/tr/td[1]");
            string Language = CommonDriver.Driver.FindElement(By.XPath("//*[@data-tab='first']/div/div[2]/div/table/tbody/tr/td[1]")).Text;
            string LanguageLevel = CommonDriver.Driver.FindElement(By.XPath("(//div[@data-tab='first']//table//tbody//tr[1]//td[2])[1]")).Text;
            Assert.AreEqual(ExcelLibHelper.ReadData(2, "Language"), Language);
            Assert.AreEqual(ExcelLibHelper.ReadData(3, "Language"), LanguageLevel);

            //validate skill added
            TabSkill.Click();
            CommonDriver.waitElementIsVisible("(//div[@data-tab='second']//table//tbody//tr[1]//td[1])[1]");
            string Skill = CommonDriver.Driver.FindElement(By.XPath("(//div[@data-tab='second']//table//tbody//tr[1]//td[1])[1]")).Text;
            string SkillLevel = CommonDriver.Driver.FindElement(By.XPath("(//div[@data-tab='second']//table//tbody//tr[1]//td[2])[1]")).Text;
            Assert.AreEqual(ExcelLibHelper.ReadData(2, "Skill"), Skill);
            Assert.AreEqual(ExcelLibHelper.ReadData(3, "Skill"), SkillLevel);

            //validate education
            TabEducation.Click();
            CommonDriver.waitElementIsVisible("(//div[@data-tab='third']//table//tbody//tr[1]//td[1])[1]");
            string Country = CommonDriver.Driver.FindElement(By.XPath("(//div[@data-tab='third']//table//tbody//tr[1]//td[1])[1]")).Text;
            string University = CommonDriver.Driver.FindElement(By.XPath("(//div[@data-tab='third']//table//tbody//tr[1]//td[2])[1]")).Text;
            string Title = CommonDriver.Driver.FindElement(By.XPath("(//div[@data-tab='third']//table//tbody//tr[1]//td[3])[1]")).Text;
            string Degree = CommonDriver.Driver.FindElement(By.XPath("(//div[@data-tab='third']//table//tbody//tr[1]//td[4])[1]")).Text;
            string Year = CommonDriver.Driver.FindElement(By.XPath("(//div[@data-tab='third']//table//tbody//tr[1]//td[5])[1]")).Text;
            Assert.AreEqual(ExcelLibHelper.ReadData(4, "Education"), Country );
            Assert.AreEqual(ExcelLibHelper.ReadData(2, "Education"), University );
            Assert.AreEqual(ExcelLibHelper.ReadData(5, "Education"), Title);
            Assert.AreEqual(ExcelLibHelper.ReadData(3, "Education"), Degree);
            Assert.AreEqual(ExcelLibHelper.ReadData(6, "Education"), Year);

            //validate certification
            TabCertification.Click();
            CommonDriver.waitElementIsVisible("(//div[@data-tab='fourth']//table//tbody//tr[1]//td[1])[1]");
            string Certificate = CommonDriver.Driver.FindElement(By.XPath("(//div[@data-tab='fourth']//table//tbody//tr[1]//td[1])[1]")).Text;
            string From = CommonDriver.Driver.FindElement(By.XPath("(//div[@data-tab='fourth']//table//tbody//tr[1]//td[2])[1]")).Text;
            string CertificateYear = CommonDriver.Driver.FindElement(By.XPath("(//div[@data-tab='fourth']//table//tbody//tr[1]//td[3])[1]")).Text;
            Assert.AreEqual(ExcelLibHelper.ReadData(2, "Certification"), Certificate);
            Assert.AreEqual(ExcelLibHelper.ReadData(3, "Certification"), From);
            Assert.AreEqual(ExcelLibHelper.ReadData(4, "Certification"), Year);

        }

        public void ValidateUpdate()
        {
            //validate language updated
            CommonDriver.Driver.FindElement(By.XPath("//a[@class='item'][contains(.,'Languages')]")).Click();
            CommonDriver.waitElementIsVisible("//*[@data-tab='first']/div/div[2]/div/table/tbody/tr/td[1]");
            string Language = CommonDriver.Driver.FindElement(By.XPath("//*[@data-tab='first']/div/div[2]/div/table/tbody/tr/td[1]")).Text;
            Assert.AreEqual(ExcelLibHelper.ReadData(8, "Language"), Language);
           

            //validate skill updated
            TabSkill.Click();
            CommonDriver.waitElementIsVisible("(//div[@data-tab='second']//table//tbody//tr[1]//td[1])[1]");
            string Skill = CommonDriver.Driver.FindElement(By.XPath("(//div[@data-tab='second']//table//tbody//tr[1]//td[1])[1]")).Text;
            Assert.AreEqual(ExcelLibHelper.ReadData(8, "Skill"), Skill);
        

            //validate updated education
            TabEducation.Click();
            CommonDriver.waitElementIsVisible("(//div[@data-tab='third']//table//tbody//tr[1]//td[1])[1]");
            string University = CommonDriver.Driver.FindElement(By.XPath("(//div[@data-tab='third']//table//tbody//tr[1]//td[2])[1]")).Text;
            Assert.AreEqual(ExcelLibHelper.ReadData(8, "Education"), University);
    

            //validate updated certification
            TabCertification.Click();
            CommonDriver.waitElementIsVisible("(//div[@data-tab='fourth']//table//tbody//tr[1]//td[1])[1]");
            string Certificate = CommonDriver.Driver.FindElement(By.XPath("(//div[@data-tab='fourth']//table//tbody//tr[1]//td[1])[1]")).Text;
            Assert.AreEqual(ExcelLibHelper.ReadData(8, "Certification"), Certificate);
           
        }

        //delete first record from all 4 tabs
        public void RemoveSkill()
        {
             
            TabSkill.Click();
            string deleteButtonXpath = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[2]/i";
            //string deleteButtonXpath = "//i[contains(@class,'remove icon')]";
            //CommonDriver.waitClickableElement(deleteButtonXpath);
            CommonDriver.Driver.FindElement(By.XPath(deleteButtonXpath)).Click();
            
        }

        public void RemoveLanguage()
        {
            //click language tab
            TabLanguage.Click();
            //delete language record
            CommonDriver.Driver.FindElement(By.XPath("//i[contains(@class,'remove icon')]")).Click();
            
        }

        public void RemoveEducation()
        {
            TabEducation.Click();
           // CommonDriver.waitClickableElement("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[6]/span[2]/i");
            //delete education
            CommonDriver.Driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[6]/span[2]/i")).Click();
        }

        public void RemoveCertification()
        {
            TabCertification.Click();
            //CommonDriver.waitClickableElement("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[4]/span[2]/i");
            //delete certification
            CommonDriver.Driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[4]/span[2]/i")).Click();
        }

            //method to clear text from textbox
            public void ClearText(string path)
        {
            CommonDriver.Driver.FindElement(By.XPath(path)).Clear();
        }

        //updates records for language, skill, education and certification
        public void UpdateRecord()
        {
            TabLanguage.Click();
            CommonDriver.TurnOnWait();
            //click the pen icon to edit
            CommonDriver.Driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[3]/span[1]/i")).Click();
            //clear existing text
            ClearText("//input[@placeholder='Add Language']");
            AddText("//input[@placeholder='Add Language']", ExcelLibHelper.ReadData(8, "Language"));
            //click update button
            CommonDriver.Driver.FindElement(By.XPath("//input[@value='Update']")).Click();
            CommonDriver.TurnOnWait();

            TabSkill.Click();
            CommonDriver.TurnOnWait();
            CommonDriver.Driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i")).Click();
            //clear existing text
            ClearText("//input[@placeholder='Add Skill']");
            AddText("//input[@placeholder='Add Skill']", ExcelLibHelper.ReadData(8, "Skill"));

            //click update button
            CommonDriver.Driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]")).Click();
            CommonDriver.TurnOnWait();
                   
            TabEducation.Click();
            CommonDriver.TurnOnWait();
            //click pen icon
            CommonDriver.Driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[6]/span[1]/i")).Click();
            //clear textbox and update with new text input
            // CommonDriver.waitElementIsVisible("//*[@class='ui fixed table']/tbody/tr/td/div[1]/div[1]/input");
            // ClearText("//*[@class='ui fixed table']/tbody/tr/td/div[1]/div[1]/input");
            // AddText("//*[@class='ui fixed table']/tbody/tr/td/div[1]/div[1]/input", ExcelLibHelper.ReadData(8, "Education"));
            CommonDriver.TurnOnWait();
            CommonDriver.Driver.FindElement(By.XPath("//input[@type='text'][@name='instituteName']")).Clear();
            AddText("//input[@type='text'][@name='instituteName']", ExcelLibHelper.ReadData(8, "Education"));
            CommonDriver.TurnOnWait();
          

            //click update
            CommonDriver.Driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[3]/input[1]")).Click();
            CommonDriver.TurnOnWait();

            TabCertification.Click();
            CommonDriver.TurnOnWait();
            CommonDriver.Driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[4]/span[1]/i")).Click();
            ClearText("//input[contains(@placeholder,'Certificate or Award')]");
            AddText("//input[contains(@placeholder,'Certificate or Award')]", ExcelLibHelper.ReadData(8, "Certification"));

            CommonDriver.Driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td/div/span/input[1]")).Click();
            CommonDriver.TurnOnWait();

        }

        public bool isRecordExists(string tabName)
        {           
            try
            {
                CommonDriver.Driver.FindElement(By.XPath("//*[@data-tab='" + tabName + "']//table//tbody"));
                return false;
            }
            catch (NoSuchElementException ex)
            {
                return true;
            }
            
        }
        //reads the pop up message and return it in a string
        
        
        public string ReadPopup()
        {
            CommonDriver.TurnOnWait();
            //CommonDriver.waitClickableElement("//div[contains(@class,'ns-box-inner')]");
            string message = CommonDriver.Driver.FindElement(By.XPath("//div[contains(@class,'ns-box-inner')]")).Text;
            
           // CommonDriver.waitClickableElement("//a[@class='ns-close']");
           
           // CommonDriver.Driver.FindElement(By.XPath("//a[@class='ns-close']")).Click();
            return message;
        }
        
    }
}
