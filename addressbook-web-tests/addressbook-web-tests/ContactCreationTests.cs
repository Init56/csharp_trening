using NUnit.Framework;


namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
 

        [Test]
        public void ContactCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            ClickAddNewContact();
            ContactData contact = new ContactData("Ivan");
            contact.Middlename = "Ivanov";
            contact.Lastname = "Ivanovich";
            contact.Nickname = "Vanya";
            FillContactName(contact);
            ClickEnter();
        }


    }
}
