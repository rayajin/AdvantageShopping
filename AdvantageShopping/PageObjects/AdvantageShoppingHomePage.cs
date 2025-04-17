using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AdvantageShopping.PageObjects
{
    internal class AdvantageShoppingHomePage
    {
        private readonly IWebDriver _driver;

        #region WebElements
        private IWebElement BtnUserIcon => _driver.FindElement(By.Id("hrefUserIcon"));
        private IWebElement BtnCreateNewAccount => _driver.FindElement(By.XPath("//a[contains(text(), 'CREATE NEW ACCOUNT')]"));

        #endregion

        public AdvantageShoppingHomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void NavigateToAdvantageShopping()
        {
            _driver.Navigate().GoToUrl("https://www.advantageonlineshopping.com/#/");
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementExists(By.Id("headphonesImg")));
        }

        public void CreateNewAccount()
        {
            BtnUserIcon.Click();
            BtnCreateNewAccount.Click();
        }

    }
}
