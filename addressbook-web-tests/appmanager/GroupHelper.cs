﻿using System;
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
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager)
           : base(manager)
        {
            driver = manager.Driver;
        }

        #region(check if group present)
        public void Prepare()
        {
            if (IsGroupPresent() != true)
            {
                GroupData group = new GroupData("new " + DateTime.Now);
                group.Header = "new_header_test";
                group.Footer = "new_footer_test";

                Create(group);
            }
        }

        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }

        private List<GroupData> groupCache = null;

        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();

                manager.Navigator.GoToGroupTab();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new GroupData(element.Text));
                }
            }                        
            return new List<GroupData>(groupCache);
        }

        public bool IsGroupPresent()
        {
            return IsElementPresent(By.Name("selected[]"));
        }
        #endregion

        public GroupHelper Create(GroupData group)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            manager.Navigator.GoToGroupTab();
            InitGroupCreation();
            FillGroupForm(group);
            Submit();
            manager.Navigator.ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Modify(int p, GroupData newData)
        {
            manager.Navigator.GoToGroupTab();
            SelectGroup(p);
            InitGroupModification();
            FillGroupForm(newData);
            Update();
            manager.Navigator.GoToGroupTab();
            return this;
        }

        public GroupHelper Update()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;

        }

        public GroupHelper Remove(int p)
        {
            manager.Navigator.GoToGroupTab();
            SelectGroup(p);
            RemoveGroup();
            manager.Navigator.GoToGroupTab();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        private GroupHelper RemoveGroup()
        {
            driver.FindElement(By.XPath("//body//input[2]")).Click();
            groupCache = null;
            return this;
        }

        private GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//span[" + (index+1) + "]/input")).Click();
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper GoToGroupTab()
        {
            driver.FindElement(By.LinkText("groups")).Click();
            return this;
        }

        public GroupHelper Submit()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }



        public GroupHelper Header()
        {
            return this;
        }

    }
}
