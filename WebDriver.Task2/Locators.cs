using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Locators 
{
    public class Locator
    {
        private IWebDriver _driver;

        public Locator(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement PostForm => _driver.FindElement(By.Id("postform-text"));
        public IWebElement HiglitingField => _driver.FindElement(By.CssSelector("#select2-postform-format-container"));
        public IWebElement ExpirationDropDown => _driver.FindElement(By.Id("select2-postform-expiration-container"));
        public IWebElement SubmitButton => _driver.FindElement(By.CssSelector("button[type='submit']"));
        public IWebElement TitleField => _driver.FindElement(By.Id("postform-name"));
        public IWebElement CodeCheck => _driver.FindElement(By.ClassName("source bash"));
    }
}
