using Locators;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Webdriver.Task2
{
    public class PasteBinPage
    {
        private const string TestUrl = "https://pastebin.com/";
        public const string PostFormText = @"
git config --global user.name  'New Sheriff in Town'
git reset $(git commit-tree HEAD^{tree} -m 'Legacy code')
git push origin master --force";
        public const string TitleFieldText = "how to gain dominance among developers";
        private readonly Locator _locators;
        private readonly IWebDriver _driver;
        private IWebElement expirationDropdown;
        private string expirationValue;
        private string higlitingValue;
        IJavaScriptExecutor js;

        public PasteBinPage(IWebDriver driver)
        {
            _driver = driver;
            _locators = new Locator(driver);
            js = (IJavaScriptExecutor)_driver;
            expirationValue = "10M";
            higlitingValue = "4bg1-8";
        }


        public void Open()
        {
            _driver.Navigate().GoToUrl(TestUrl);
        }

        public void EditPost()
        {
            _locators.PostForm.SendKeys(PostFormText);
        }

        public void SelectHighlightingSelect()
        {
            _locators.HiglitingField.Click();
            this.js.ExecuteScript($"arguments[0].value = '{higlitingValue}';", _locators.HiglitingField);
        }

        public void SelectExpirationSelect()
        {
          _locators.ExpirationDropDown.Click();
            js.ExecuteScript("arguments [0].value='" + expirationValue + "';", _locators.ExpirationDropDown);
        }

        public void SetTitleSelect()
        {
            _locators.TitleField.SendKeys(TitleFieldText);
        }

        public void SubmitPost()
        {
            _locators.SubmitButton.Click();
        }

        public bool IsSyntaxHighlighted(string expectedSyntax)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement syntaxHighlightElement = wait.Until(driver => driver.FindElement(By.CssSelector(".syntax_highlighting_class"))); 
            return syntaxHighlightElement.Text.Contains(expectedSyntax);
        }

        public string GetCode()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement parentElement = wait.Until(driver => driver.FindElement(By.ClassName("source bash")));
            IReadOnlyCollection<IWebElement> childElements = parentElement.FindElements(By.CssSelector("div.del1"));
            string concatenatedText = string.Join(" ", childElements.Select(e => e.Text.Trim()));
            return concatenatedText;
        }

        public string GetPageTitle()
        {
            return _driver.Title;
        }

        public void AddNewPost()
        {
            Open();
            EditPost();
            SelectHighlightingSelect();
            SelectExpirationSelect();
            SetTitleSelect();
            Thread.Sleep(1000);
            SubmitPost();
        }
    }
}

