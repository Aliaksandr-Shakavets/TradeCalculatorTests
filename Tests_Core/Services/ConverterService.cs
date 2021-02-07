using System;
using System.Collections.Generic;
using System.Linq;
using Tests_Core.Data_access_layer;
using Tests_Core.Data_access_layer.Calculations;
using Tests_Core.Data_access_layer.Commissions;

namespace Tests_Core.Services
{
    public static class ConverterService
    {
        private readonly static int commandLineErrorIndex = 2;
        private readonly static string errorIndicator = "Several errors occured:";
        private readonly static StringComparison comparison = StringComparison.InvariantCultureIgnoreCase;
        
        public static ICalculationResult ConvertToResult(string commandLineOutput)
        {
            if (string.IsNullOrEmpty(commandLineOutput))
            {
                return new ExceptionResult();
            }

            var splitedOutput = commandLineOutput.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            if (HasError(splitedOutput))
            {
                return new ExceptionResult();
            }

            return ParseToSuccessfulResult(splitedOutput.RemoveWhitespace());
        }

        internal static Trade ConvertCommandLineToTrade(string output)
        {
            output = output.Replace("--", "*");
            var splitedOutput = output.Split(new char[] { '*', }, StringSplitOptions.RemoveEmptyEntries);

            return new Trade()
            {
                OpenPrice = GetPropertyValue(splitedOutput, "open"),
                ClosePrice = GetPropertyValue(splitedOutput, "close"),
                Commission = GetPropertyValue(splitedOutput, "commission"),
                Volume = GetPropertyValue(splitedOutput, "volume"),
                ContractSize = GetPropertyValue(splitedOutput, "contract-size"),
                Leverage = GetPropertyValue(splitedOutput, "leverage"),
                CommissionType = GetCommissionType(splitedOutput)
            };
        }

        public static List<ICalculationResult> ConvertToResults(string processOutput)
        {
            var calculationList = new List<ICalculationResult>();
            var splitedOutput = processOutput.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var output in splitedOutput)
            {
                calculationList.Add(ConvertToResult(string.Concat("\\n \\r", output)));
            }

            return calculationList;
        }

        private static ICommissionType GetCommissionType(string[] splitedOutput)
        {
            var command = splitedOutput.FirstOrDefault(c => c.Contains("commission-type", comparison));
            if (command is null)
            {
                return new PerLot();
            }

            var commissionType = SeparateValue(command.TrimEnd(), ' ').ToLowerInvariant();
            if (CommissionsDefinations.TryGetValue(commissionType, out ICommissionType commission))
            {
                return commission;
            }

            return new UnknowTradeType();
        }

        private static SuccessfulResult ParseToSuccessfulResult(string[] output)
        {
            var profit = GetPropertyValue(output, "profit");
            var margin = GetPropertyValue(output, "margin");
            var commission = GetPropertyValue(output, "commission");

            return new SuccessfulResult(profit, margin, commission);
        }

        /// TODO: needs to modify
        private static decimal GetPropertyValue(string[] commandLine, string property)
        {
            var separator = commandLine.Any(i => i.Contains('=')) ? '=' : ' ';
            var command = commandLine.FirstOrDefault(c => string.Equals(c.Split(separator).First(), property, comparison))?.TrimEnd();
            if (command is null)
            {
                return default;
            }

            var commandValue = SeparateValue(command, separator);

            return commandValue == command ? -1 : decimal.Parse(commandValue);
        }

        private static string SeparateValue(string line, char separator) => line[(line.IndexOf(separator) + 1)..];

        private static bool HasError(string[] splitedOutput) => splitedOutput[commandLineErrorIndex].Equals(errorIndicator);
    }
}
