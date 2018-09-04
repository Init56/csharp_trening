using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    class GroupData
    {
        private string groupName;
        private string groupHeader = "";
        private string groupFooter = "";

        public GroupData(string groupName, string groupHeader, string groupFooter)
        {
            this.groupName = groupName;
            this.groupHeader = groupHeader;
            this.groupFooter = groupFooter;
        }

        public GroupData(string groupName)
            {
            this.groupName = groupName;

        }
        public string GroupName
        {
            get
            {
                return GroupName;
            }
            set
            {
                groupName = value;
            }
        }
        public string GroupHeader
        {
            get
            {
                return groupHeader;
            }
            set
            {
                groupHeader = value;
            }
        }
        public string GroupFooter
        {
            get
            {
                return groupFooter;
            }
            set
            {
                groupFooter = value;
            }
        }
    }
}
