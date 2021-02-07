namespace Tests_Core.Data_access_layer.Commissions
{
    public class PerTrade : ICommissionType
    {
        public decimal CalculateCommision(Trade trade) => trade.Commission * 1m;
    }
}
