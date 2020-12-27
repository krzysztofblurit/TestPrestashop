using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Test_PrestaShop.PageObjects;
using Test_PrestaShop.Utilities;

namespace Test_PrestaShop.Tests
{
    [TestFixture]
	class SearchTest : BaseTest
    {
        public static object[] _SourceData =
        {
            new object[] { "Printed Dress" }
        };

        Header search;

        [Test, Order(1), TestCaseSource("_SourceData")]
        public void CheckSearchEngineResultPage(string ItemToSearch)
        {
            Header search = new Header(driver);
            search.GoToHomePage();

            Actions action = new Actions(driver);
            action
                .SendKeys(search.SearchInput, ItemToSearch)
                .SendKeys(Keys.Enter)
                .Build()
                .Perform();

            string ActualTitle = driver.Title;
            string ExpectedTitle = "Search - My Store";
            Assert.AreEqual(ExpectedTitle, ActualTitle);
        }

        [Test, Order(2), TestCaseSource("_SourceData")]
        public void CheckIfItemIsElementDisplayed(string ItemToSearch)
        {
            SearchResult item = new SearchResult(driver);

            bool checkIsVisible = item.IsElementDisplayed(item.FindItemByTitle(ItemToSearch));
            Assert.True(checkIsVisible);
        }
        [Test, Order(3), TestCaseSource("_SourceData")]
        public void CheckIfItemIsElementEnabled(string ItemToSearch)
        {
            SearchResult item = new SearchResult(driver);

            bool checkIsVisible = item.IsElementEnabled(item.FindItemByTitle(ItemToSearch));
            Assert.True(checkIsVisible);
        }
        [Test, Order(4), TestCaseSource("_SourceData")]
        public void CheckIfItemCanBeClicked(string ItemToSearch)
        {
            SearchResult item = new SearchResult(driver);

            Actions action = new Actions(driver);
            action
                .MoveToElement(item.FindItemByTitle(ItemToSearch))
                .Click(item.FindItemByTitle(ItemToSearch))
                .Build()
                .Perform();
        }

    }
}
