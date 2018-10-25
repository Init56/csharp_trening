using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    public class GroupHelper : HelperBase
    {

        public GroupHelper(ApplicationManager manager) 
            : base (manager)
        {
        }
        public GroupHelper Create(GroupData data)
        {
            manager.Navigator.GoToGroupsPage();
            InitNewGroupCreation();
            FillGroupForm(data);
            SubmitGroupCreation();
            manager.Navigator.ReturnToGroupsPage();
            return this;
        }

        private List<GroupData> groupCache = null;  
        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new GroupData(element.Text));
                }
            }

            return new List<GroupData>(groupCache);
        }

        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }

        public GroupHelper Modify(int v, GroupData group)
        {
            manager.Navigator.GoToGroupsPage();

            if (GroupExists == false)
            {
                Create(new GroupData("1", "2", "3"));
            }
            SelectGroup(v);
            InitGroupModification();
            FillGroupForm(group);
            SubmitGroupModification();
            manager.Navigator.ReturnToGroupsPage();
            return this;
        }
        public GroupHelper Remove(int v)
        {
            manager.Navigator.GoToGroupsPage();

            if (GroupExists == false)
            {
                Create(new GroupData("1", "2", "3"));
            }
            SelectGroup(v);
            RemoveGroup();
            manager.Navigator.ReturnToGroupsPage();
            return this;
        } 
        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper FillGroupForm(GroupData data)
        {
            Type(By.Name("group_name"), data.GroupName);
            Type(By.Name("group_header"), data.GroupHeader);
            Type(By.Name("group_footer"), data.GroupFooter);
            return this;
        }
        public GroupHelper InitNewGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }
        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }
        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
        public bool GroupExists
        {
            get
            {
                if (IsElementPresent(By.ClassName("group")))
                { return true; }
                else
                {
                    return false;
                }
            }
        }
    }
}
