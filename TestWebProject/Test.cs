using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace TestWebProject
{
    [TestClass]
    public class Test
    {
        private IWebDriver driver;
        private string baseUrl;


        [TestInitialize]
        public void SetupTest()
        {
            var service = FirefoxDriverService.CreateDefaultService();
            this.driver = new FirefoxDriver(service);
            this.baseUrl = "https://meteo.paraplan.net/";
            //3.1 открыть страницу
            this.driver.Navigate().GoToUrl(this.baseUrl);
            this.driver.FindElement(By.XPath("//a[text()='English']")).Click();
        }

        [TestMethod]
        public void TestClickRef()
        {
            //3.2 нажать на Five-day weather forecast
            this.driver.FindElement(By.XPath("//*[text()='Five-day weather forecast']")).Click();
            //3.3 убедиться что на странице есть текст Five-day weather forecast
            this.driver.FindElement(By.XPath("//span[text()='Five-day weather forecast']"));
            //3.4 убедиться что на страницу есть ссылка Skew-T log-P diagram
            this.driver.FindElement(By.XPath("//a[text()='Skew-T log-P diagram']"));
            //3.5 переходим по ссылке
            this.driver.FindElement(By.XPath("//a[text()='Skew-T log-P diagram']")).Click();
            //3.6 убеждаемся что переход состоялся
            this.driver.FindElement(By.XPath("//link[@href='https://meteo.paraplan.net/en/forecast/saint-petersburg/aerological_diagram/']"));
        }

        [TestCleanup]
        public void CleanUp()
        {
            this.driver.Close();
            this.driver.Quit();
        }
    }
}
