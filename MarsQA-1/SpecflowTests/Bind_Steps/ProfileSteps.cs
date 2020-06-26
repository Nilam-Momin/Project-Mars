using MarsQA_1.Helpers;
using MarsQA_1.Pages;
using MarsQA_1.SpecflowPages.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace MarsQA_1.SpecflowTests.Bind_Steps
{
    [Binding]
    public class ProfileSteps
    {
        //create profile page object
        Profile ProfilePage;
        string Availabilitymessage;
        string Hourmessage;
        string EarnTargetmessage;

        [Given(@"I have logged into the portal")]
        public void GivenIHaveLoggedIntoThePortal()
        {
            SignIn signin = new SignIn();
            //sign in 
            signin.SigninStep();
            ProfilePage = new Profile();
        }

        [When(@"I add language, skill, education and certification")]
        public void WhenIAddLanguageSkillEducationAndCertification()
        {
           // ProfilePage = new Profile();
            ProfilePage.AddLanguage();
            ProfilePage.AddSkill();
            ProfilePage.AddEducation();
            ProfilePage.AddCertification();
        }

        [When(@"I add availability")]
        public void WhenIAddAvailability()
        {
           Availabilitymessage = ProfilePage.AddAvailability(ExcelLibHelper.ReadData(2, "Availability"));
           Hourmessage = ProfilePage.AddAvailabilityHour(ExcelLibHelper.ReadData(2, "Hour"));
           EarnTargetmessage = ProfilePage.AddEarnTarget(ExcelLibHelper.ReadData(2, "EarnTarget"));
        }

        [Then(@"I should be able to get confirmation message")]
        public void ThenIShouldBeAbleToGetConfirmationMessage()
        {
            if((Availabilitymessage == "Availability updated") && (Hourmessage == "Availability updated") && (EarnTargetmessage == "Availability updated"))
            {
                Assert.Pass("Availability added successfully");
            }
        }


        [Then(@"I should be able to view the record")]
        public void ThenIShouldBeAbleToViewTheRecord()
        {
            //validate new record
            ProfilePage.ValidateAdd();
        }


        [When(@"I update skill, education, certification and language")]
        public void WhenIUpdateSkillEducationCertificationAndLanguage()
        {
            //update education, certification, skill and language with null values
            ProfilePage.UpdateRecord();
        }

        [Then(@"I should be able to see the updated record")]
        public void ThenIShouldBeAbleToSeeTheUpdatedRecord()
        {
            //validates the updated record
            ProfilePage.ValidateUpdate();
        }




        [When(@"I remove  certification, skill, education and language")]
        public void WhenIRemoveCertificationSkillEducationAndLanguage()
        {
            //remove record in language, skill, education and certification each
            ProfilePage.RemoveSkill();
            ProfilePage.RemoveCertification();
            ProfilePage.RemoveLanguage();
            ProfilePage.RemoveEducation();
            
        }

        [Then(@"I should be able to see a confirmation message")]
        public void ThenIShouldBeAbleToSeeAConfirmationMessage()
        {
            Assert.IsTrue(ProfilePage.isRecordExists("first"));
            Assert.IsTrue(ProfilePage.isRecordExists("second"));
            Assert.IsTrue(ProfilePage.isRecordExists("third"));
            Assert.IsTrue(ProfilePage.isRecordExists("fourth"));

            
        }

    }
}
