using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE
{
    internal class TariffPlan
    {
        public DateOnly Date = new DateOnly();
        public string? TariffPlanName;
        public int Traffic;

        public TariffPlan(string? tariffPlanName)
        {
            TariffPlanName = tariffPlanName;
        }
    }
}
