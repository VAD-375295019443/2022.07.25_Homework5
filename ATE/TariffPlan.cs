﻿using System;
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

        public TariffPlan(string? Name, int Price)
        {
            this.Name = Name;
            this.Price = Price;
        }
        
        public TariffPlan(DateTime Date, string? Name, int Price)
        {
            this.Date = Date;
            this.Name = Name;
            this.Price = Price;
        }
    }
}
