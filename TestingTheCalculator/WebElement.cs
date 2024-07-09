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
        public IWebElement InputBar() => Page.GetElement(By.XPath("//span[@class='dcg-mq-root-block dcg-mq-empty']"));
        public IWebElement OutputBar() => Page.GetElement(By.ClassName("dcg-exp-output-container"));
        public IWebElement ErrorIcon() => Page.GetElement(By.ClassName("dcg-icon-error"));
        public IWebElement AbcButton() => Page.GetElement(By.XPath("//*[text()='abc']"));
        public IWebElement A_Button() => Page.GetElement(By.XPath("//span[@dcg-command='a']"));

        public IWebElement SettingsButton() => Page.GetElement(By.XPath("//div[@dcg-command='settings']"));
        public IWebElement ContrastButton() => Page.GetElement(By.ClassName("dcg-checkbox"));
        public IWebElement CheckBoxContrast() => Page.GetElement(By.XPath("//div[@class='dcg-component-checkbox dcg-checked dcg-settings-menu-option dcg-do-not-blur dcg-reverse-contrast']"));
    }
}
