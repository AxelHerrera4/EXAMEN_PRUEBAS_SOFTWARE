using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.IO;

namespace ReqnrollProject1.Reports
{
    internal class ExtentReportManager
    {
        private static ExtentReports _extent;
        private static ExtentTest _test;
        private static string _reportPath = Path.Combine(Directory.GetCurrentDirectory(), "TestResults", "ExtentReport.html");

        public static void InitReport()
        {
            var sparkReporter = new ExtentSparkReporter(_reportPath);
            _extent = new ExtentReports();
            _extent.AttachReporter(sparkReporter);
        }

        public static void StartTest(string testName)
        {
            _test = _extent.CreateTest(testName);
        }

        public static void LogStep(bool isSuccess, string stepDetails)
        {
            if (isSuccess)
                _test.Log(Status.Pass, stepDetails);
            else
                _test.Log(Status.Fail, stepDetails);
        }

        public static void FlushReport()
        {
            _extent.Flush();
        }
    }
}