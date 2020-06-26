using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsQA_1.Helpers
{
    public class CommonDriver
    {

        //Initialize the browser
        public static IWebDriver Driver { get; set; }

        public void Initialize()
        {
            //Defining the browser
            Driver = new ChromeDriver();
            TurnOnWait();

            //Maximise the window
            Driver.Manage().Window.Maximize();
        }

        public static string BaseUrl
        {
            get { return ConstantHelpers.Url; }
        }


        //Implicit Wait
        public static void TurnOnWait()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

        }

        //explicit wait until element is clickable
        public static void waitClickableElement( string locatorValue)
        {
            try
            {
                var wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 20));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(locatorValue)));
                
            }
            catch (Exception ex)
            {
                Assert.Fail("Exception at waitClickableElement", ex.Message);
            }

        }

        //explicit wait until element is visible
        public static void waitElementIsVisible(string locatorValue)
        {
            try
            {
                var wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 20));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(locatorValue)));
               
            }
            catch (Exception ex)
            {
                Assert.Fail("Exception at waitElementIsVisible", ex.Message);
            }

        }

        public static void waitElement(string locatorValue)
        {
            try
            {
                var wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 5));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath(locatorValue)));

            }
            catch
            {

            }
        }
        public static void NavigateUrl()
        {
            Driver.Navigate().GoToUrl(BaseUrl);
        }

        //Close the browser
        public void Close()
        {
            Driver.Quit();
        }

        
    }
}
