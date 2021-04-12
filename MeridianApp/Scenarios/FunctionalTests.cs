using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeridianApp.Scenarios
{
    public class FunctionalTests: TestBase
    {
        [TestCase(ExpectedResult = "")]
        public void Login()
        {
            //Load driver and call Url
            DriverExtension.Goto("");
            //LoadTestData - Read from Excel

            //Perform Page actions
            //Assert
        }
    }
}
