using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;

namespace Test_PrestaShop.PageObjects
{
    class SignIn : BasePage
    {
        public SignIn(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }
        protected static string SignInUrl = "http://automationpractice.com/index.php?controller=authentication&back=my-account";
        public IWebElement EmailInput => _driver.FindElement(By.Name("email_create"));
        public IWebElement CreateAnAccountButton => _driver.FindElement(By.Id("SubmitCreate"));
        public IWebElement CreateAccountErrorAlert => _driver.FindElement(By.Id("create_account_error"));
        public IWebElement SubmitButton => _driver.FindElement(By.LinkText("Register"));

        //form
        //Title
        public IWebElement TitleMrRadio => _driver.FindElement(By.Id("uniform-id_gender1"));
        public IWebElement TitleMrsRadio => _driver.FindElement(By.Id("uniform-id_gender2"));
        //personal data
        public IWebElement FirstNameInput => _driver.FindElement(By.Id("customer_firstname"));
        public IWebElement FirstNameInputAlert => _driver.FindElement(By.XPath("//*[@class='alert alert-danger']//*[contains(text(),'firstname')]"));
        public IWebElement LastNameInput => _driver.FindElement(By.Id("customer_lastname"));
        public IWebElement LastNameInputAlert => _driver.FindElement(By.XPath("//*[@class='alert alert-danger']//*[contains(text(),'lastname')]"));
        public IWebElement PasswordInput => _driver.FindElement(By.Id("passwd"));
        //Date of Birth
        public IWebElement DateDaySelect => _driver.FindElement(By.Id("days"));
        public IWebElement DateMonthSelect => _driver.FindElement(By.Id("months"));
        public IWebElement DateYearSelect => _driver.FindElement(By.Id("years"));
        //checkbox
        public IWebElement NewsletterCheckbox => _driver.FindElement(By.Id("newsletter"));
        public IWebElement SpamCheckbox => _driver.FindElement(By.Id("optin"));
        //adress
        public IWebElement FirstNameAdressInput => _driver.FindElement(By.Id("firstname"));
        public IWebElement LastNameAdressInput => _driver.FindElement(By.Id("lastname"));
        public IWebElement CompanyInput => _driver.FindElement(By.Id("company"));
        public IWebElement CompanyAdressInput => _driver.FindElement(By.Id("address1"));
        public IWebElement CityAdressInput => _driver.FindElement(By.Id("city"));
        public IWebElement StateAdressInput => _driver.FindElement(By.Id("id_state"));
        public IWebElement PostCodeAdressInput => _driver.FindElement(By.Id("postcode"));
        public IWebElement CountryAdressInput => _driver.FindElement(By.Id("id_country"));
        public IWebElement MobilePhoneAdressInput => _driver.FindElement(By.Id("phone_mobile"));

        public IWebElement RegisterButton => _driver.FindElement(By.Id("submitAccount"));

        public SignIn GoToSignIn()
        {
            _driver.Navigate().GoToUrl(SignInUrl);
            return this;
        }
        public SignIn FieldEntry(IWebDriver driver, IWebElement element, string value)
        {
            Actions action = new Actions(driver);
            action
                .DoubleClick(element)
                .SendKeys(Keys.Delete)
                .SendKeys(element, value)
                .Build()
                .Perform();
            return this;
        }
    }
}
