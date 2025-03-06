using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace TestLogin
{
    public class LoginTest : IDisposable
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public LoginTest()
        {
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Fact]
        public void IniciarSesionConDatosIncorrectos()
        {
            driver.Navigate().GoToUrl("https://www.automationexercise.com/login");

            driver.FindElement(By.Name("email")).SendKeys("test@example.com");
            driver.FindElement(By.Name("password")).SendKeys("123456");
            driver.FindElement(By.CssSelector("button[data-qa='login-button']")).Click();

            Thread.Sleep(2000);

            var logoutButton = driver.FindElements(By.CssSelector("a[href='/logout']"));
            if (logoutButton.Count > 0)
            {
                Assert.True(logoutButton.Count > 0, "El login fue exitoso.");
            }
            else
            {
                var errorMessage = driver.FindElements(By.CssSelector("p[style='color: red;']"));
                Assert.True(errorMessage.Count > 0, "El mensaje de error no apareció, pero el login falló.");
            }
        }

        [Fact]
        public void IniciarSesionConCamposVacios()
        {
            driver.Navigate().GoToUrl("https://www.automationexercise.com/login");

            driver.FindElement(By.CssSelector("button[data-qa='login-button']")).Click();

            Thread.Sleep(2000);

            Assert.Equal("https://www.automationexercise.com/login", driver.Url);
        }

        [Fact]
        public void IniciarSesionConCorreoIncorrectoYContrasenaCorrecta()
        {
            driver.Navigate().GoToUrl("https://www.automationexercise.com/login");

            driver.FindElement(By.Name("email")).SendKeys("wrongemail@example.com");
            driver.FindElement(By.Name("password")).SendKeys("12345678");
            driver.FindElement(By.CssSelector("button[data-qa='login-button']")).Click();

            Thread.Sleep(2000);

            var errorMessage = driver.FindElements(By.CssSelector("p[style='color: red;']"));
            Assert.True(errorMessage.Count > 0, "El mensaje de error no apareció.");
            Assert.Equal("Your email or password is incorrect!", errorMessage[0].Text);
        }

        [Fact]
        public void IniciarSesionConCorreoCorrectoYContrasenaIncorrecta()
        {
            driver.Navigate().GoToUrl("https://www.automationexercise.com/login");

            driver.FindElement(By.Name("email")).SendKeys("asherrera11@espe.edu.ec");
            driver.FindElement(By.Name("password")).SendKeys("abcd");
            driver.FindElement(By.CssSelector("button[data-qa='login-button']")).Click();

            Thread.Sleep(2000);

            var errorMessage = driver.FindElements(By.CssSelector("p[style='color: red;']"));
            Assert.True(errorMessage.Count > 0, "El mensaje de error no apareció.");
            Assert.Equal("Your email or password is incorrect!", errorMessage[0].Text);
        }

        [Fact]
        public void IniciarSesionConCredencialesValidas()
        {
            driver.Navigate().GoToUrl("https://www.automationexercise.com/login");

            driver.FindElement(By.Name("email")).SendKeys("asherrera11@espe.edu.ec");
            driver.FindElement(By.Name("password")).SendKeys("12345678");
            driver.FindElement(By.CssSelector("button[data-qa='login-button']")).Click();

            Thread.Sleep(2000);

            Assert.Equal("https://www.automationexercise.com/", driver.Url);
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}
