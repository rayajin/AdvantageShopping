using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Reqnroll;
using Reqnroll.BoDi;
using AdvantageShopping.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AdvantageShopping.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private readonly IObjectContainer _container;

        public Hooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario]
        public void CreateWebDriver()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _container.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterScenario]
        public void DestroyWebDriver()
        {
            IWebDriver driver = _container.Resolve<IWebDriver>();
            driver.Close();
            driver.Dispose();
        }
    }
}