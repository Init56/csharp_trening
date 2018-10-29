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
            ContactData contact = new ContactData("Vasiliy", "Vasilievich");
            contact.Middlename = "Vasiliev";
            if (app.Contacts.ContactExists == false)
            {
                app.Contacts.Create(new ContactData("1", "2", "3"));
            }
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Modify(0, contact);
            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].Firstname = contact.Firstname;
            oldContacts[0].Lastname = contact.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
