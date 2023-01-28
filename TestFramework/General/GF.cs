using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace TestFramework.General
{
    public delegate IWebElement Condition(IWebElement element);
    internal class GF
    {
        protected static IWebDriver Driver { get => Drivers.dr; }

        public static IWebElement WaitElement(IWebDriver driver, By selector, int timeSeconds, Condition cnd)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeSeconds));
            return wait.Until((x) =>
            {
                IWebElement element = driver.FindElement(selector);
                return cnd(element);
            });
        }

        public static IWebElement ExistDisplayedEnabled(IWebElement element)
        {
            return (element != null && element.Displayed && element.Enabled) ? element : null;
        }

        public static bool ExistDisplayed(IWebElement element)
        {        
            return element != null && element.Displayed;
        }

        public static bool IsNotDisplayed(IWebElement element)
        {
            try
            {
               return element.Displayed;
            }
            catch (Exception ex)
            {
                return true;
            }
        }

        public static void ClickOn(IWebElement element, string description = "",int timeToWait=8)
        {
            WaitForClickabilityOfElement(element, timeToWait);
            element.Click();
        }

        public static void WaitForClickabilityOfElement(IWebElement element, long timeToWait = 10)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeToWait));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public static void MoveToElement(IWebElement element, string description = "")
        {
            Actions actions = new Actions(Driver);
            actions.MoveToElement(element).Build().Perform();
        }

    }
}