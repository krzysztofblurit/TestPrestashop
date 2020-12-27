using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Test_PrestaShop.PageObjects
{
    class Product : BasePage
    {
        private readonly IWebDriver _driver;
        public Product(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }
        protected static string ProductUrl = "http://automationpractice.com/index.php?id_product=4&controller=product#/size-s/color-beige";

        public IWebElement Quantity => _driver.FindElement(By.Id("quantity_wanted"));
        public IWebElement Minus => _driver.FindElement(By.ClassName("icon-minus"));
        public IWebElement Plus => _driver.FindElement(By.ClassName("icon-plus"));
        public IWebElement SelectSize => _driver.FindElement(By.Id("group_1"));
        public IWebElement ButtonSubmit => _driver.FindElement(By.Name("Submit"));
        public IWebElement ButtonProceedToCheckout => _driver.FindElement(By.XPath("//*[@id=\"layer_cart\"]/div[1]/div[2]/div[4]/a"));

        public Product GoToProductPrintedDress()
        {
            _driver.Navigate().GoToUrl(ProductUrl);
            return this;
        }
    }
}
