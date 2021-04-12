
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeridianApp
{
    [TestFixture]
    public class TestBase: DriverExtension
    {
        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            //RunLevel SetUps to be done here
        }
        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            //RunLevel Teardowns to be done here
        }
        [SetUp]
        public static void BeforTest()
        {
            try
            {
                DriverExtension.Init();
            }
            catch (Exception e)
            {
                throw (e);
            }
        }
        [TearDown]
        public static void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var testMethod = TestContext.CurrentContext.Test.FullName;
            if (status == TestStatus.Failed)
            {
                var errorMessage = TestContext.CurrentContext.Result.Message;
                Console.WriteLine("Error in Test: " + errorMessage);
            }

            DriverExtension.Close();
        }
    }
}
