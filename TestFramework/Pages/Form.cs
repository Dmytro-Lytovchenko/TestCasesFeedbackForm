using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TestFramework.General;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;



namespace TestFramework.Pages
{
    public class Form : PageBase
    {
        public IWebElement FormName { get => WaitElement(By.XPath("//input[@id='user-name']")); }
        public IWebElement NameErrorMessage { get => WaitElement(By.XPath("//span[@id='user-name_error']")); }
        public IWebElement FormEmail { get => WaitElement(By.XPath("//input[@id='user-email']")); }
        public IWebElement EmailErrorMessage { get => WaitElement(By.XPath("//span[@id='user-email_error']")); }
        public IWebElement FormMessage { get => WaitElement(By.XPath("//textarea[@id='user-message']")); }
        public IWebElement FormMessageErrorMessage { get => WaitElement(By.XPath("//span[@id='user-message_error']")); }
        public IWebElement SuccessMessage { get => WaitElement(By.XPath("//span[@id='message-success']")); }
        public IWebElement FeedbackForm  { get => WaitElement(By.XPath("//div[@class='location-form']")); }
        public IWebElement ButtonSubmit { get => WaitElement(By.XPath("//div//button[@type='submit']")); }
        public IWebElement ButtonOrder { get => WaitElement(By.XPath("//div[@id='navbarCollapse']//a[@class='btn btn-custom']")); }


        public void FillForm(string name, string email, string message, string description = "")
        {
            FormName.Clear();
            FormName.SendKeys(name);
            FormEmail.Clear();
            FormEmail.SendKeys(email);
            FormMessage.Clear();
            FormMessage.SendKeys(message);
            GF.MoveToElement(ButtonSubmit);
            GF.ClickOn(ButtonSubmit);
        }        
    }
}
