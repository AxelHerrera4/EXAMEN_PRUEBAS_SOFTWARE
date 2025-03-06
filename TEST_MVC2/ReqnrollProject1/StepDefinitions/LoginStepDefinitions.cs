using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using Reqnroll;
using ReqnrollProject1.Utilities;

namespace ReqnrollProject1.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        private IWebDriver _driver;
        private static ExtentReports _extent;
        private static ExtentTest _test;
        private readonly ScenarioContext _scenarioContext;
        
        public LoginStepDefinitions( ScenarioContext scenarioContext) 
        {
            _scenarioContext = scenarioContext;

        }
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var spartReporter = new ExtentSparkReporter("ExtentReport.html");
            _extent = new ExtentReports();
            _extent.AttachReporter(spartReporter);

        }
        [BeforeScenario]
        public void BeforeScenario() 
        {
            _driver = WebDriverManager.GetDriver("Edge");
            _test = _extent.CreateTest(_scenarioContext.ScenarioInfo.Title);
        }


        [Given("que el usuario esta en la pagina del login")]
        public void GivenQueElUsuarioEstaEnLaPaginaDelLogin()
        {
           _driver.Navigate().GoToUrl("https://www.automationexercise.com/login");
            _test.Log(Status.Pass, "Usuario navega a la pagina del login");

        }

        [When("ingresa el correo {string} y la contraseña {string}")]
        public void WhenIngresaElCorreoYLaContrasena(string email, string password)
        {
            _driver.FindElement(By.Name("email")).SendKeys(email);
            _driver.FindElement(By.Name("password")).SendKeys(password);
            _test.Log(Status.Info, $"Usuario ingresa el correo : {email} y contraseña {password}");
        }

        [When("hacer click en el boton de inicio de sesion")]
        public void WhenHacerClickEnElBotonDeInicioDeSesion()
        {
           
            try
            {
                bool isLoggedIn = _driver.FindElement(By.ClassName("user-info")) != null;
                _test.Log(Status.Pass, "Inicio de sesion exitoso");
            }
            catch (NoSuchElementException)
            {
                _test.Log(Status.Fail, "Error en inicio de sesión");
                
            }
            _driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }

        [Then("deberia ver un mensaje de error")]
        public void ThenDeberiaVerUnMensajeDeError()
        {
            try
            {
                bool isError = _driver.FindElement(By.ClassName("login_error")) != null;
                _test.Log(Status.Pass, "Mensaje de error mostrado correctamente");
            }
            catch (NoSuchElementException)
            {
                _test.Log(Status.Fail, "No se mostro el mensaje de error");

            }
        }
        [AfterScenario]
        public void Down()
        {
            _driver.Quit();
            _extent.Flush();
        }
    }
}
