using OpenQA.Selenium;
using PageObjLib.Factories;
using PageObjLib.Page;
using SeleniumExtras.WaitHelpers;

namespace TestingTheCalculator
{
    public class WebElement
    {
        public Dictionary<string, IWebElement> dicOfButtons {get; set;}

        public WebElement()
        {
            dicOfButtons ??= GetButtons();
        }
        public Dictionary<string, IWebElement> GetButtons()
        {
            var allButtons = Driver.GetWait().Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//span[@dcg-command]"))).DistinctBy(a => a.Text).ToList();
            return allButtons.ToDictionary(p => p.Text);
        }

        public IWebElement ClearAllButton() => Page.GetElement(By.XPath("//div[text()='стереть все']"));

        public IWebElement Output() => Page.GetElement(By.ClassName("dcg-exp-output-container"));
    }
}
