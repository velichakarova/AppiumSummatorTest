

using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Windows;
using System;

namespace AppiumSumatorTest.Tests
{
    public class SummatarTestAppium
    {

        private WindowsDriver<WindowsElement> driver;
        private const string AppiumServer = "http://127.0.0.1:4723/wd/hub";
        private AppiumOptions options;

        [OneTimeSetUp]
        public void OpenApp()
        {
            this.options = new AppiumOptions();
            options.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Windows");
            options.AddAdditionalCapability(MobileCapabilityType.App, @"C:\SummatorDesktopApp.exe");

            this.driver = new WindowsDriver<WindowsElement>(new Uri(AppiumServer), options);
        }

        [OneTimeTearDown]
        public void ShutDownApp()
        {
            this.driver.Quit();
        }
        [Test]
        public void Test_Sum_Two_PositiveNumber_POM()
        { 
            var window = new Window.SummatorWindow(driver);
            string value1 = "5";
            string value2 = "10";
            string result = window.Calculate(value1, value2);

            
            Assert.That(result, Is.EqualTo("15"));
        }
    }
}
