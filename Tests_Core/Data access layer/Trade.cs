using Newtonsoft.Json;
using Tests_Core.Data_access_layer.Commissions;

namespace Tests_Core.Data_access_layer
{
    public class Trade
    {
        private string commissionTypeName;
        private void SetCommission(string value)
        {
            commissionTypeName = value;
            if (string.IsNullOrEmpty(value))
            {
                CommissionType = new PerTrade();
            }

            if (CommissionsDefinations.TryGetValue(value, out ICommissionType commissionType))
            {
                CommissionType = commissionType;
            }
            else
            {
                CommissionType = new UnknowTradeType();
            }
        }


        [JsonIgnore]
        public ICommissionType CommissionType { get; set; } = new PerLot();

        [JsonProperty("commissionType")]
        public string CommissionTypeName { private get => commissionTypeName; set => SetCommission(value); }

        [JsonProperty("openPrice", Required = Required.Always)]
        public decimal OpenPrice { get; set; }

        [JsonProperty("closePrice", Required = Required.Always)]
        public decimal ClosePrice { get; set; }

        [JsonProperty("volume", Required = Required.Always)]
        public decimal Volume { get; set; }

        [JsonProperty("contractSize", Required = Required.Always)]
        public decimal ContractSize { get; set; }

        [JsonProperty("leverage", Required = Required.Always)]
        public decimal Leverage { get; set; }

        [JsonProperty("commission", Required = Required.Always)]
        public decimal Commission { get; set; }

        public decimal GetCommissionByType() => CommissionType.CalculateCommision(this);
    }
}
