using NUnit.Framework;


namespace WebAddressBookTests 
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {


        [Test]
        public void GroupRemovalTest()
        {
            naviHelper.OpenHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            naviHelper.GoToGroupsPage();
            groupHelper.SelectGroup(1);
            groupHelper.RemoveGroup();
            naviHelper.ReturnToGroupsPage();
        }

    }
}
