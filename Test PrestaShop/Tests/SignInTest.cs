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
    class SignInTest : BaseTest
    {
        [Test, Order(1)]
        public void CheckSignInPage()
        {
            SignIn create = new SignIn(driver);
            create.GoToSignIn();

            string ActualTitle = driver.Title;
            string ExpectedTitle = "Login - My Store";
            Assert.AreEqual(ExpectedTitle, ActualTitle);
        }

        private static object[] _WrongEmails =
        {
            new object[] { " " },
            new object[] { "1234567890" },
            new object[] { "qwertyui" },
            new object[] { "!@#$%^&" },
            new object[] { "hcbjcjhb@djjdjdj" },
            new object[] { "ŁÓĄŻĆa" },
            new object[] { "gvsgsv@ jdnjnd.pl" }
        };

        [Test, Order(2), TestCaseSource("_WrongEmails")]
        public void CheckInvalidEmails(string email)
        {
            SignIn create = new SignIn(driver);
            create.GoToSignIn();

            Actions action = new Actions(driver);
            action
                .DoubleClick()
                .SendKeys(Keys.Delete)
                .SendKeys(create.EmailInput, email)
                .SendKeys(Keys.Enter)
                .Build()
                .Perform();

            Thread.Sleep(2000);
            bool checkIsVisible = create.IsElementDisplayed(create.CreateAccountErrorAlert);
            Assert.True(checkIsVisible);
        }
        private static object[] _CorrectEmails =
        {
            new object[] { "sihbiosdb9u@b4b4c9bc9b.com" }
        };
        [Test, Order(3), TestCaseSource("_CorrectEmails")]
        public void CheckValidEmails(string email)
        {
            SignIn create = new SignIn(driver);
            create.GoToSignIn();

            Actions action = new Actions(driver);
            action
                .DoubleClick()
                .SendKeys(Keys.Delete)
                .SendKeys(create.EmailInput, email)
                .SendKeys(Keys.Enter)
                .Build()
                .Perform();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            bool checkIsVisible = create.IsElementDisplayed(create.FirstNameInput);
            Assert.True(checkIsVisible);
        }

        private static object[] _InvalidFirstNameAndLastName =
        {
            new object[] { "123" },
            new object[] { "!" },
            new object[] { "!@#$%^&" },
            new object[] { "hcbjcjhb@djjdjdj" },
        };

        [Test, Order(4), TestCaseSource("_InvalidFirstNameAndLastName")]
        public void CheckInvalidFirstName(string firstname)
        {
            SignIn create = new SignIn(driver);
            create.GoToSignIn();

            CheckValidEmails("test123@test321.com");

            Actions action = new Actions(driver);
            action
                .DoubleClick()
                .SendKeys(Keys.Delete)
                .SendKeys(create.FirstNameInput, firstname)
                .SendKeys(Keys.Enter)
                .Build()
                .Perform();
            Thread.Sleep(2000);
            bool checkIsVisible = create.IsElementDisplayed(create.FirstNameInputAlert);
            Assert.True(checkIsVisible);
        }

        [Test, Order(5), TestCaseSource("_InvalidFirstNameAndLastName")]
        public void CheckInvalidLastName(string lastname)
        {
            SignIn create = new SignIn(driver);
            create.GoToSignIn();

            CheckValidEmails("test123@test321.com");

            Actions action = new Actions(driver);
            action
                .DoubleClick()
                .SendKeys(Keys.Delete)
                .SendKeys(create.LastNameInput, lastname)
                .SendKeys(Keys.Enter)
                .Build()
                .Perform();
            Thread.Sleep(2000);
            bool checkIsVisible = create.IsElementDisplayed(create.LastNameInputAlert);
            Assert.True(checkIsVisible);
        }
        private static object[] _AccountData =
        {
            new object[] { "Krzysztof", 
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
                "889889889"

            }
        };

        [Test, Order(6), TestCaseSource("_AccountData")]
        public void RegisterAccount(
            string firstname,
            string lastname,
            string email,
            string password,
            string choseDay,
            string chooseMonth,
            string chooseYear,
            string company,
            string companyAdress,
            string city,
            string state,
            string postCode,
            string country,
            string phone
            )
        {
            SignIn create = new SignIn(driver);
            //create.GoToSignIn();
            CheckValidEmails(create.TotalSecondsFromDate() + email);
            create.FieldEntry(driver, create.FirstNameInput, firstname);
            create.FieldEntry(driver, create.LastNameInput, lastname);
            create.FieldEntry(driver, create.PasswordInput, password);
            new SelectElement(create.DateDaySelect).SelectByValue(choseDay);
            new SelectElement(create.DateMonthSelect).SelectByValue(chooseMonth);
            new SelectElement(create.DateYearSelect).SelectByValue(chooseYear);
            create.NewsletterCheckbox.Click();
            create.FieldEntry(driver, create.FirstNameAdressInput, firstname);
            create.FieldEntry(driver, create.LastNameAdressInput, lastname);
            create.FieldEntry(driver, create.CompanyInput, company);
            create.FieldEntry(driver, create.CompanyAdressInput, companyAdress);
            create.FieldEntry(driver, create.CityAdressInput, city);
            new SelectElement(create.StateAdressInput).SelectByText(state);
            create.FieldEntry(driver, create.PostCodeAdressInput, postCode);
            new SelectElement(create.CountryAdressInput).SelectByText(country);
            create.FieldEntry(driver, create.MobilePhoneAdressInput, phone);
            create.RegisterButton.Click();
        }

    }
}
