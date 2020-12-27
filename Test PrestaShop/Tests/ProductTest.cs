using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using Test_PrestaShop.PageObjects;
using Test_PrestaShop.Utilities;

namespace Test_PrestaShop.Tests
{
    [TestFixture]
    class ProductTest : BaseTest
    {

        private static object[] _SourceData =
        {
            new object[] { 120 }
        };
        private static object[] _Size =
{
            new object[] { "M" }
        };

        [Test, Order(1), TestCaseSource("_SourceData")]
        public void CheckIncreasingOfTheValue(int howMany)
        {
            Product product = new Product(driver);
            product.GoToProductPrintedDress();

            int i = 1;
            while (howMany >= i)
            {
                product.Plus.Click();
                i++;
            }
            var Quantity = product.Quantity.GetAttribute("value");

            Assert.AreEqual(howMany + 1, Int32.Parse(Quantity));
        }
        [Test, Order(2), TestCaseSource("_SourceData")]
        public void CheckDecreasingOfTheValue(int howMany)
        {
            Product product = new Product(driver);

            int i = 1;
            while (howMany/2 >= i)
            {
                product.Minus.Click();
                i++;
            }
            var Quantity = product.Quantity.GetAttribute("value");

            Assert.AreEqual(howMany/2 + 1, Int32.Parse(Quantity));
        }
        [Test, Order(3), TestCaseSource("_SourceData")]
        public void CheckChangeOfTheValue(int howMany)
        {
            Product product = new Product(driver);
            Actions action = new Actions(driver);

            action
                .DoubleClick(product.Quantity)
                .SendKeys(Keys.Delete)
                .SendKeys(product.Quantity, howMany.ToString())
                .Build()
                .Perform();

            var Quantity = product.Quantity.GetAttribute("value");

            Assert.AreEqual(howMany, Int32.Parse(Quantity));
        }
        [Test, Order(4)]
        public void CheckDropDown()
        {
            Product product = new Product(driver);
            Actions action = new Actions(driver);

            var size = product.SelectSize.GetAttribute("value");

            action
                .Click(product.SelectSize)
                .SendKeys(Keys.Down)
                .SendKeys(Keys.Down)
                .SendKeys(Keys.Enter)
                .Build()
                .Perform();

            var newSize = product.SelectSize.GetAttribute("value");

            Assert.AreNotEqual(size, newSize);
        }
        [Test, Order(5), TestCaseSource("_Size")]
        public void CheckDropDownChooseSize(string choseSize)
        {
            Product product = new Product(driver);

            string size = product.SelectSize.GetAttribute("value");

            new SelectElement(product.SelectSize)
                .SelectByText(choseSize);

            var newSize = product.SelectSize.GetAttribute("value");

            Assert.AreNotEqual(size, newSize);
        }
        [Test, Order(6)]
        public void CheckIfItemIsElementDisplayed()
        {
            Product product = new Product(driver);

            bool checkIsVisible = product.IsElementDisplayed(product.ButtonSubmit);
            Assert.True(checkIsVisible);
        }
        [Test, Order(7)]
        public void CheckIfItemIsElementEnabled()
        {
            Product product = new Product(driver);

            bool checkIsVisible = product.IsElementEnabled(product.ButtonSubmit);
            Assert.True(checkIsVisible);
        }
        [Test, Order(8)]
        public void CheckIfSubmitCanBeClicked()
        {
            Product product = new Product(driver);

            Actions action = new Actions(driver);
            action
                .Click(product.ButtonSubmit)
                .Build()
                .Perform();
        }
        [Test, Order(9)]
        public void CheckIfButtonProceedToCheckoutCanBeClicked()
        {
            Product product = new Product(driver);
            Thread.Sleep(2000);
            Actions action = new Actions(driver);
            action
                .Click(product.ButtonProceedToCheckout)
                .Build()
                .Perform();
        }
    }
}
