using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WebAddressBookTests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager):base(manager)
        {
        }

        public void Login(AccountData data)
        {
            Type(By.Name("user"), data.Username);
            Type(By.Name("pass"), data.Password);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }
    }
}
