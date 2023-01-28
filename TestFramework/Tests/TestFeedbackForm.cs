using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium.Chrome;
using System;
using TestFramework.General;


namespace TestFramework.Tests
{
    [TestFixture(typeof(ChromeDriver))]
    //[TestFixture(typeof(string))]
    //[TestFixture(typeof(FirefoxDriver))]
    [Category("Check the “Order a flower bouquet” form Functionality")]
    class TestFeedbackForm<TBrowser> : TestBase<TBrowser>
    {

        string ValidName = "Test name";
        string InvalidName = "T";
        string InvalidNameLong = "TestNameTestNameTestNameTestName";
        string NameWithDash = "Name-SecondName";

        string ValidEmail = "email@email.com";
        string InvalidEmail = "ab(c)d,e:f;gi[jk]l@example.com";

        string ValidMessage= "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In eu tristique lorem. Duis leo enim, luctus in efficitur in, congue.";
        string InvalidMessage = "їїї";


        [TestOf("FF - 1")]
        [Description("Checking form with valid data")]
        [Test]
        public void CheckFormValidData()
        {
            GF.MoveToElement(FormPage.ButtonOrder);
            GF.ClickOn(FormPage.ButtonOrder);
            FormPage.FillForm(ValidName, ValidEmail,ValidMessage);
            Assert.IsTrue(GF.ExistDisplayed(FormPage.SuccessMessage), "Success message does not appear");
        }

        [TestOf("FF - 2")]
        [Description("Checking form with invalid email")]
        [Test]
        public void CheckFormInvalidEmail()
        {
            GF.MoveToElement(FormPage.FeedbackForm);
            FormPage.FillForm(ValidName, InvalidEmail, ValidMessage);
            Assert.IsTrue(Boolean.Parse(FormPage.FormEmail.GetAttribute("required")), "Email feild error message not appear");
        }

        [TestOf("FF - 3")]
        [Description("Checking form with invalid name that less than 2 symbols")]
        [Test]
        public void CheckFormInvalidName()
        {
            GF.MoveToElement(FormPage.FeedbackForm);
            FormPage.FillForm(InvalidName, ValidEmail, ValidMessage);
            Assert.IsTrue(GF.ExistDisplayed(FormPage.NameErrorMessage), "Name field error message not appear");
        }

        [TestOf("FF - 4")]
        [Description("Checking form invalid message field data")]
        [Test]
        public void CheckFormInvalidMessage()
        {
            GF.MoveToElement(FormPage.FeedbackForm);
            FormPage.FillForm(ValidName, ValidEmail, InvalidMessage);
            Assert.IsTrue(GF.ExistDisplayed(FormPage.FormMessageErrorMessage), "Message field error message not appear");
        }

        [TestOf("FF - 6")]
        [Description("Checking name field and message field error message displayed after correction each of them")]
        [Test]
        public void CheckFewErrorMessages()
        {
            GF.MoveToElement(FormPage.FeedbackForm);
            FormPage.FillForm(InvalidName, ValidEmail, InvalidMessage);
            GF.ExistDisplayed(FormPage.NameErrorMessage);
            FormPage.FillForm(ValidName, ValidEmail, InvalidMessage);
            GF.ExistDisplayed(FormPage.FormMessageErrorMessage);
            FormPage.FillForm(ValidName, ValidEmail, ValidMessage);
            Assert.IsTrue(GF.ExistDisplayed(FormPage.SuccessMessage));
        }

        [TestOf("FF - 7")]
        [Description("Checking form with invalid name that more than 30 symbols")]
        [Test]
        public void CheckFormInvalidNameLong()
        {
            GF.MoveToElement(FormPage.FeedbackForm);
            FormPage.FillForm(InvalidNameLong, ValidEmail, ValidMessage);
            Assert.IsTrue(GF.ExistDisplayed(FormPage.NameErrorMessage), "Name field error message not appear");
        }

        [TestOf("FF - 8")]
        [Description("Check ability to enter names that contains dash character")]
        [Test]
        public void CheckFormNameWithDash()
        {
            GF.MoveToElement(FormPage.FeedbackForm);
            FormPage.FillForm(NameWithDash, ValidEmail, ValidMessage);
            Assert.IsTrue(GF.ExistDisplayed(FormPage.SuccessMessage), "Name field error message not appear");
        }
    }
}
