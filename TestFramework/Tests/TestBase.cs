using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using TestFramework.Pages;

namespace TestFramework.Tests
{

    public class TestBase<TBrowser>
    {
        public IWebDriver Driver { get => Drivers.dr; }


        [SetUp]
        public void CreateDriver()
        {
            if (typeof(TBrowser) == typeof(ChromeDriver)) { new Drivers("ch"); }

            if (typeof(TBrowser) == typeof(FirefoxDriver)) { new Drivers("fr"); }

            if (typeof(TBrowser) == typeof(string)) { new Drivers("ch-hd"); }

            Driver.Navigate().GoToUrl(Drivers.Base);
        }

        [TearDown]
        public void TeardownTest()
        {
            Driver.Quit();
        }

        public Form FormPage = new Form();
    }
}
