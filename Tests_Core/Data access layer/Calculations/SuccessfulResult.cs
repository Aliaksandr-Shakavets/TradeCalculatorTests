using System;

namespace Tests_Core.Data_access_layer.Calculations
{
    public sealed class SuccessfulResult : ICalculationResult, IEquatable<SuccessfulResult>
    {
        public SuccessfulResult(decimal profit, decimal margin, decimal commission)
        {
            Profit = profit;
            Margin = margin;
            Commission = commission;
        }

        public decimal Profit { get; }
        public decimal Margin { get; }
        public decimal Commission { get; }

        public override bool Equals(object obj)
        {
            return Equals(obj as SuccessfulResult);
        }

        public bool Equals(SuccessfulResult other)
        {
            return other != null &&
                   Profit == other.Profit &&
                   Margin == other.Margin &&
                   Commission == other.Commission;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Profit, Margin, Commission);
        }
    }
}
