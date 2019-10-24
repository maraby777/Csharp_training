using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests.tests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModifictionTests()
        {
            GroupData newData = new GroupData("ModifyName_test " + DateTime.Now);
            newData.Header = null;
            newData.Footer = null;

            app.Groups.Modify(2, newData);
        }

    }
}
