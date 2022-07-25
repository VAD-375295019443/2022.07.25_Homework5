using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE
{
    internal class PhoneCallStatus
    {
        public bool CallStatus;
        public DateTime CallDateStart;
        public int DialedNumberSubscriber;
        string DialedNameSubscriber;

        public PhoneCallStatus()
        {
            CallStatus = false; //Статус дозвона.
        }


        public delegate void CallStatusOn(int DialedNumberSubscriber, string DialedNameSubscriber);
        public event CallStatusOn? On;
        public void CalcCallStatusOn(ref ATE aTE, int DialedIndexSubscriber)
        {
            CallStatus = true;
            CallDateStart = DateTime.Now;
            this.DialedNumberSubscriber = aTE.Subscriber[DialedIndexSubscriber].NumberSubscriber;
            this.DialedNameSubscriber = $"{aTE.Subscriber[DialedIndexSubscriber].Surname} {aTE.Subscriber[DialedIndexSubscriber].Name} {aTE.Subscriber[DialedIndexSubscriber].MiddleName}";

            aTE.Subscriber[DialedIndexSubscriber].PhoneCallStatus.CallStatus = true;

            if (On != null)
            {
                On(DialedNumberSubscriber, DialedNameSubscriber);
            }
        }


        public delegate void CallStatusOff(ref ATE aTE, int MyNumberSubscriber, string MyNameSubscriber, int DialedNumberSubscriber, string DialedNameSubscriber, DateTime CallDateStart, DateTime CallDateStop, double Price);
        public event CallStatusOff? Off;
        public void CalcCallStatusOff(ref ATE aTE, int MyIndexSubscriber)
        {
            CallStatus = false;
            
            aTE.Subscriber[aTE.Subscriber.FindIndex(x => x.NumberSubscriber == DialedNumberSubscriber)].PhoneCallStatus.CallStatus = false;

            if (Off != null)
            {
                Off(ref aTE,
                    aTE.Subscriber[MyIndexSubscriber].NumberSubscriber,
                    $"{aTE.Subscriber[MyIndexSubscriber].Surname} {aTE.Subscriber[MyIndexSubscriber].Name} {aTE.Subscriber[MyIndexSubscriber].MiddleName}",
                    DialedNumberSubscriber,
                    DialedNameSubscriber,
                    CallDateStart,
                    DateTime.Now,
                    aTE.Subscriber[MyIndexSubscriber].TariffPlan.Price);
            }
        }
    }
}
