using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SampleFramework1
{
    internal class SampleApplicationPage : BaseApplicationPage
    {

        public bool? IsVisible => Driver.Title.Contains(PageTitle);

        public IWebElement FirstNameField => Driver.FindElement(By.XPath("//*[@id='f1']"));

        public IWebElement SubmitButton => Driver.FindElement(By.XPath("//*[@id='submit1']"));

        public IWebElement LastNameField => Driver.FindElement(By.XPath("//*[@id='l1']"));

        public string PageTitle => "Sample Application Lifecycle - Sprint 4 - Ultimate QA";

        public IWebElement FemaleRadioButton => Driver.FindElement(By.XPath("//*[@id='radio1-f']"));

        public IWebElement MaleRadioButton => Driver.FindElement(By.XPath("//*[@id='radio1-m']"));
        public IWebElement OtherRadioButton => Driver.FindElement(By.XPath("//*[@value='radio1-0']"));

        public IWebElement FemaleRadioButtonForEmergencyContact => Driver.FindElement(By.XPath("//*[@id='radio2-f']"));
        public IWebElement MaleRadioButtonForEmergencyContact => Driver.FindElement(By.XPath("//*[@id='radio2-m']"));
        public IWebElement OtherRadioButtonForEmergencyContact => Driver.FindElement(By.XPath("//*[@id='radio2-0']"));

        public IWebElement FirstNameFieldForEmergencyContact => Driver.FindElement(By.XPath("//*[@id='f2']"));
        public IWebElement LastNameFieldForEmergencyContact => Driver.FindElement(By.XPath("//*[@id='l2']"));

        public SampleApplicationPage(IWebDriver driver) : base(driver) {}

        internal void FillOutEmergencyContactForm(TestUser emergencyUser)
        {
            SetGenderForEmergencyContact(emergencyUser);
            FirstNameFieldForEmergencyContact.SendKeys(emergencyUser.FirstName);
            LastNameFieldForEmergencyContact.SendKeys(emergencyUser.LastName);
        }

        private void SetGenderForEmergencyContact(TestUser emergencyUser)
        {
            switch (emergencyUser.GenderType)
            {
                case Gender.Female:
                    FemaleRadioButtonForEmergencyContact.Click();
                    break;
                case Gender.Male:
                    MaleRadioButtonForEmergencyContact.Click();
                    break;
                case Gender.Other:
                    OtherRadioButtonForEmergencyContact.Click();
                    break;
            }
        }

        internal void GoTo()
        {
            Driver.Navigate().GoToUrl("https://ultimateqa.com/sample-application-lifecycle-sprint-4/");
            Assert.IsTrue(IsVisible, $"Expected: {PageTitle}, Actual: {Driver.Title}");
        }

        internal HomePage FillOutFormAndSubmit(TestUser user)
        {
            SetGender(user);
            FirstNameField.SendKeys(user.FirstName);
            LastNameField.SendKeys(user.LastName);
            SubmitButton.Submit();
            return new HomePage(Driver);
        }

        private void SetGender(TestUser user)
        {
            switch (user.GenderType)
            {
                case Gender.Female:
                    FemaleRadioButton.Click();
                    break;
                case Gender.Male:
                    MaleRadioButton.Click();
                    break;
                case Gender.Other:
                    OtherRadioButton.Click();
                    break;
            }
        }
    }
}