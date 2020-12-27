using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Test_PrestaShop.PageObjects
{
    class Header : BasePage
    {
        public Header(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }
        public IWebElement SearchInput => _driver.FindElement(By.Name("search_query"));

        //actions
        public Header GoToHomePage()
        {
            _driver.Navigate().GoToUrl(Url);
            return this;
        }
    }
}
