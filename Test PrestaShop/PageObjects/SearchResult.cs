using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Test_PrestaShop.PageObjects
{
    class SearchResult : BasePage
    {

        public SearchResult(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }


    }
}
