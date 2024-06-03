using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjLib.Factories;
using PageObjLib.Page;
using SeleniumExtras.WaitHelpers;
using Xunit;

namespace TestingTheCalculator
{
    public class Tests
    {
        
        [SetUp]
        public void Setup()
        {
           Page.GoUrl("https://www.desmos.com/scientific?lang=ru");
        }



        [Fact(DisplayName = "ClearAllButtonPositive")]
        [Test]
        public void ClearButtonTest1()
        {
            WebElement element = new();

            element.dicOfButtons["1"].Click();
            element.dicOfButtons["+"].Click();
            element.dicOfButtons["1"].Click();

            var result = element.ClearAllButton().Displayed;

            Assert.IsTrue(result);
        }

        [Fact(DisplayName = "OutputContainer")]
        [Test]
        public void OutputTest1()
        {
            WebElement element = new();

            element.dicOfButtons["8"].Click();
            element.dicOfButtons["×"].Click();
            element.dicOfButtons["9"].Click();

            var result = element.Output().Displayed;

            Assert.IsTrue(result);
        }




        [TearDown]
        public void TearDown()
        {
            Driver.QuitDriver();
            Driver.DisposeDriver();
        }

    }
}