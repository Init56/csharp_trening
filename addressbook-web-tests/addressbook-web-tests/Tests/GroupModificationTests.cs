﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModoficationTest()
        {
            GroupData group = new GroupData("aa");
            group.GroupHeader = "bb";
            group.GroupFooter = "cc";
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData oldData = oldGroups[0];
            app.Groups.Modify(0, group);
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());
            List<GroupData> newGroups = app.Groups.GetGroupList();
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
