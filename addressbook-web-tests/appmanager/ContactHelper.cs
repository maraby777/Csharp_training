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

        public ContactHelper Remove(int p)
        {
            manager.Navigator.GoToHomePage();
            SelectEdit(p);
            RemoveContact();
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
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + index + "]")).Click();
            return this;
        }

        public ContactHelper ModifyContact()
        {
            Type(By.Name("firstname"), "change name " + DateTime.Now);
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//form[2]//input[2]")).Click();
            return this;
        }

        public ContactHelper AddNewContact(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Name);
            driver.FindElement(By.Name("theform")).Click();
            Type(By.Name("lastname"), contact.Surname);
            driver.FindElement(By.Name("theform")).Click();
            Type(By.Name("email"), contact.Email);
            Type(By.Name("mobile"), contact.Phone);
            driver.FindElement(By.Name("theform")).Click();
            driver.FindElement(By.XPath("//input[21]")).Click();
            return this;
        }

    }
    
}
