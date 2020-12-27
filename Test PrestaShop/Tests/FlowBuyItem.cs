using NUnit.Framework;
using System.Threading;
using Test_PrestaShop.Utilities;

namespace Test_PrestaShop.Tests
{
    [TestFixture]
    class FlowBuyItem : BaseTest
    {
        public static object[] _SourceData =
        {
            new object[] { "Printed Dress", 3, "M",
                "Krzysztof",
                "Adamczyk",
                "@test.com",
                "12345",
                "11",
                "1",
                "2000",
                "SII",
                "Kolorowa 2",
                "Poznań",
                "Alaska",
                "12345",
                "United States",
                "889889889"}
        };

        [Test, TestCaseSource("_SourceData")]
        public void BuyItem(string ItemToSearch, int howMany, string size, string firstname, string lastname,
                            string email, string password, string choseDay, string chooseMonth, string chooseYear,
                            string company, string companyAdress, string city, string state, string postCode,
                            string country, string phone)
        {
            //find my product
            new SearchTest().CheckSearchEngineResultPage(ItemToSearch);
            //go to my product
            new SearchTest().CheckIfItemCanBeClicked(ItemToSearch);
            //set howmany
            new ProductTest().CheckChangeOfTheValue(howMany);
            //set size
            new ProductTest().CheckDropDownChooseSize(size);
            //add to cart
            new ProductTest().CheckIfSubmitCanBeClicked();
            //go to order
            Thread.Sleep(2000); //When the automat goes immediately to the Order page, the data is not yet processed to display the contents of the shopping cart.
            new OrderTest().CheckOrdePage();
            //check price
            new OrderTest().CheckTotalPriceIsCorrect();
            //proceed to checkout
            new OrderTest().CheckIfSubmitCanBeClicked();
            //register account
            new SignInTest().RegisterAccount(firstname, lastname, email, password, choseDay, chooseMonth, chooseYear,
                                             company, companyAdress, city, state, postCode, country, phone);
        }
    }
}
