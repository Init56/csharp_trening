using System;
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
            app.Groups.Modify(1, group);
        }
    }
}
