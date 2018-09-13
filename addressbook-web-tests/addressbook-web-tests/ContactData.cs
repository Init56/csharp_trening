using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    class ContactData
    {
        private string firstname;
        private string middlename;
        private string lastname;
        private string nickname;

        public ContactData(string firstname, string middlename, string lastname, string nickname)
        {
            this.firstname = firstname;
            this.middlename = middlename;
            this.lastname = lastname;
            this.nickname = nickname;
        }

        public ContactData(string firstname)
        {
            this.firstname = firstname;

        }
        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }
        public string Middlename
        {
            get
            {
                return middlename;
            }
            set
            {
                middlename = value;
            }
        }
        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }
        public string Nickname
        {
            get
            {
                return nickname;
            }
            set
            {
                nickname = value;
            }
        }
    }
}
