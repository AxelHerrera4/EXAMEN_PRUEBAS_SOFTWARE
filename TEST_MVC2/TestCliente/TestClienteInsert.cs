using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

namespace TestCliente
{
    public class TestClienteInsert : IDisposable
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public TestClienteInsert()
        {
            var options = new EdgeOptions();
            options.AddArgument("--ignore-certificate-errors"); 
            driver = new EdgeDriver(options);
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        [Fact]
        public void TestClienteInsertar()
        {
            driver.Navigate().GoToUrl("http://localhost:5192/Cliente/Create");

            var cedula = wait.Until(d => d.FindElement(By.Id("Cedula")));
            cedula.SendKeys("1234567890");

            var apellidos = wait.Until(d => d.FindElement(By.Id("Apellidos")));
            apellidos.SendKeys("Pérez");

            var nombres = wait.Until(d => d.FindElement(By.Id("Nombres")));
            nombres.SendKeys("PEPITO");

            var fechaNacimiento = wait.Until(d => d.FindElement(By.Id("FechaNacimiento")));
            fechaNacimiento.SendKeys("2000-01-01");

            var mail = wait.Until(d => d.FindElement(By.Id("Mail")));
            mail.SendKeys("juan.perez@example.com");

            var telefono = wait.Until(d => d.FindElement(By.Id("Telefono")));
            telefono.SendKeys("0991234567");

            var direccion = wait.Until(d => d.FindElement(By.Id("Direccion")));
            direccion.SendKeys("Calle Falsa 123");

            var estadoDropdown = new SelectElement(driver.FindElement(By.Id("Estado")));
            estadoDropdown.SelectByValue("true");

            var submitButton = wait.Until(d => d.FindElement(By.CssSelector("button[type='submit']")));
            submitButton.Click();

            wait.Until(d => d.Url.Contains("/Cliente"));

            Assert.Contains("/Cliente", driver.Url);
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}
