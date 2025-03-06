using Reqnroll;
using ReqnrollProject1.Reports;

namespace ReqnrollProject1.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ExtentReportManager.InitReport();
        }

        [BeforeScenario]
        public void BeforeScenario(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            ExtentReportManager.StartTest($"{featureContext.FeatureInfo.Title} - {scenarioContext.ScenarioInfo.Title}");
        }

        [AfterStep]
        public static void AfterStep(ScenarioContext scenarioContext)
        {
            var stepInfo = scenarioContext.StepContext.StepInfo.Text;
            bool isSuccess = scenarioContext.TestError == null;
            ExtentReportManager.LogStep(isSuccess, isSuccess ? $"Paso exitoso: {stepInfo}" : $"Error: {scenarioContext.TestError.Message}");
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            ExtentReportManager.FlushReport();
        }
    }
}