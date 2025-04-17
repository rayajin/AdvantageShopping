using System;
using AdvantageShopping.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace AdvantageShopping.StepDefinitions
{
    [Binding]
    public class CreateAccountStepDefinitions
    {
        private readonly IWebDriver _driver;
        CreateAccountPage _createAccountPage;

        public CreateAccountStepDefinitions(IWebDriver driver)
        {
            _driver = driver;
        }

        [When("I click on username field")]
        public void WhenIClickOnUsernameField()
        {
            _createAccountPage = new CreateAccountPage(_driver);
            _createAccountPage.ClickUsernameTextbox();
        }

        [When("I click on email field")]
        public void WhenIClickOnEmailField()
        {
            _createAccountPage = new CreateAccountPage(_driver);
            _createAccountPage.ClickEmailTextbox();
        }

        [When("I click on password field")]
        public void WhenIClickOnPasswordField()
        {
            _createAccountPage = new CreateAccountPage(_driver);
            _createAccountPage.ClickPasswordTextbox();
        }

        [When("I click on confirm password field")]
        public void WhenIClickOnConfirmPasswordField()
        {
            _createAccountPage = new CreateAccountPage(_driver);
            _createAccountPage.ClickConfirmPasswordTextbox();
        }

        [When("I click on First Name field")]
        public void WhenIClickOnFirstNameField()
        {
            _createAccountPage = new CreateAccountPage(_driver);
            _createAccountPage.ClickFirstNameTextbox();
        }

        [Then("I should see validation message errors on the Account Details fields")]
        public void ThenIShouldSeeValidationMessageErrorsOnTheAccountDetailsFields()
        {
            _createAccountPage = new CreateAccountPage(_driver);
            Assert.AreEqual("Username field is required", _createAccountPage.GetInputValidationErrorMessage("Username"));
            Assert.AreEqual("Email field is required", _createAccountPage.GetInputValidationErrorMessage("Email"));
            Assert.AreEqual("Password field is required", _createAccountPage.GetInputValidationErrorMessage("Password"));
            Assert.AreEqual("Confirm password field is required", _createAccountPage.GetInputValidationErrorMessage("Confirm password"));
        }

        [When("I enter {string}, {string}, {string} and {string}")]
        public void WhenIEnterAnd(string username, string email, string password, string confirmPassword)
        {
            _createAccountPage = new CreateAccountPage(_driver);
            _createAccountPage.EnterAccountDetails(username, email, password, confirmPassword);
        }


        [Then("I should not see any validation messages on the fields")]
        public void ThenIShouldNotSeeAnyValidationMessagesOnTheFields()
        {
            _createAccountPage = new CreateAccountPage(_driver);
            Assert.AreEqual(false, _createAccountPage.IsInputValidationErrorMessageDisplayed());
        }
    }
}
