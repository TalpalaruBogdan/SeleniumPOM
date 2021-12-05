using ContentManagement;
using NUnit.Framework;
using TestProjectSelenium.Driver;
using TestProjectSelenium.PageObjects;
using TestProjectSelenium.Utils;

namespace TestProjectSelenium.Tests
{
    
    internal class FormPageTests
    {
        BaseDriver? baseDriver;
        FormPage? formPage;

        [SetUp] 
        public void Setup()
        {
            baseDriver = new BaseDriver();
            formPage = new FormPage(baseDriver.Driver);
            baseDriver.NavigateToUrl(Constants.FormPageUrl);
        }

        [TearDown]
        public void TearDown()
        {
            baseDriver?.Quit();
        }


        [TestCase("John", "Doe")]
        public void FillAndSubmitForm_Should_ReflectCorrectInput(string name, string surname)
        {
            formPage?.FillAndSubmitForm(name, surname);
            formPage?.AssertFormOutputs(name, surname);
        }

        [TestCase("", "")]
        public void EmptySubmitForm_Should_ReflectEmptyWarning(string name, string surname)
        {
            formPage?.FillAndSubmitForm(name, surname);
            formPage?.AssertFormOutputs(Warnings.MissingValueWarningMessage, Warnings.MissingValueWarningMessage);
        }

        [TestCase("123,,'.", "123,,'.")]
        public void CharsSubmitForm_Should_ReflectForbiddenCharsWarning(string name, string surname)
        {
            formPage?.FillAndSubmitForm(name, surname);
            formPage?.AssertFormOutputs(Warnings.SpecialCharWarningMessage, Warnings.SpecialCharWarningMessage);
        }
    }
}