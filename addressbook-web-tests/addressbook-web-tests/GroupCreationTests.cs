using NUnit.Framework;


namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
     
        [Test]
        public void GroupCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GroupData group = new GroupData("1");
            group.GroupHeader = "2";
            group.GroupFooter = "3";
            CreateNewGroup(group);
            ReturnToGroupsPage();
        }
    }
}
