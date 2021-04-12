using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeridianApp
{
    public static class Driver
    {
        public static IWebDriver driver = new ChromeDriver();
    }
}
