﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeridianApp
{
    public class DriverExtension
    {
        private  IWebDriver driver;
        private static string browser = ConfigurationManager.AppSettings["browser"];

        public void Init()
        {

            var options = new ChromeOptions();
            options.AddArgument("no-sandbox");
            switch (browser.ToUpper())
            {
                case "CHROME":
                    driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(3));
                    break;
            }
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
        }
        
        public  IWebDriver getDriver
        {
            get { return driver; }
        }
        public  void SetImplicitTimeout(int seconds=15)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }

        public  void Goto(string url)
        {
            driver.Url = url;
        }
        public  void Close()
        {
            driver.Quit();
        }
    }
}
