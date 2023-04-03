using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SampleFramework1
{
    public class BaseApplicationPage
    {
        public IWebDriver Driver { get; set; }
        public BaseApplicationPage(IWebDriver driver)
        {
            this.Driver = driver;
        }
    }
}