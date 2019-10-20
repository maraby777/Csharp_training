using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests.tests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]

        public void GroupModifictionTests()
        {
            GroupData newData = new GroupData("ModifyName_test " + DateTime.Now);
            newData.Header = "headerModyfy_test";
            newData.Footer = "footerModufy_test";

            app.Groups.Modify(1, newData);
        }
    }
}
