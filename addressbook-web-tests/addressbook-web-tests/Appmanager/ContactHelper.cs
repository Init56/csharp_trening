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
            InitContactModification(index);
            FillContactName(contact);
            SubmitContactModification();
        }

        internal ContactHelper Remove()
        {
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
            return this;
        }

        public ContactHelper ClickAddNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactHelper FillContactName(ContactData data)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(data.Firstname);
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(data.Middlename);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(data.Lastname);
            driver.FindElement(By.Name("nickname")).Clear();
            driver.FindElement(By.Name("nickname")).SendKeys(data.Nickname);
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
    }
}
