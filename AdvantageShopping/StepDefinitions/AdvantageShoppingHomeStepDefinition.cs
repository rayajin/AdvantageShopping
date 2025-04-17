using System;
using Reqnroll;
using OpenQA.Selenium;
using AdvantageShopping.PageObjects;
using NUnit.Framework;

namespace AdvantageShopping.StepDefinitions
{
    [Binding]
    public class AdvantageShoppingHomeStepDefinition
    {
        private readonly IWebDriver _driver;
        AdvantageShoppingHomePage _advantageShoppingHomePage;
        CreateAccountPage _createAccountPage;

        public AdvantageShoppingHomeStepDefinition(IWebDriver driver)
        {
            _driver = driver;
        }

        [Given("I navigate to Advantage Online Shopping")]
        public void GivenINavigateToAdvantageOnlineShopping()
        {
            _advantageShoppingHomePage = new AdvantageShoppingHomePage(_driver);
            _advantageShoppingHomePage.NavigateToAdvantageShopping();
        }

        [When("I click on user icon to create new account")]
        public void WhenIClickOnUserIconToCreateNewAccount()
        {
            _advantageShoppingHomePage = new AdvantageShoppingHomePage(_driver);
            _advantageShoppingHomePage.CreateNewAccount();
        }

        [Then("I should see create new account page displayed")]
        public void ThenIShouldSeeCreateNewAccountPageDisplayed()
        {
            _createAccountPage = new CreateAccountPage(_driver);
            _createAccountPage.CheckCreateAccountTitleIsVisible();
            Assert.AreEqual("CREATE ACCOUNT", _createAccountPage.GetCreateAccountTitle());
        }
    }
}
