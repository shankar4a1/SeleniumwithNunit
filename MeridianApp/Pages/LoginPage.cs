using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MeridianApp.Pages
{
    public class LoginPage
    {
        DriverExtension driver;
        public LoginPage(DriverExtension driver)
        {
            this.driver = driver;
        }


        [FindsBy(How = How.Id, Using = "LOGIN_USER_NAME")]
        public IWebElement username { get; set; }

        [FindsBy(How = How.Id, Using = "LOGIN_PASSWORD")]
        public IWebElement password { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Login']")]
        public IWebElement loginButton { get; set; }

        public void OpenUrl(string url)
        {
            driver.Goto(url);
        }

        public void EnterUserNameAndPassword(String usernameValue, String passwordValue)
        {
            username.SendKeys(usernameValue);
            Thread.Sleep(5000);
            password.SendKeys(passwordValue);
        }

        public void ClickOnLoginBtn()
        {
            Thread.Sleep(5000);
            loginButton.Click();
        }

    }
}
