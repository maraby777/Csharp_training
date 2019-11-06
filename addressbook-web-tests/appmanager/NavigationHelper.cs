using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace addressbook_web_tests
{ 

    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL)
            : base(manager)
        {
            
            this.baseURL = baseURL;
        }

        public void GoToGroupTab()
        {
            if (driver.Url == baseURL + "/addressbook/group.php"
                && IsElementPresent(By.Name("new")))
            {
                return;
            }

            driver.FindElement(By.LinkText("groups")).Click();
            
        }

        public void ReturnToGroupsPage()
        {
            if (driver.Url == baseURL + "/addressbook/group.php"
                 && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "/addressbook/group.php");
        }

        public void GoToHomePage()
        {
            if (driver.Url == baseURL + "/addressbook/"
                && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "/addressbook/");
        }

        public void GoToNewContactForm()
        {
            if (driver.Url == baseURL + "/addressbook/edit.php"
                && IsElementPresent(By.Name("firstname")))
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "/addressbook/edit.php");

        }
    }
}
