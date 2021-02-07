using Tests_Core.Data_access_layer;
using Tests_Core.Data_access_layer.Commissions;

namespace Tests_Core.Services
{
    public static class GuardService
    {
        public static bool IsValidTradeProperties(Trade trade)
        {
            if (trade is null)
            {
                return false;
            }

            if (trade.OpenPrice <= 0 || trade.ClosePrice <= 0 ||
                trade.Volume == 0 || trade.ContractSize <= 0 ||
                trade.Leverage <= 0 || trade.Commission < 0 || trade.CommissionType is UnknowTradeType)
            {
                return false;
            }

            return true;
        }
    }
}
