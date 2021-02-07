using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Tests_Core;
using Tests_Core.Data_access_layer.Calculations;
using Tests_Core.Services;

namespace Tests
{
    public class ParseValidTradeOptionsFromFiles: BaseTest
    {
        [Test]
        [TestCase("t1.json")]
        [TestCase("t2.json")]
        [TestCase("t3.json")]
        [TestCase("t4.json")]
        public void ParseValidTradeFromCommandLine(string fileName)
        {
            var filePath = Path.Combine(ApplicationSettings.SamplesFolderPath, fileName);
            var commandLineArgument = string.Concat("-f ", filePath);

            var processOutput = ProcessService.Start(commandLineArgument);
            var expected = CalculationSerivce.Calculate(new FileInfo(filePath));
            var actual = ConverterService.ConvertToResult(processOutput);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("t1.json", "t3.json")]
        [TestCase("t1.json", "t2.json", "t2.json")]
        [TestCase("t1.json", "t2.json", "t3.json", "t4.json")]
        public void ParseValidTradesFromCommandLine(params string[] fileNames)
        {
            var commandLineArguments = new StringBuilder(fileNames.Length);            
            var expected = new List<ICalculationResult>(fileNames.Length);

            for (int i = 0; i < fileNames.Length; i++)
            {
                var commandPrefix = i == 0 ? "-f " : " ";
                var filePath = Path.Combine(ApplicationSettings.SamplesFolderPath, fileNames[i]);
                var commandLineArgument = string.Concat(commandPrefix, filePath);
                expected.Add(CalculationSerivce.Calculate(new FileInfo(filePath)));
                commandLineArguments.Append(commandLineArgument);
            }

            var processOutput = ProcessService.Start(commandLineArguments.ToString());
            var actual = ConverterService.ConvertToResults(processOutput);

            Assert.AreEqual(expected, actual);
        }
    }
}
