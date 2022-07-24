using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE
{
    internal class TariffPlan
    {
        public DateTime Date;
        public string? Name;
        public double Price;

        public TariffPlan(string? Name, double Price)
        {
            this.Name = Name;
            this.Price = Price;
        }
        
        public TariffPlan(DateTime Date, string? Name, double Price)
        {
            this.Date = Date;
            this.Name = Name;
            this.Price = Price;
        }


        public delegate void TariffPlanReplace(ref ATE aTE, int MyIndexSubscriber);
        public event TariffPlanReplace? Replace;
        public void CalcTariffPlanReplace(ATE aTE, int MyIndexSubscriber)
        {
            if (Replace != null)
            {
                Replace(ref aTE, MyIndexSubscriber);
            }
        }
    }
}
