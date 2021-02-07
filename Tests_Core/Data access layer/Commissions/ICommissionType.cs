namespace Tests_Core.Data_access_layer.Commissions
{
    public interface ICommissionType
    {
        public decimal CalculateCommision(Trade trade);
    }
}