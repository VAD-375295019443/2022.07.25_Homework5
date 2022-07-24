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


        public delegate void CallStatusOn(string Result);
        public event CallStatusOn? On;
        public void CalcCallStatusOn(int DialedNumberSubscriber, string DialedNameSubscriber)
        {
            string Result;

            CallStatus = true;
            CallDateStart = DateTime.Now;
            this.DialedNumberSubscriber = DialedNumberSubscriber;
            this.DialedNameSubscriber = DialedNameSubscriber;

            Result = $"Соединение установлено!";
            if (On != null)
            {
                On(Result);
            }
        }


        public delegate void CallStatusOff(ATE aTE, int MyNumberSubscriber, string MyNameSubscriber, int DialedNumberSubscriber, string DialedNameSubscriber, DateTime CallDateStart, DateTime CallDateStop, double Price, string Result);
        public event CallStatusOff? Off;
        public void CalcCallStatusOff(ATE aTE, int MyNumberSubscriber, string MyNameSubscriber, double Price)
        {
            string Result;

            Result = $"Соединение завершено!";
            if (Off != null)
            {
                Off(aTE, MyNumberSubscriber, MyNameSubscriber, DialedNumberSubscriber, DialedNameSubscriber, CallDateStart, DateTime.Now, Price, Result);
            }
        }
    }
}
