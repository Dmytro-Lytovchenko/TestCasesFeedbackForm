using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using TestFramework.General;

namespace TestFramework
{
    public class Drivers
    {
        public static IWebDriver dr;

        public static string Base { get => "http://spetsr.perfect-sitebank.com/"; }

        /// <summary>
        /// Create driver
        /// </summary>
        /// <param name="browser">ch - create Chrome driver; ch-hd - create Chrome driver headless; fr - create Firefox driver</param>
        public Drivers(string browser)
        {
            ChromeOptions optionsAll = new ChromeOptions();
            optionsAll.AddArgument("--start-maximized");
            optionsAll.AddArgument("--disable-notifications");
            optionsAll.AddArgument("--disable-infobars");

            switch (browser)
            {
                case "ch":
                    dr = new ChromeDriver(optionsAll);
                    break;
                case "ch-hd":
                    optionsAll.AddArgument("--headless");
                    dr = new ChromeDriver(optionsAll);
                    break;
                case "fr":
                    dr = new FirefoxDriver();
                    break;
                default:
                    dr = new ChromeDriver(optionsAll);
                    break;
            }
        }

        public Drivers()
        {
        }


    }
}
