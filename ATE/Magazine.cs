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
        DateTime StartDateTime = DateTime.Now;
        TimeOnly CallDuration;
        double Money;

        public Magazine(int subscriberNumber, DateTime startDateTime, TimeOnly callDuration, double money)
        {
            SubscriberNumber = subscriberNumber;
            StartDateTime = startDateTime;
            CallDuration = callDuration;
            Money = money;
        }
    }
}
