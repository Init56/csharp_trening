using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            //prepare
            app.Auth.Logout();
            //action
            AccountData acc = new AccountData("admin", "secret");
            app.Auth.Login(acc);
            //verification
            Assert.IsTrue(app.Auth.IsLoggedIn(acc));
        }
        [Test]
        public void LoginWithInValidCredentials()
        {
            //prepare
            app.Auth.Logout();
            //action
            AccountData acc = new AccountData("admin", "123");
            app.Auth.Login(acc);
            //verification
            Assert.IsFalse(app.Auth.IsLoggedIn(acc));
        }
    }
}
