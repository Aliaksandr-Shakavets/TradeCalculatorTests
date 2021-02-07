using NUnit.Framework;
using Tests_Core.Services;
#pragma warning disable S4144

namespace Tests
{
    public class ParseValidTradeOptionsCl : BaseTest
    {
        [Test]
        [TestCase("--open 1.3 --close 1.2 --volume 1.5 --contract-size 100000 --leverage 10")]
        [TestCase("--open 1.2 --close 1.1 --volume 1.5 --contract-size 100000 --leverage 100 --commission 10 --commission-type PerTrade")]
        public void ParseValidTradeFromCommandLine(string args)
        {
            var processOutput = ProcessService.Start(args);
            var expected = CalculationSerivce.Calculate(args);
            var actual = ConverterService.ConvertToResult(processOutput);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("--opEn 1.3 --close 1.2 --volume 1.5 --contract-size 100000 --leverage 10")]
        [TestCase("--open 1.0 --close 1.2 --Volume 1.5 --contract-size 100000 --leverage 10")]
        [TestCase(" --commission-type perTrade --open 1.6 --close 1.1 --volume 1.5 --contract-size 100000 --leverage 100 --commission 10")]
        public void ParseValidTradeFromCommandLine_OptionNameInUppercase(string args)
        {
            var processOutput = ProcessService.Start(args);
            var expected = CalculationSerivce.Calculate(args);
            var actual = ConverterService.ConvertToResult(processOutput);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("--volume 1.3 --close 1.2 --open 1.5 --contract-size 100000 --leverage 10")]
        [TestCase("--open 1.0 --close 1.2 --volume 1.5 --leverage 10 --contract-size 100000")]
        [TestCase("--close 1.5 --volume 1.2 --open 1.5 --contract-size 100000 --leverage 10 --commission 5")]
        [TestCase(" --commission-type PerTrade --open 1.2 --close 1.1 --volume 1.5 --contract-size 100000 --leverage 100 --commission 10")]
        public void ParseValidTradeFromCommandLine_ChangedOptionsPlace(string args)
        {
            var processOutput = ProcessService.Start(args);
            var expected = CalculationSerivce.Calculate(args);
            var actual = ConverterService.ConvertToResult(processOutput);

            Assert.AreEqual(expected, actual);
        }
    }
}