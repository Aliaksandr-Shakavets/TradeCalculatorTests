using NUnit.Framework;
using Tests_Core.Data_access_layer.Calculations;
using Tests_Core.Services;
#pragma warning disable S4144

namespace Tests
{
    public class TryToParseUnvalidTradeOptionsCl : BaseTest
    {
        [Test]
        [TestCase("--open -1.3 --close 1.2 --volume 1.5 --contract-size 100000 --leverage 10")]
        [TestCase("--open 1 --close 0 --volume 1.5 --contract-size 100000 --leverage 100 --commission 10")]
        [TestCase("--open s --close 1.1--volume 1.5 --contract-size 100000 --leverage 100 --commission 10")]
        [TestCase("--open 1 --close 1.2 --volume 1.5 --contract-size -1 --leverage 100 --commission 10")]
        [TestCase("--open 1 --close 1.3 --volume 1.5 --contract-size 100000 --leverage 0 --commission 10")]
        [TestCase("--open 1 --close 1.4 --volume 1.5 --contract-size 100000 --leverage 100 --commission -1")]
        [TestCase("--open 1 --close 1.5 --volume 1.5 --contract-size 100000 --leverage 100 --commission 10 --commission-type NothingElseMatters")]
        public void ParseTrade_UnvalidOptionsValue(string args)
        {
            var processOutput = ProcessService.Start(args);
            var actual = ConverterService.ConvertToResult(processOutput);

            Assert.IsAssignableFrom<ExceptionResult>(actual);
        }

        [Test]
        [TestCase("--opn 1.3 --close 1.2 --volume 1.5 --contract-size 100000 --leverage 10")]
        [TestCase("--open 1.0 --closee 1.2 --Volume 1.5 --contract-size 100000 --leverage 10")]
        [TestCase(" --commissions*type perTrade --open 1.6 --close 1.1 --volume 1.5 --contract-size 100000 --leverage 100 --commission 10")]
        public void ParseTrade_UnvalidOptionsName(string args)
        {
            var processOutput = ProcessService.Start(args);
            var actual = ConverterService.ConvertToResult(processOutput);

            Assert.IsAssignableFrom<ExceptionResult>(actual);
        }
    }
}
