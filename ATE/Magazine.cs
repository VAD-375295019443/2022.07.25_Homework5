using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE
{
    internal class Magazine
    {
        int SubscriberNumber;
        DateTime StartDateTime;
        TimeOnly CallDuration;
        double Money;

        public Magazine(int SubscriberNumber, DateTime StartDateTime, TimeOnly CallDuration, double Money)
        {
            this.SubscriberNumber = SubscriberNumber;
            this.StartDateTime = StartDateTime;
            this.CallDuration = CallDuration;
            this.Money = Money;
        }
    }
}
