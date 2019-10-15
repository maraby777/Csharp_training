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
    [TestFixture]
    public class GroupsCreationTest : TestBase
    {
        [Test]
        public void AddGroup()
        {
            GroupData group = new GroupData("name_test " + DateTime.Now);
            group.Header = "header_test";
            group.Footer = "footer_test";

            app.Groups.Create(group);
        }


        [Test]
        public void AddEmptyGroup()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            app.Groups.Create(group);
        }
    }

}
