using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TestProjectSelenium.Utils;

namespace TestProjectSelenium.Driver
{
    internal class BaseDriver
    {
        public IWebDriver Driver { get; private set; }

        public int ElementFindTimeout { private get; set; }

        public int PageLoadTimeout { private get; set; }

        public BaseDriver(BrowserType browserType = BrowserType.CHROME)
        {
            ChromeOptions options = new();
            options.AddArgument("headless");

            ElementFindTimeout = Constants.DefaultWait;
            PageLoadTimeout = Constants.DefaultWait;

            switch (browserType)
            {
                case BrowserType.CHROME:
                    {

                        Driver = new ChromeDriver(Constants.ChromeDriverPath, options);
                        break;
                    }
                default:
                    {
                        Driver= new ChromeDriver(Constants.ChromeDriverPath, options);
                        break;
                    }
            }

            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ElementFindTimeout);
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(PageLoadTimeout);
        }

        public void NavigateToUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public void Quit()
        {
            Driver.Quit();
        }
    }
}
