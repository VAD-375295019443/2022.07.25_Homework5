using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE
{
    internal class Subscriber : Client
    {
        public int ContractNumber = 0;
        public int PhoneNumber = 0;
        public bool PortStatus = true; //Статус порта.
        public bool PhoneCallStatus = false; //Статус дозвона.

        public Subscriber(string surname, string name, string middleName, DateOnly dateOfBirth) : base(surname, name, middleName, dateOfBirth)
        {
        }

        public delegate void Delegate ();
        public event Delegate? Event;
        public void EventPhoneNumber()
        {
            if(Event != null)
            {
                Event();
            }
        }
    }
}
