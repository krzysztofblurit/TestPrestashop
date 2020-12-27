using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;
using Test_PrestaShop.PageObjects;
using Test_PrestaShop.Utilities;

namespace Test_PrestaShop.Tests
{
    [TestFixture]
    class OrderTest : BaseTest
    {
        [OneTimeSetUp]
        public void PrepareDataForTests()
        {
            //find my product
            new SearchTest().CheckSearchEngineResultPage("Printed Dress");
            //go to my product
            new SearchTest().CheckIfItemCanBeClicked("Printed Dress");
            //set howmany
            new ProductTest().CheckChangeOfTheValue(3);
            //set size
            new ProductTest().CheckDropDownChooseSize("M");
            //add to cart
            new ProductTest().CheckIfSubmitCanBeClicked();
            //go to order
            Thread.Sleep(2000); //When the automat goes immediately to the Order page, the data is not yet processed to display the contents of the shopping cart.
            new OrderTest().CheckOrdePage();
        }
        [Test, Order(1)]
        public void CheckOrdePage()
        {
            Order checkOut = new Order(driver);
            checkOut.GoToOrder();

            string ActualTitle = driver.Title;
            string ExpectedTitle = "Order - My Store";
            Assert.AreEqual(ExpectedTitle, ActualTitle);
        }

        [Test, Order(2)]
        public void CheckTotalProductsPriceIsNotNull()
        {
            Order checkOut = new Order(driver);
            decimal totalProductsPrice = checkOut.ParsePrice(checkOut.TotalProducts.Text);

            Assert.IsNotNull(totalProductsPrice);
        }
        [Test, Order(3)]
        public void CheckTotalShippingPriceIsNotNull()
        {
            Order checkOut = new Order(driver);
            decimal totalShippingPrice = checkOut.ParsePrice(checkOut.TotalShipping.Text);

            Assert.IsNotNull(totalShippingPrice);
        }
        [Test, Order(4)]
        public void CheckTotalWithoutTaxPriceIsNotNull()
        {
            Order checkOut = new Order(driver);
            decimal totalWithoutTaxPrice = checkOut.ParsePrice(checkOut.TotalPriceWithoutTax.Text);

            Assert.IsNotNull(totalWithoutTaxPrice);
        }
        [Test, Order(5)]
        public void CheckTotalTaxPriceIsNotNull()
        {
            Order checkOut = new Order(driver);
            decimal totalTaxPrice = checkOut.ParsePrice(checkOut.TotalTax.Text);

            Assert.IsNotNull(totalTaxPrice);
        }
        [Test, Order(6)]
        public void CheckTotalPriceIsNotNull()
        {
            Order checkOut = new Order(driver);
            decimal totalPrice = checkOut.ParsePrice(checkOut.TotalPrice.Text);

            Assert.IsNotNull(totalPrice);
        }
        [Test, Order(7)]
        public void CheckUnitPriceIsNotNull()
        {
            Order checkOut = new Order(driver);
            decimal unitPrice = checkOut.ParsePrice(checkOut.UnitPrice.Text);

            Assert.IsNotNull(unitPrice);
        }
        [Test, Order(8)]
        public void CheckQuantity()
        {
            Order checkOut = new Order(driver);
            var quantity = Decimal.Parse(checkOut.Quantity.GetAttribute("value"));

            Assert.IsNotNull(quantity);
        }
        [Test, Order(9)]
        public void CheckTotalPriceIsCorrect()
        {
            Order checkOut = new Order(driver);
            decimal unitPrice = checkOut.ParsePrice(checkOut.UnitPrice.Text);
            var quantity = Decimal.Parse(checkOut.Quantity.GetAttribute("value"));
            decimal totalShippingPrice = checkOut.ParsePrice(checkOut.TotalShipping.Text);
            decimal totalTaxPrice = checkOut.ParsePrice(checkOut.TotalTax.Text);
            decimal totalPrice = checkOut.ParsePrice(checkOut.TotalPrice.Text);

            Assert.AreEqual(totalPrice, unitPrice * quantity + totalShippingPrice + totalTaxPrice);
        }
        [Test, Order(10)]
        public void CheckIfItemIsElementDisplayed()
        {
            Order checkOut = new Order(driver);

            bool checkIsVisible = checkOut.IsElementDisplayed(checkOut.ProceedToCheckout);
            Assert.True(checkIsVisible);
        }
        [Test, Order(11)]
        public void CheckIfItemIsElementEnabled()
        {
            Order checkOut = new Order(driver);

            bool checkIsVisible = checkOut.IsElementEnabled(checkOut.ProceedToCheckout);
            Assert.True(checkIsVisible);
        }
        [Test, Order(12)]
        public void CheckIfSubmitCanBeClicked()
        {
            Order checkOut = new Order(driver);

            Actions action = new Actions(driver);
            action
                .Click(checkOut.ProceedToCheckout)
                .Build()
                .Perform();
        }
    }
}
