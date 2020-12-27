using OpenQA.Selenium;
using System;

namespace Test_PrestaShop.PageObjects
{
    class BasePage
    {
        protected IWebDriver _driver;
        protected static string Url = "http://automationpractice.com/index.php";
        public IWebElement FindItemByTitle(string ItemFromResult) => _driver.FindElement(By.XPath("//a[starts-with(@title, '" + ItemFromResult + "')]"));
        
        public bool IsElementDisplayed(IWebElement element)
        {
            return element.Displayed;
        }
        public bool IsElementNotDisplayed(IWebElement element)
        {
            return element.Displayed;
        }
        public bool IsElementEnabled(IWebElement element)
        {
            return element.Enabled;
        }
        public int TotalSecondsFromDate()
        {
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            return unixTimestamp;        }
    }
}
