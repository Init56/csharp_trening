using NUnit.Framework;


namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("Ivan");
            contact.Middlename = "Ivanov";
            contact.Lastname = "Ivanovich";
            contact.Nickname = "Vanya";
            app.Contacts.Create(contact);
        }
        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("");
            contact.Middlename = "";
            contact.Lastname = "";
            contact.Nickname = "";
            app.Contacts.Create(contact);
        }

    }
}
