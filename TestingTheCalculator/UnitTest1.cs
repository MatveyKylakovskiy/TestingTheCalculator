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

        [Fact(DisplayName = "OutputContainerPositive")]
        [Test]
        public void OutputTest1()
        {
            WebElement element = new();

            element.dicOfButtons["4"].Click();
            element.dicOfButtons["×"].Click();
            element.dicOfButtons["5"].Click();

            var result = element.OutputBar().Text;


            Assert.That(result,Is.EqualTo("=20"));

        }

        [Fact(DisplayName = "ErorIconTestNegative")]
        [Test]
        public void ErrorIconTest()
        {
            WebElement element = new();

            element.AbcButton().Click();
            element.A_Button().Click();

            var result = element.ErrorIcon().GetAttribute("aria-hidden");

            Assert.That(result, Is.EqualTo("true"));

        }

        [Fact(DisplayName = "ContrastSettingsTest")]
        [Test]
        public void ContrastTest()
        {
            WebElement element = new();

            element.SettingsButton().Click();
            element.ContrastButton().Click();

            var result = element.CheckBoxContrast().GetAttribute("aria-checked");

            Assert.That(result, Is.EqualTo("true"));

        }




        [TearDown]
        public void TearDown()
        {
            Driver.QuitDriver();
            Driver.DisposeDriver();
        }

    }
}