﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager)
           : base(manager)
        {
            driver = manager.Driver;
        }

        internal ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitModifyContact(0);

            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone
            };

        }


        private void InitModifyContact(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
        }

        internal ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();

            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                                              .FindElements(By.TagName("td"));

            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones
            };
        }

        #region(check if contact rpesent)
        public void Prepare()
        {
            if (IsContactPresent() != true)
            {
                ContactData contact = new ContactData();
                contact.Name = "Name2 " + DateTime.Now;
                contact.MobilePhone = "1112223332";
                contact.Surname = "Surname2";
                contact.Email = "test@test.com2";

                Create(contact);            }
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();

                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                    ContactData contact = new ContactData(cells[1].Text, cells[2].Text);
                    contactCache.Add(new ContactData(cells[1].Text, cells[2].Text));
                }
            }
            return new List<ContactData>(contactCache);
        }

        public bool IsContactPresent()
        {
            return IsElementPresent(By.Name("selected[]"));
        }
        #endregion

        public ContactHelper Remove(int p)
        {
            manager.Navigator.GoToHomePage();
            SelectEdit(p);
            RemoveContact();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToNewContactForm();
            manager.Contact.AddNewContact(contact);
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper Modify(int p)
        {
            manager.Navigator.GoToHomePage();
            SelectEdit(p);
            ModifyContact();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper SelectCheckbox(int index)
        {
            driver.FindElement(By.Id("" + index + "")).Click();
            return this;
        }
        public ContactHelper SelectEdit(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + index + 1 + "]")).Click();
            return this;
        }

        public ContactHelper ModifyContact()
        {
            Type(By.Name("firstname"), "Name change name ");
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//form[2]//input[2]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper AddNewContact(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Name);
            driver.FindElement(By.Name("theform")).Click();
            Type(By.Name("lastname"), contact.Surname);
            driver.FindElement(By.Name("theform")).Click();
            Type(By.Name("email"), contact.Email);
            Type(By.Name("mobile"), contact.MobilePhone);
            driver.FindElement(By.Name("theform")).Click();
            driver.FindElement(By.XPath("//input[21]")).Click();
            contactCache = null;
            return this;
        }

    }
    
}
