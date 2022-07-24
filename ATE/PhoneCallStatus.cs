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
        public int PhoneNumber;

        public PhoneCallStatus()
        {
            CallStatus = false; //Статус дозвона.
        }


        public delegate void CallStatusOnOff(string Result);
        public event CallStatusOnOff? OnOff;
        public void CalcCallStatus(int PhoneNumber = (-1))
        {
            string Result;
            DateTime CallDateStop;

            if (CallStatus == true)
            {
                CallStatus = false;
                CallDateStop = DateTime.Now;






                Result = $"Соединение завершено!";
                if (OnOff != null)
                {
                    OnOff(Result);
                }
            }
            else
            {
                CallStatus = true;
                CallDateStart = DateTime.Now;
                this.PhoneNumber = PhoneNumber;

                Result = $"Соединение установлено!";
                if (OnOff != null)
                {
                    OnOff(Result);
                }
            }
        }


    }
}
