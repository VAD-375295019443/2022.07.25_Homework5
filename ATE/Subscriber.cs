using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE
{
    internal class Subscriber : Client
    {
        public DateTime ContractDate;// = DateTime.Now;
        public int ContractNumber;
        public int PhoneNumber;

        public TariffPlan tariffPlan;
        
        
        //???
        //public bool PortStatus = true; //Статус порта.
        //public bool PhoneCallStatus = false; //Статус дозвона.


        public Subscriber(string? surname, string? name, string? middleName, DateOnly dateOfBirth, string? tariffPlanName, int tariffPlanPrice) : base(surname, name, middleName, dateOfBirth)
        {
            ContractDate = DateTime.Now;
            tariffPlan = new TariffPlan(DateTime.Now, tariffPlanName, tariffPlanPrice);
        }


        public delegate void Delegate (List<Subscriber> subscriber);
        public event Delegate? Event;
        public void EventPhoneNumber(List<Subscriber> subscriber)
        {
            if (Event != null)
            {
                Event(subscriber);
            }
        }
    }
}
