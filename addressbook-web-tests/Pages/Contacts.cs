using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests.Pages 
{
    [TestFixture]
    public class Contacts : TestBase
    {
        [Test]
        public void TheContactTest()
        {
            OpenHomePage();
            Login(new Pages.AccountData("admin", "secret"));
            GoToNewContactForm();
            AddNewContact(new ContactData("Name " + DateTime.Now , "Surname", "test@test.com", "111222333"));
            GoToHomePage();
            Logout();
        }
    }
}
