using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests.tests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void RemoveContactTests()
        {
            app.Contact.Prepare();

            List<ContactData> oldContactList = app.Contact.GetContactList();

            app.Contact.Remove(0);

            List<ContactData> newContactList = app.Contact.GetContactList();

            oldContactList.RemoveAt(0);

            Assert.AreEqual(oldContactList, newContactList);

        }

    }
}
