using System.Collections.Generic;

namespace Tests_Core.Data_access_layer.Commissions
{
    public static class CommissionsDefinations
    {
        private static readonly Dictionary<string, ICommissionType> commissions = new Dictionary<string, ICommissionType>
        {
            {"pertrade", new PerTrade() },
            {"perlot", new PerLot() }
        };

        public static bool TryGetValue(string commissionType, out ICommissionType commission)
        {
            return commissions.TryGetValue(commissionType.ToLowerInvariant(), out commission);
        }
    }
}
