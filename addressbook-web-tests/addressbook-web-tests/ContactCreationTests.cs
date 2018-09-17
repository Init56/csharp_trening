using NUnit.Framework;


namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            naviHelper.OpenHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            contactHelper.ClickAddNewContact();
            ContactData contact = new ContactData("Ivan");
            contact.Middlename = "Ivanov";
            contact.Lastname = "Ivanovich";
            contact.Nickname = "Vanya";
            contactHelper.FillContactName(contact);
            contactHelper.ClickEnter();
        }


    }
}
