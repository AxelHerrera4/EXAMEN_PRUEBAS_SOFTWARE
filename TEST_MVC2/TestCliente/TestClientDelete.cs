using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

namespace TestCliente
{
    public class TestClienteDelete : IDisposable
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public TestClienteDelete()
        {
            var options = new EdgeOptions();
            options.AddArgument("--ignore-certificate-errors"); 
            driver = new EdgeDriver(options);
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        [Fact]
        public void TestClienteEliminar()
        {
            driver.Navigate().GoToUrl("http://localhost:5192/Cliente");

            var deleteButton = wait.Until(d => d.FindElement(By.CssSelector("button[type='submit']")));

            deleteButton.Click();

            var alert = wait.Until(d => d.SwitchTo().Alert());
            alert.Accept(); 

            wait.Until(d => d.Url.Contains("/Cliente"));

            Assert.Contains("/Cliente", driver.Url);
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}
