using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace Webdriver.Task2
{
    public class PasteBinPageTests
    {
        private IWebDriver _driver;
        private PasteBinPage _pasteBinPage;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _pasteBinPage = new PasteBinPage(_driver);
        }


        [Test]
        public void TestCodeContentAndPageTitle()
        {
            _pasteBinPage.AddNewPost();
            //Thread.Sleep(5000);
            string actualCode = _pasteBinPage.GetCode();

            string expectedCode = PasteBinPage.PostFormText.Trim();

            Assert.AreEqual(PasteBinPage.TitleFieldText, _pasteBinPage.GetPageTitle());

            Assert.AreEqual(expectedCode, actualCode.Trim());
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
