using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using Reqnroll;

namespace AdvantageShopping.PageObjects
{
    internal class CreateAccountPage
    {
        private readonly IWebDriver _driver;

        #region WebElements
        private IWebElement TxtCreateAccount => _driver.FindElement(By.XPath("//h3[@class='roboto-regular sticky fixedImportant ng-scope']"));
        private IWebElement TxtboxUsername => _driver.FindElement(By.Name("usernameRegisterPage"));
        private IWebElement TxtboxEmail => _driver.FindElement(By.Name("emailRegisterPage"));
        private IWebElement TxtboxPassword => _driver.FindElement(By.Name("passwordRegisterPage"));
        private IWebElement TxtboxConfirmPassword => _driver.FindElement(By.Name("confirm_passwordRegisterPage"));
        private IWebElement TxtboxFirstName => _driver.FindElement(By.Name("first_nameRegisterPage"));
        private IReadOnlyCollection<IWebElement> TxtInputErrorMessages => _driver.FindElements(By.XPath("//label[contains(text(), 'is required')]"));
        private IWebElement BtnCreateNewAccount => _driver.FindElement(By.XPath("//a[contains(text(), 'CREATE NEW ACCOUNT')]"));

        #endregion

        public CreateAccountPage (IWebDriver driver)
        {
            _driver = driver;
        }

        public string GetCreateAccountTitle()
        {
            return TxtCreateAccount.Text;
        }

        public string GetInputValidationErrorMessage(string inputField)
        {
            var errorList = TxtInputErrorMessages;
            foreach (var errorMessage in errorList)
            {
                if (errorMessage.Text.Contains(inputField))
                    return errorMessage.Text;
            }
            return null;
        }

        public Boolean IsInputValidationErrorMessageDisplayed()
        {
            int errorList = TxtInputErrorMessages.Count;
            if (errorList > 0)
                return true;
            return false;
        }

        public void CheckCreateAccountTitleIsVisible()
        {
            try
            {
                var createAccountHeading = TxtCreateAccount.Displayed;
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (BtnCreateNewAccount.Displayed)
                    BtnCreateNewAccount.Click();
                else
                {

                }
            }
        }

        public void ClickUsernameTextbox()
        {
            TxtboxUsername.Click();
        }

        public void ClickEmailTextbox()
        {
            TxtboxEmail.Click();
        }

        public void ClickPasswordTextbox()
        {
            TxtboxPassword.Click();
        }

        public void ClickConfirmPasswordTextbox()
        {
            TxtboxConfirmPassword.Click();
        }

        public void ClickFirstNameTextbox()
        {
            TxtboxFirstName.Click();
        }

        public void EnterAccountDetails(string username, string email, string password, string confirmPassword)
        {
            TxtboxUsername.SendKeys(username);
            TxtboxEmail.SendKeys(email);
            TxtboxPassword.SendKeys(password);
            TxtboxConfirmPassword.SendKeys(confirmPassword);
        }
    }
}
