using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Globalization;

namespace Test_PrestaShop.PageObjects
{
    class Order : BasePage
    {
        public Order(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }
        protected static string CheckOutUrl = "http://automationpractice.com/index.php?controller=order";
        public IWebElement TotalProducts => _driver.FindElement(By.Id("total_product"));
        public IWebElement TotalShipping => _driver.FindElement(By.Id("total_shipping"));
        public IWebElement TotalPriceWithoutTax => _driver.FindElement(By.Id("total_price_without_tax"));
        public IWebElement TotalTax => _driver.FindElement(By.Id("total_tax"));
        public IWebElement TotalPrice => _driver.FindElement(By.Id("total_price"));
        public IWebElement UnitPrice => _driver.FindElement(By.Id("product_price_4_17_0"));
        public IWebElement Quantity => _driver.FindElement(By.Name("quantity_4_17_0_0"));
        public IWebElement ProceedToCheckout => _driver.FindElement(By.LinkText("Proceed to checkout"));

        public Order GoToOrder()
        {
            _driver.Navigate().GoToUrl(CheckOutUrl);
            return this;
        }
        public decimal ParsePrice(string value)
        {
            NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
            CultureInfo provider = new CultureInfo("en-US");
            decimal number = Decimal.Parse(value, style, provider);

            return number;
        }
    }
}
