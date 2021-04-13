using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeridianApp
{
    public class PageExtension: DriverExtension
    {
        private static IWebDriver webDriver = DriverExtension.getDriver;

        public IEnumerable<IWebElement> FindElements(By by)
        {
            return webDriver.FindElements(by);
        }

        public void NavigateBack()
        {
            webDriver.Navigate().Back();
        }

        public void Refresh()
        {
            webDriver.Navigate().Refresh();
        }

        public void CloseBrowser()
        {
            webDriver.Close();
        }

        public IWebElement FindElement(By by)
        {
            return webDriver.FindElement(by);
        }

        public IOptions Manage()
        {
            return webDriver.Manage();
        }

        public INavigation Navigate()
        {
            return webDriver.Navigate();
        }

        public ITargetLocator SwitchTo()
        {
            return webDriver.SwitchTo();
        }

        public void acceptAlert()
        {
            webDriver.SwitchTo().Alert().Accept();
        }

        public void dismissAlert()
        {
            webDriver.SwitchTo().Alert().Dismiss();
        }

        public String getTextFromAlert()
        {
            return webDriver.SwitchTo().Alert().Text;
        }
    }
}
