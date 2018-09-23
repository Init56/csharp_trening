using OpenQA.Selenium;

namespace WebAddressBookTests
{
    public class HelperBase
    {
        public IWebDriver driver;
        public HelperBase(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}