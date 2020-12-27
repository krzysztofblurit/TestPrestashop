using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Drawing;
using System.IO;

namespace Test_PrestaShop.Utilities
{
    class BaseTest
    {
        public static IWebDriver driver;
        [OneTimeSetUp]
        /*        public void BaseSetUp()
                {
                    string USERNAME = "krzysztofadamczy1";
                    string AUTOMATE_KEY = "AkzQaeDbVMi9zzwsui6q";


                    DesiredCapabilities caps = new DesiredCapabilities();

                    caps.SetCapability("os", "Windows");
                    caps.SetCapability("os_version", "10");
                    caps.SetCapability("browser", "Chrome");
                    caps.SetCapability("browser_version", "80");
                    caps.SetCapability("browserstack.user", USERNAME);
                    caps.SetCapability("browserstack.key", AUTOMATE_KEY);
                    caps.SetCapability("name", "krzysztofadamczy1's First Test");

                    driver = new RemoteWebDriver(
                      new Uri("https://hub-cloud.browserstack.com/wd/hub/"), caps
                    );
                }*/
        public void SetUp()
        {
            driver = new ChromeDriver(Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..//..//", "Utilities/")));
            driver.Manage().Window.Size = new Size(1100, 1000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(3000);
        }

        [OneTimeTearDown]
        public void BaseTearDown()
        {
            driver.Close();
        }




    }
}
