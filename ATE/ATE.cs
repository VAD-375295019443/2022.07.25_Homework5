using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE
{
    internal class ATE
    {
        public List<Subscriber> Subscriber;
        public List<TariffPlan> TariffPlan;
        public List<Magazine> Magazine;

        public ATE()
        {
            Subscriber = new List<Subscriber>();
            
            TariffPlan = new List<TariffPlan>();
            TariffPlan.Add(new TariffPlan("Light plan", 1.0));
            TariffPlan.Add(new TariffPlan("Medium plan", 10.0));
            TariffPlan.Add(new TariffPlan("Supper plan", 100.0));
            TariffPlan.Add(new TariffPlan("Supper Plus plan", 1000.0));

            Magazine = new List<Magazine>();
        }
    }
}
