using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE
{
    internal class Magazine
    {
        int MyNumberSubscriber;
        string MyNameSubscriber;
        int DialedNumberSubscriber;
        string DialedNameSubscriber;
        DateTime CallDateStart;
        DateTime CallDateStop;
        TimeSpan CallDuration;
        double Price;
        double Cost;
        private string result;

        public Magazine(int MyNumberSubscriber, string MyNameSubscriber, int DialedNumberSubscriber, string DialedNameSubscriber, DateTime CallDateStart, DateTime CallDateStop, TimeSpan CallDuration, double Price, double Cost)
        {
            this.MyNumberSubscriber = MyNumberSubscriber;
            this.MyNameSubscriber = MyNameSubscriber;
            this.DialedNumberSubscriber = DialedNumberSubscriber;
            this.DialedNameSubscriber = DialedNameSubscriber;
            this.CallDateStart = CallDateStart;
            this.CallDateStop = CallDateStop;
            this.CallDuration = CallDuration;
            this.Price = Price;
            this.Cost = Cost;
        }
    }
}
