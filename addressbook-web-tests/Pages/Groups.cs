using System;
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
    public class Groups : TestBase
    {
        [Test]
        public void AddGroup()
        {
            OpenHomePage();
            Login(new Pages.AccountData("admin", "secret"));
            GoToGroupTab();
            InitGroupCreation();
            FillGroupForm(new Pages.GroupData("name_test " + DateTime.Now, "header_test", "footer_test"));
            Submit();
            ReturnToGroupsPage();
            Logout();
        }
    }
}
