namespace ReqnrollTestProject.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        private readonly Calculadora _calculadora = new Calculadora();
        // For additional details on Reqnroll step definitions see https://go.reqnroll.net/doc-stepdef

        private int _result;

        [Given("the first number is {int}")]
        public void GivenTheFirstNumberIs(int number)
        {
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see https://go.reqnroll.net/doc-sharingdata
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 

            _calculadora.FirstNumber = number;  // Fix variable name (FirstNumebr → FirstNumber)
        }

        [Given("the second number is {int}")]
        public void GivenTheSecondNumberIs(int number)
        {
            //TODO: implement arrange (precondition) logic

            _calculadora.SecondNumber = number;  // Fix variable name (SecondNumebr → SecondNumber)
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            //TODO: implement act (action) logic

            _result = _calculadora.Add();
        }

        [Then("the result should be {int}")]
        public void ThenTheResultShouldBe(int result)
        {
            //TODO: implement assert (verification) logic

            _result.CompareTo(result);  // Comparison is valid now
        }
    }
}
