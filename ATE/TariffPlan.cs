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
        public int Price;

        public TariffPlan(string? name, int price)
        {
            Name = name;
            Price = price;
        }
        
        public TariffPlan(DateTime date, string? name, int price)
        {
            Date = date;
            Name = name;
            Price = price;
        }
    }
}
