using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests.tests
{
    [TestFixture]
    public class ContactsCreationTest : AuthTestBase
    {
        [Test]
        public void AddContact()
        {
            ContactData contact = new ContactData();
            contact.Name = "Name " + DateTime.Now;
            contact.Phone = "111222333";
            contact.Surname = "Surname";
            contact.Email = "test@test.com";

            app.Contact.Create(contact);
           
        }

        [Test]
        public void AddEmptyContact()
        {
            ContactData contact = new ContactData();
            contact.Name = "";
            contact.Phone = "";
            contact.Surname = "";
            contact.Email = "";

            app.Navigator.GoToNewContactForm();
            app.Contact.AddNewContact(contact);
            app.Navigator.GoToHomePage();
           
        }
    }
}
