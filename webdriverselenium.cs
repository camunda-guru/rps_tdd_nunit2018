using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class Webdriverselenium
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver("E:/software/A08/file/chromedriver_win32");
            baseURL = "http://newtours.demoaut.com/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheWebdriverseleniumTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
            driver.FindElement(By.LinkText("REGISTER")).Click();
            driver.FindElement(By.Name("firstName")).Clear();
            driver.FindElement(By.Name("firstName")).SendKeys("Parameswari");
            driver.FindElement(By.Name("lastName")).Clear();
            driver.FindElement(By.Name("lastName")).SendKeys("Bala");
            driver.FindElement(By.Name("phone")).Clear();
            driver.FindElement(By.Name("phone")).SendKeys("9952032862");
            driver.FindElement(By.Id("userName")).Clear();
            driver.FindElement(By.Id("userName")).SendKeys("Parameswaribala@gmail.com");
            driver.FindElement(By.Name("address1")).Clear();
            driver.FindElement(By.Name("address1")).SendKeys("8d,8the street");
            driver.FindElement(By.Name("city")).Clear();
            driver.FindElement(By.Name("city")).SendKeys("chennai");
            driver.FindElement(By.Name("state")).Clear();
            driver.FindElement(By.Name("state")).SendKeys("TN");
            driver.FindElement(By.Name("postalCode")).Clear();
            driver.FindElement(By.Name("postalCode")).SendKeys("600049");
            new SelectElement(driver.FindElement(By.Name("country"))).SelectByText("INDIA");
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys("eswaribala");
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys("vigneshbala");
            driver.FindElement(By.Name("confirmPassword")).Clear();
            driver.FindElement(By.Name("confirmPassword")).SendKeys("vigneshbala");
            driver.FindElement(By.Name("register")).Click();
            driver.FindElement(By.LinkText("sign-in")).Click();
            driver.FindElement(By.Name("login")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
