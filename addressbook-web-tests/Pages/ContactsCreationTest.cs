﻿using System;
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
    public class ContactsCreationTest : TestBase
    {
        [Test]
        public void TheContactTest()
        {
            navigator.OpenHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            navigator.GoToNewContactForm();
            contactHelper.AddNewContact(new ContactData("Name " + DateTime.Now , "Surname", "test@test.com", "111222333"));
            navigator.GoToHomePage();
            loginHelper.Logout();
        }

    }
}
