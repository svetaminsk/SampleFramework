using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SampleFramework1
{
    public class SampleApplicationTests
    {
        protected IWebDriver Driver { get; set; } = default!;
        internal TestUser TestUser { get; private set; } = default!;
        internal SampleApplicationPage SampleApplicationPage { get; private set; } = default!;
        internal TestUser EmergencyUser { get; private set; } = default!;

        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver();
            TestUser = new TestUser();
            TestUser.FirstName = "Svetlana";
            TestUser.LastName = "Doe";
            SampleApplicationPage = new SampleApplicationPage(Driver);
            EmergencyUser = new TestUser();
            EmergencyUser.FirstName = "Eric";
            EmergencyUser.LastName = "Jackson";
        }

        [Test]
        [Category("SampleApplication1")]
        public void TheApplicationFormIsSubmittedWithGenderFemale()
        {
            SetGenderType(Gender.Female, Gender.Male);
            SampleApplicationPage.GoTo();
            SampleApplicationPage.FillOutEmergencyContactForm(EmergencyUser);
            var homePage = SampleApplicationPage.FillOutFormAndSubmit(TestUser);
            Assert.IsTrue(homePage.IsVisible, "The home page was not visible");
        }

        [Test]
        [Category("SampleApplication1")]
        public void TheApplicationFormIsSubmittedWithGenderOther()
        {

            SetGenderType(Gender.Male, Gender.Other);

            SampleApplicationPage.GoTo();
            SampleApplicationPage.FillOutEmergencyContactForm(EmergencyUser);
            var homePage = SampleApplicationPage.FillOutFormAndSubmit(TestUser);
            Assert.IsTrue(homePage.IsVisible, "The home page was not visible");
        }

        private void SetGenderType(Gender primaryContact, Gender emergencyContact)
        {
            TestUser.GenderType = primaryContact;
            EmergencyUser.GenderType = emergencyContact;
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Close();
            Driver.Quit();
        }
    }
}