﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace addressbook_web_tests.Pages
{
    public class NavigationHelper
    {
        private IWebDriver driver;
        private string baseURL;

        public NavigationHelper(IWebDriver driver, string baseURL) {
            this.driver = driver;
            this.baseURL = baseURL;
        }

        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }

        public void GoToGroupTab()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }
        
        public void ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }
    }
}
