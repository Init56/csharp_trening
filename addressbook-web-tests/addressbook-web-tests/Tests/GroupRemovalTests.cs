using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressBookTests 
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {


        [Test]
        public void GroupRemovalTest()
        {

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Remove(1);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count , newGroups.Count-1);
        }

    }
}
