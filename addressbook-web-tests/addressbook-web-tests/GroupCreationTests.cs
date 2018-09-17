using NUnit.Framework;


namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
     
        [Test]
        public void GroupCreationTest()
        {
            naviHelper.OpenHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            GroupData group = new GroupData("1");
            group.GroupHeader = "2";
            group.GroupFooter = "3";
            groupHelper.CreateNewGroup(group);
            naviHelper.ReturnToGroupsPage();
        }
    }
}
