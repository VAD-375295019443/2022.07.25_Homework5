using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE
{
    internal class Subscriber : Client
    {
        public int PhoneNumber;
        public bool PortStatus;
        public PhoneCallStatus PhoneCallStatus;
        public TariffPlan TariffPlan;
        public Balance Balance;

        public Subscriber(string? Surname, string? Name, string? MiddleName, DateOnly DateOfBirth, int PhoneNumber, string? TariffPlanName, int TariffPlanPrice) : base(Surname, Name, MiddleName, DateOfBirth)
        {
            PhoneCallStatus = new PhoneCallStatus();
            PortStatus = true;
            TariffPlan = new TariffPlan(DateTime.Now, TariffPlanName, TariffPlanPrice);
            Balance = new Balance();
        }


        public delegate void PortOnOff(string Result);
        public event PortOnOff? OnOff;
        public void CalcPortStatus()
        {
            string Result;

            if (PortStatus == true)
            {
                PortStatus = false;

                Result = $"Порт закрыт!";
                if (OnOff != null)
                {
                    OnOff(Result);
                }
            }
            else
            {
                PortStatus = true;

                Result = $"Порт открыт!";
                if (OnOff != null)
                {
                    OnOff(Result);
                }
            }
        }
    }
}
