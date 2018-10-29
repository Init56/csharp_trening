using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {

        public string GroupName { get; set; }
        public string GroupHeader { get; set; } = "";
        public string GroupFooter { get; set; } = "";
        public string Id { get; set; }

        public GroupData(string groupName, string groupHeader, string groupFooter)
        {
            GroupName = groupName;
            GroupHeader = groupHeader;
            GroupFooter = groupFooter;
        }
        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return GroupName == other.GroupName;
        }

        public override int GetHashCode()
        {
            return GroupName.GetHashCode();
        }

        public override string ToString()
        {
            return "name = " + GroupName + "\nheader = " + GroupHeader + "\nfooter = " + GroupFooter;
        }
        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return GroupName.CompareTo(other.GroupName);
        }
        public GroupData(string groupName)
        {
            this.GroupName = groupName;
        }

    }
}
