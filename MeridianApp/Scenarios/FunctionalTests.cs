using MeridianApp.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeridianApp.Scenarios
{
    public class FunctionalTests: TestBase
    {
        LoginPage login;
        IWebDriver driver;
        [TestCase(ExpectedResult = "",Category="Regression")]
        public void ApplicationLogin()
        {
            //Load driver and call Url
            driver = new DriverExtension();
            login = new LoginPage(driver.getDriver);
            login.openUrl("");


        }
        
        //LoadTestData - Read from Excel

        //Perform Page actions
        //Assert
    }
    }
}
