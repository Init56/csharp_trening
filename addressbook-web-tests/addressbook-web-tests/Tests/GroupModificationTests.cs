using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModoficationTest()
        {
            GroupData group = new GroupData("aa");
            group.GroupHeader = "bb";
            group.GroupFooter = "cc";
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldData = oldGroups[0];
            app.Groups.Modify(0, group);
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());
            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].GroupName = group.GroupName;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData gr in newGroups)
            {
                if (gr.Id == oldData.Id)
                {
                    Assert.AreEqual(group.GroupName, gr.GroupName);
                }
            }
        }
    }
}
