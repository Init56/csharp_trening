using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    public class ContactHelper : HelperBase
    {

        public ContactHelper(ApplicationManager manager)
            :base(manager)
        {
        }

        internal void Modify(int index, ContactData contact)
        {
            if (ContactExists == false)
            {
                Create(new ContactData("1", "2", "3", "4"));
            }
            InitContactModification(index);
            FillContactName(contact);
            SubmitContactModification();
        }

        internal ContactHelper Remove()
        {
            if (ContactExists == false)
            {
                Create(new ContactData("1","2","3","4"));                
            }
            SelectContact();
            RemoveContact();
            AcceptRemove();
            return this;
        }
        public ContactHelper Create(ContactData contact)
        {
            ClickAddNewContact();
            FillContactName(contact);
            ClickEnter();
            manager.Navigator.OpenHomePage();
            return this;
        }

        public ContactHelper ClickAddNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactHelper FillContactName(ContactData data)
        {
            Type(By.Name("firstname"), data.Firstname);
            Type(By.Name("middlename"), data.Middlename);
            Type(By.Name("lastname"), data.Lastname);
            Type(By.Name("nickname"), data.Nickname);
            return this;
        }
        private ContactHelper InitContactModification(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + index + "]")).Click();
            return this;
        }
        private ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }
        public ContactHelper AcceptRemove()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }
        public ContactHelper SelectContact()
        {
            driver.FindElement(By.XPath("//input[@name='selected[]']")).Click();
            return this;
        }

        public ContactHelper ClickEnter()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }
        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }
        public bool ContactExists
        {
            get
            {
                if (IsElementPresent(By.Name("entry")))
                { return true; }
                else
                {
                    return false;
                }
            }
        }
        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.GoToGroupsPage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
            foreach (IWebElement element in elements)
            {
                contacts.Add(new ContactData(element.Text));
            }
            return contacts;
        }
    }
}
