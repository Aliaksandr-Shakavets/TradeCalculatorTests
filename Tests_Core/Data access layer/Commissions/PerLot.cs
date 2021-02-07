namespace Tests_Core.Data_access_layer.Commissions
{
    public class PerLot : ICommissionType
    {
        public decimal CalculateCommision(Trade trade) => trade.Commission * trade.Volume;
    }
}
