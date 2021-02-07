namespace Tests_Core.Data_access_layer.Commissions
{
    public class UnknowTradeType : ICommissionType
    {
        public decimal CalculateCommision(Trade trade)
        {
            return decimal.MinValue;
        }
    }
}
