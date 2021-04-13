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
        IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement username  => driver.FindElement(By.Id("LOGIN_USER_NAME"));               
        public IWebElement password => driver.FindElement(By.Id("LOGIN_PASSWORD"));
        public IWebElement loginButton => driver.FindElement(By.XPath("//input[@value='Login']"));
               

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
