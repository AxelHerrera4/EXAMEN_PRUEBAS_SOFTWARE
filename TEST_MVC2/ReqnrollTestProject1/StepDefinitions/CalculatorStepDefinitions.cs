using TEST_MVC2.Models;
using System;

namespace ReqnrollTestProject.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        private readonly Calculadora _calculadora = new Calculadora();
        private int _result;

        [Given("the first number is {int}")]
        public void GivenTheFirstNumberIs(int number)
        {
            // Asignar el primer número en la calculadora
            _calculadora.FirstNumber = number;
        }

        [Given("the second number is {int}")]
        public void GivenTheSecondNumberIs(int number)
        {
            // Asignar el segundo número en la calculadora
            _calculadora.SecondNumber = number;
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            // Realizar la suma
            _result = _calculadora.Add();
        }

        [Then("the result should be {int}")]
        public void ThenTheResultShouldBe(int expectedResult)
        {
            // Verificar el resultado usando una comparación
            if (_result != expectedResult)
            {
                throw new Exception($"Expected {_result} to be {expectedResult}");
            }

            // O puedes usar un marco de aserción como NUnit o MSTest:
            // Assert.AreEqual(expectedResult, _result);
        }
    }
}
