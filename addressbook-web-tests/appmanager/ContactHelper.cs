using System;
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

        private bool acceptNextAlert = true;

        public ContactHelper(ApplicationManager manager)
           : base(manager)
        {
            driver = manager.Driver;
        }

        public ContactHelper Remove(int p)
        {
            manager.Navigator.GoToHomePage();
            RemoveContact(p);
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper Modify(int p)
        {
            manager.Navigator.GoToHomePage();
            SelectEdit();
            ModifyContact(p);
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper SelectCheckbox(int index)
        {
            driver.FindElement(By.Id("" + index + "")).Click();
            return this;
        }
        public ContactHelper SelectEdit()
        {
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='test@test.com'])[1]/following::img[2]")).Click();
            return this;
        }

        public ContactHelper ModifyContact(int index)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys("change name " + DateTime.Now);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Notes:'])[1]/following::input[" + index + "]")).Click();
            return this;
        }

        public ContactHelper RemoveContact(int index)
        {

            driver.FindElement(By.Id(""+ index +"")).Click();
            acceptNextAlert = true;
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            return this;
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }

        public ContactHelper AddNewContact(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Name);
            driver.FindElement(By.Name("theform")).Click();
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Surname);
            driver.FindElement(By.Name("theform")).Click();
            driver.FindElement(By.Name("email")).Click();
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys(contact.Email);
            driver.FindElement(By.Name("mobile")).Click();
            driver.FindElement(By.Name("mobile")).Clear();
            driver.FindElement(By.Name("mobile")).SendKeys(contact.Phone);
            driver.FindElement(By.Name("theform")).Click();
            driver.FindElement(By.XPath("//input[21]")).Click();
            return this;
        }

    }
    
}
