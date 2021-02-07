using NUnit.Framework;
using Tests_Core;
using Tests_Core.Services;

namespace Tests
{
    public class BaseTest
    {
        [OneTimeSetUp]
        public void RunBeforAnyTests()
        {
            ApplicationSettings.TradeCalculatorExePath = TestContext.Parameters["TradeCalculatorExecutableFile"];
            ApplicationSettings.SamplesFolderPath = TestContext.Parameters["SamplesFolder"];
        }

        [TearDown]
        public void RunAfterEachTest()
        {
            ProcessService.Close();
        }
    }
}