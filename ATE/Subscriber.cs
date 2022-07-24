using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE
{
    internal class Subscriber : Client
    {
        public int NumberSubscriber;
        public bool PortStatus;
        public PhoneCallStatus PhoneCallStatus;
        public TariffPlan TariffPlan;
        public Balance Balance;

        public Subscriber(string? Surname, string? Name, string? MiddleName, DateOnly DateOfBirth, int NumberSubscriber, string? TariffPlanName, double TariffPlanPrice) : base(Surname, Name, MiddleName, DateOfBirth)
        {
            this.NumberSubscriber = NumberSubscriber;
            PortStatus = true;
            PhoneCallStatus = new PhoneCallStatus();
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
