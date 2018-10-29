using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {

        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string ContactProperty { get; set; }
        private string allEmails;
        private string allPhones;
        private string fullData;

        public ContactData(string firstname, string middlename, string lastname)
        {
            Firstname = firstname;
            Middlename = middlename;
            Lastname = lastname;
        }
        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname && Lastname == other.Lastname;
        }
        public override int GetHashCode()
        {
            return Firstname.GetHashCode() + Lastname.GetHashCode();
        }
        public override string ToString()
        {
            return "Firstname&Middlename = " + Firstname + " " + Lastname;
        }
        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Lastname.CompareTo(other.Lastname) == 0)
            {
                return Firstname.CompareTo(other.Firstname);
            }
            else
            {
                return Lastname.CompareTo(other.Lastname);
            }
        }
        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public ContactData()
        {
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUpEmail(Email) + CleanUpEmail(Email2) + CleanUpEmail(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUpPhone(HomePhone) + CleanUpPhone(MobilePhone) + CleanUpPhone(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }

        }
        public string FullData
        {
            get
            {
                if (fullData != null)
                {
                    return fullData;
                }
                else
                {
                    return ((CleanContactlData(Firstname + " " + Lastname)).Trim() + "\r\n" + CleanContactlData(Address) + "\r\n" +
                        CleanContactlData("H: " + HomePhone) + CleanContactlData("M: " + MobilePhone) + CleanContactlData("W: " + WorkPhone) + "\r\n" +
                        CleanContactlData(Email) + CleanContactlData(Email2) + CleanContactlData(Email3)).Trim();
                }
            }
            set
            {
                fullData = value;
            }
        }
        private string CleanContactlData(string contactData)
        {
            if (contactData == null || contactData == "" || contactData == "H: " || contactData == "M: " || contactData == "W: ")
            {
                return "";
            }
            return contactData + "\r\n";
        }
        private string CleanUpEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return email + "\r\n";
        }
        private string CleanUpPhone(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }
    }
}
