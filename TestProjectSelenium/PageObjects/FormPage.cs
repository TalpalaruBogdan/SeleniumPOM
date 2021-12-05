using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TestProjectSelenium.Utils;

namespace TestProjectSelenium.PageObjects
{
    internal class FormPage : BasePage
    {
        private IWebElement _nameInput => _driver.FindElement(By.Id("nameInput"));
        private IWebElement _surnameInput => _driver.FindElement(By.Id("surnameInput"));
        private IWebElement _nameOutput => _driver.FindElement(By.Id("nameEntry"));
        private IWebElement _surnameOutput => _driver.FindElement(By.Id("surnameEntry"));
        private IWebElement _submitButton => _driver.FindElement(By.Id("submitButton"));

        public FormPage(IWebDriver driver) : base(driver)
        {
        }

        public void FillAndSubmitForm(string name, string surname)
        {
            ActionHelper.SendText(_nameInput, name);
            ActionHelper.SendText(_surnameInput, surname);
            ActionHelper.ClickElement(_submitButton);
        }

        public void AssertFormOutputs(string name, string surname)
        {
            ActionHelper.GetText(_nameOutput).Should().Be(name, $"because it expects {name} to be reflected");
            ActionHelper.GetText(_surnameOutput).Should().Be(surname, $"because it expects {surname} to be reflected");
        }

        internal void AssertFormOutputs(object warnings, string v)
        {
            throw new NotImplementedException();
        }
    }
}
