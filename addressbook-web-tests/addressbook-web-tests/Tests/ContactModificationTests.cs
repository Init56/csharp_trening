﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    [TestFixture]
    class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData contact = new ContactData("Vasiliy");
            contact.Middlename = "Vasiliev";
            contact.Lastname = "Vasilievich";
            contact.Nickname = "Vasya";
            if (app.Contacts.ContactExists == false)
            {
                app.Contacts.Create(new ContactData("1", "2", "3", "4"));
            }
            app.Contacts.Modify(1, contact);
        }
    }
}
