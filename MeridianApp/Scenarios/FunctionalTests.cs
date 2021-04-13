using MeridianApp.Pages;
using MeridianApp.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeridianApp.Scenarios
{
    public class FunctionalTests: TestBase
    {
        LoginPage loginPage;
        [TestCase(Category="Regression")]
        public void ApplicationLogin()
        {
            //Load driver and call Url
            DriverExtension.getDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            DriverExtension.Goto(ConfigurationManager.AppSettings["loginUrl"]);
            DriverExtension.getDriver.Manage().Window.Maximize();

            //LoadTestData - Read from Excel
            InputReader inputReader = new InputReader();
            var participant = inputReader.Read(1);

            //Perform Page actions
            loginPage = new LoginPage(DriverExtension.getDriver);
            loginPage.EnterUserNameAndPassword(ConfigurationManager.AppSettings["userName"], ConfigurationManager.AppSettings["password"]);
            loginPage.ClickOnLoginBtn();
            //Assert

        }    
    }
}
