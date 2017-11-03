using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System.IO;
using OpenQA.Selenium.Safari;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Selenium
{
    [TestClass]
    public class TestCalc
    {
        static IWebDriver driver;

        [ClassInitialize]
        public static void ClassSetUp(TestContext context)
        {
            driver = new ChromeDriver();

           /* //OperaOptions srv = new OperaOptions();
            //srv.BinaryLocation = @"C:\Program Files\Opera\launcher.exe";
            //driver = new OperaDriver(srv);

            //FirefoxOptions ffOptions = new FirefoxOptions();
            //ffOptions.BrowserExecutableLocation = @"C:\Program Files\Mozilla Firefox\firefox.exe";            
            //driver = new FirefoxDriver(ffOptions);

            //driver = new EdgeDriver();

            //driver = new InternetExplorerDriver();

            //driver = new SafariDriver();

            //driver.Navigate().GoToUrl("file:///C:/my%20stuff/ORT%20courses/Homeworks/jsCalcBtn/CalcBtn.html");*/
            driver.Navigate().GoToUrl("file:///C:/my%20stuff/ORT%20courses/Homeworks/jsCalcFields/CalcFields.html");
        }

        [ClassCleanup]
        public static void ClassTeardown()
        {
            driver.Quit();
        }

        [TestInitialize]
        public void SetUp()
        {
            driver.Navigate().Refresh();
        }


        [DataTestMethod]
        [DataRow("aTxt", true)]
        [DataRow("bTxt", true)]
        [DataRow("oTxt", true)]
        [DataRow("resTxt", true)]
        [DataRow("btnCalc", true)]


        [TestMethod]
        public void TestIsPresent(string id, bool exp)
        {
            bool actual = driver.FindElement(By.Id(id)).Displayed;
            Assert.AreEqual(exp, actual);
        }

        [DataTestMethod]
        [DataRow("aTxt", "0", "0")]
        [DataRow("bTxt", "1", "1")]
        [DataRow("oTxt", "+", "+")]


        [TestMethod]
        public void TestSimpleTest(string id, string key, string exp)
        {
            driver.FindElement(By.Id(id)).SendKeys(key);
            string actual = driver.FindElement(By.Id(id)).GetAttribute("value");
            Assert.AreEqual(exp, actual);
        }

        [DataTestMethod]
        [DataRow("aTxt", "12345", "12345")]
        [DataRow("bTxt", "12345", "12345")]
        [DataRow("oTxt", "+-*/", "+-*/")]


        public void TestComplexTest(string id, string key, string exp)
        {
            driver.FindElement(By.Id(id)).SendKeys(key);
            string actual = driver.FindElement(By.Id(id)).GetAttribute("value");
            Assert.AreEqual(exp, actual);
        }

        [DataTestMethod]
        [DataRow("12", "+", "5", "17")]
        [DataRow("12", "-", "5", "7")]
        [DataRow("3", "*", "5", "15")]
        [DataRow("8", "/", "2", "4")]


        [TestMethod]
        public void TestRealJob(string keyA, string keyO, string keyB, string exp)
        {
            driver.FindElement(By.Id("aTxt")).SendKeys(keyA);
            driver.FindElement(By.Id("oTxt")).SendKeys(keyO);
            driver.FindElement(By.Id("bTxt")).SendKeys(keyB);
            driver.FindElement(By.Id("btnCalc")).Click();
            string actual = driver.FindElement(By.Id("resTxt")).GetAttribute("value");
            Assert.AreEqual(exp, actual);
        }

        //[TestMethod]
        //public void TestJsCalc()
        //{
        //    var script = new TestScript();
        //    script.AppendFile(@"C:\my stuff\ORT courses\Homeworks\jsCalcFields\main.js");
        //    script.AppendBlock(new JsAssertLibrary());

        //    script.RunTest(@"assert.equal(5, calc(2,3,'+'))");
        //}
    }
}
