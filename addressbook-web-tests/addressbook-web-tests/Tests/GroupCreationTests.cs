using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
     
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("1");
            group.GroupHeader = "2";
            group.GroupFooter = "3";
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(group);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count+1, newGroups.Count);
        }
        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.GroupHeader = "";
            group.GroupFooter = "";
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(group);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);

        }
    }
}
