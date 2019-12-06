using System;
using System.Collections.Generic;
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
            contact.MobilePhone = "111222333";
            contact.Surname = "Surname";
            contact.Email = "test@test.com";

            List<ContactData> oldContactList = app.Contact.GetContactList();

            app.Contact.Create(contact);

            List<ContactData> newContactList = app.Contact.GetContactList();
            oldContactList.Add(contact);
            oldContactList.Sort();
            newContactList.Sort();
            Assert.AreEqual(oldContactList, newContactList);

            app.Navigator.GoToHomePage();

        }

        [Test]
        public void AddEmptyContact()
        {
            ContactData contact = new ContactData();
            contact.Name = "";
            contact.MobilePhone = "";
            contact.Surname = "";
            contact.Email = "";

            List<ContactData> oldContactList = app.Contact.GetContactList();
            app.Navigator.GoToNewContactForm();

            app.Contact.AddNewContact(contact);
            app.Navigator.GoToHomePage();

            List<ContactData> newContactList = app.Contact.GetContactList();
            oldContactList.Add(contact);
            oldContactList.Sort();
            newContactList.Sort();
            Assert.AreEqual(oldContactList, newContactList);
           
        }
    }
}
