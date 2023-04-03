using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SampleFramework1
{
    internal class HomePage : BaseApplicationPage
    {
        
        public HomePage(IWebDriver driver) : base(driver) {}
        public bool IsVisible => Driver.Title.Contains("Homepage - Ultimate QA");
    }
}