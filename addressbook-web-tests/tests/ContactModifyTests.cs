﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests.tests
{
    [TestFixture]
    public class ContactModifyTests : TestBase
    {
        [Test]
        public void ModifyContactNameTests()
        {

            app.Contact.Modify(1);

        }

    }
}
