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
        public bool PhoneCallStatus;
        public TariffPlan TariffPlan;

        public Subscriber(string? Surname, string? Name, string? MiddleName, DateOnly DateOfBirth, int PhoneNumber, string? TariffPlanName, int TariffPlanPrice) : base(Surname, Name, MiddleName, DateOfBirth)
        {
            this.PhoneNumber = PhoneNumber;
            PortStatus = true;
            PhoneCallStatus = false; //Статус дозвона.

            TariffPlan = new TariffPlan(DateTime.Now, TariffPlanName, TariffPlanPrice);
        }



        

        /*
        public delegate void Delegate (List<Subscriber> subscriber);
        public event Delegate? Event;
        public void EventPhoneNumber(List<Subscriber> subscriber)
        {
            if (Event != null)
            {
                Event(subscriber);
            }
        }
        */



    }
}
