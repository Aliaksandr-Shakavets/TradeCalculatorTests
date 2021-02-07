using Newtonsoft.Json;
using System.IO;
using Tests_Core.Data_access_layer;
using Tests_Core.Data_access_layer.Calculations;

namespace Tests_Core.Services
{
    public static class CalculationSerivce
    {
        public static ICalculationResult Calculate(Trade currentTrade)
        {
            if (!GuardService.IsValidTradeProperties(currentTrade))
            {
                return new ExceptionResult();
            }

            var profit = (currentTrade.ClosePrice - currentTrade.OpenPrice) * currentTrade.Volume * currentTrade.ContractSize;
            var margin = currentTrade.Volume * currentTrade.ContractSize / currentTrade.Leverage;

            return new SuccessfulResult(profit, margin, currentTrade.GetCommissionByType());
        }

        public static ICalculationResult Calculate(FileInfo file)
        {
            Trade trade;
            using (var sr = new StreamReader(file.FullName))
            {
                var txt = sr.ReadToEnd();
                trade = JsonConvert.DeserializeObject<Trade>(txt);
            }

            return Calculate(trade);
        }

        public static ICalculationResult Calculate(string output) => Calculate(ConverterService.ConvertCommandLineToTrade(output));
    }
}
