using OpenQA.Selenium;

namespace TestProjectSelenium.Utils
{
    internal class ActionHelper
    {
        public static void ClickElement(IWebElement element) => element.Click();

        public static void SendText(IWebElement element, string text) => element.SendKeys(text + Keys.Enter);
    
        public static void ClearText(IWebElement element) => element.Clear();

        public static bool IsElementDisplayed(IWebElement element) => element.Displayed;

        public static string GetText(IWebElement element) => element.Text;
    }
}
