using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests.tests
{
    [TestFixture]
    public class ContactModifyTests : AuthTestBase
    {
        [Test]
        public void ModifyContactNameTests()
        {
            app.Contact.Prepare();
            
            List<ContactData> oldContactList = app.Contact.GetContactList();

            app.Contact.Modify(0);

            List<ContactData> newContactList = app.Contact.GetContactList();
            oldContactList.Sort();
            newContactList.Sort();
            Assert.AreEqual(oldContactList, newContactList);
        }

    }
}
