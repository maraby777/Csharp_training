using System;
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
    [TestFixture]
    public class GroupsCreationTest : TestBase
    {
        [Test]
        public void AddGroup()
        {
            navigator.OpenHomePage();
            loginHelper.Login(new Pages.AccountData("admin", "secret"));
            groupHelper.GoToGroupTab();
            groupHelper.InitGroupCreation();
            groupHelper.FillGroupForm(new Pages.GroupData("name_test " + DateTime.Now, "header_test", "footer_test"));
            groupHelper.Submit();
            navigator.ReturnToGroupsPage();
            loginHelper.Logout();
        }
    }
}
