using System;
using System.Threading;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace TestCliente
{
    public class TestClienteEdit : IDisposable
    {
        private IWebDriver driver;

        public TestClienteEdit()
        {
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
        }

        [Fact]
        public void TestClienteEditar()
        {
            driver.Navigate().GoToUrl("http://localhost:5192/Cliente/Edit/6"); 

            Thread.Sleep(1000);

            var apellidos = driver.FindElement(By.Name("Apellidos"));
            apellidos.Clear();
            apellidos.SendKeys("Gómez");

            var nombres = driver.FindElement(By.Name("Nombres"));
            nombres.Clear();
            nombres.SendKeys("Carlos");

            var mail = driver.FindElement(By.Name("Mail"));
            mail.Clear();
            mail.SendKeys("carlos.gomez@example.com");

            var telefono = driver.FindElement(By.Name("Telefono"));
            telefono.Clear();
            telefono.SendKeys("0998765432");

            var direccion = driver.FindElement(By.Name("Direccion"));
            direccion.Clear();
            direccion.SendKeys("Avenida Siempre Viva 742");

            var estado = driver.FindElement(By.Name("Estado"));
            estado.SendKeys("Inactivo");

            // Enviar el formulario
            driver.FindElement(By.CssSelector("button[type='submit']")).Click();

            Thread.Sleep(2000);

            Assert.Equal("http://localhost:5192/Cliente", driver.Url);
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}
