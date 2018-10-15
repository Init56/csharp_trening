using NUnit.Framework;
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
            app.Contacts.Modify(1, contact);
        }
    }
}
