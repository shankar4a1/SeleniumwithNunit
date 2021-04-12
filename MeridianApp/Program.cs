
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MeridianApp
{
    class Program
    {
        public static void Main(String[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(" https://meridian.commonwealth.int/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            IWebElement username = driver.FindElement(By.XPath("//*[@id='LOGIN_USER_NAME']"));
            username.SendKeys("autex01");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            IWebElement password = driver.FindElement(By.XPath("//*[@id='LOGIN_PASSWORD']"));
            password.SendKeys("Aut0mat10n");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            IWebElement login = driver.FindElement(By.XPath("//input[@value='Login']"));
            login.Click();
            Thread.Sleep(5000);
            IWebElement mainmenu = driver.FindElement(By.Id("LAYOUT_PULLMENU_TRIGGER"));
           IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
           jse.ExecuteScript("arguments[0].click();", mainmenu);
            // driver.FindElement(By.Id("LAYOUT_PULLMENU_TRIGGER")).Click();
            // mainmenu.Click();
            Thread.Sleep(5000);
            IWebElement administation = driver.FindElement(By.XPath("//*[@id='div_multilevelpushmenu']/div/ul/li[8]/a"));
            administation.Click();
            Thread.Sleep(5000);
            IWebElement participant = driver.FindElement(By.XPath("//a[text()='Participant Management']"));
            participant.Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//*[@id='TitleBar']/div/div[2]/div/button")).Click();
            Thread.Sleep(5000);

            // IWebElement user = driver.FindElement(By.XPath("//*[@class='pull - right']/span[4]"));
            // IWebElement user = driver.FindElement(By.XPath(" //*[@id='31B072526256492C8144709AD28327A0']/span[4]"));
            // user.Click();
            // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            // IWebElement logout = driver.FindElement(By.XPath("//a[contains(text(),'Logout')]"));
            // logout.Click();
            driver.FindElement(By.XPath("//label[contains(text(),'Name')]//following-sibling::input")).SendKeys("AUTX_Government of Erehwon");
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//label[contains(text(),'Role')]//following-sibling::input")).SendKeys("Borrower, Guarantor, Creditor");
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//label[contains(text(),'Country of Residence')]//following-sibling::span/select")).SendKeys("Erehwon");
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//label[contains(text(),'Country of Domicile')]//following-sibling::span/select")).SendKeys("Erehwon");
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//label[contains(text(),'Residency')]//following-sibling::span/select")).SendKeys("Erehwon");
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//label[contains(text(),'Category')]//following-sibling::span/select")).SendKeys("Erehwon");
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//label[contains(text(),'Parent Company')]//following-sibling::span/select")).SendKeys("Erehwon");
            Console.WriteLine("succussfully login and logeout");
            

            //*[@id="cd18a6a88fa94630adbe03fbfc16e1e3-1"]/div[2]/div[3]/div[1]/div/div/input

            driver.Close();
        }

    }
}

