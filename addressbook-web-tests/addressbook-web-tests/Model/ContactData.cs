using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;
using LinqToDB.Mapping;

namespace WebAddressBookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        [Column(Name = "firstname")]
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        [Column(Name = "lastname")]
        public string Lastname { get; set; }
        [Column(Name = "address")]
        public string Address { get; set; }
        [Column(Name = "home")]
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        [Column(Name = "email")]
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string ContactProperty { get; set; }
        private string allEmails;
        private string allPhones;
        private string fullData;
        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }
        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

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
            return "name = " + Firstname + "\nlastName = " + Lastname + "\naddress = " + Address +
                "\nhomePhone = " + HomePhone + "\nemail = " + Email;
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
        [XmlIgnore]
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
        [XmlIgnore]
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
        [XmlIgnore]
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
        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select g).ToList();
            }
        }
    }
}
