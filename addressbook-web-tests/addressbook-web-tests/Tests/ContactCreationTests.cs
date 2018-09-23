using NUnit.Framework;


namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Contacts.ClickAddNewContact();
            ContactData contact = new ContactData("Ivan");
            contact.Middlename = "Ivanov";
            contact.Lastname = "Ivanovich";
            contact.Nickname = "Vanya";
            app.Contacts.FillContactName(contact);
            app.Contacts.ClickEnter();
        }


    }
}
