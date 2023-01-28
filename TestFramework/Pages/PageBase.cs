using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TestFramework.General;

namespace TestFramework.Pages
{
    public class PageBase
    {
        protected static IWebDriver Driver { get => Drivers.dr; }

        protected static int timeLoadPage = 5;

        public string Url;
        public PageBase() { }


        protected static IWebElement WaitElement(By selector, int time = 10)
        {
            WaitPageFullLoaded();
            return GF.WaitElement(Driver, selector, time, new Condition(GF.ExistDisplayedEnabled));
        }
  
        public static void WaitPageFullLoaded()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeLoadPage));

            wait.Until((x) =>
            {
                return ((IJavaScriptExecutor)Driver).ExecuteScript("return document.readyState").Equals("complete");
            });
        }
    }
}
