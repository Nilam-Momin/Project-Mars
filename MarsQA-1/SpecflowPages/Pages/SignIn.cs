using MarsQA_1.Helpers;
using MongoDB.Driver.Core.Authentication;
using OpenQA.Selenium;
using System.Threading;

namespace MarsQA_1.Pages
{
    public class SignIn
    {
        public SignIn()
        {
            ExcelLibHelper.PopulateInCollection(@"\MarsQA-1\SpecflowTests\Data\Mars.xlsx", "Credentials");
            username = ExcelLibHelper.ReadData(2, "username");
            password = ExcelLibHelper.ReadData(2, "password");
        }

        private string username;
        private string password;
        private IWebElement SignInBtn => CommonDriver.Driver.FindElement(By.XPath("//a[@class='item'][text()='Sign In']"));
        private IWebElement Email => CommonDriver.Driver.FindElement(By.XPath("(//input[@type='text'])[2]"));
        private IWebElement Password => CommonDriver.Driver.FindElement(By.XPath("//input[@type='password']"));
        private IWebElement LoginBtn => CommonDriver.Driver.FindElement(By.XPath("//button[@class='fluid ui teal button'][text()='Login']"));
        public void SigninStep()
        {
            CommonDriver.NavigateUrl();
            SignInBtn.Click();
            Email.SendKeys(username);
            Password.SendKeys(password);
            LoginBtn.Click();
        }
        public static void Login()
        {
            CommonDriver.NavigateUrl();

            //Enter Url
            CommonDriver.Driver.FindElement(By.XPath("//A[@class='item'][text()='Sign In']")).Click();

            //Enter Username
            CommonDriver.Driver.FindElement(By.XPath("(//INPUT[@type='text'])[2]")).SendKeys("");

            //Enter password
            CommonDriver.Driver.FindElement(By.XPath("//INPUT[@type='password']")).SendKeys("");

            //Click on Login Button
            CommonDriver.Driver.FindElement(By.XPath("//BUTTON[@class='fluid ui teal button'][text()='Login']")).Click();

        }
    }
}