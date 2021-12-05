using OpenQA.Selenium;

namespace TestProjectSelenium.PageObjects
{
    internal class BasePage
    {
        protected IWebDriver _driver;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }
    }
}
