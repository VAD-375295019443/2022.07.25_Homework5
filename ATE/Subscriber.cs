using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE
{
    internal class Subscriber : Client
    {
        public string? PhoneNumber;
        public bool PortStatus = false;

        public Subscriber(string surname, string name, string middleName, DateOnly dateOfBirth) : base(surname, name, middleName, dateOfBirth)
        {
        }

        public delegate void Delegate ();
        public event Delegate? Event;
        public void Put()
        {
            if(Event != null)
            {
                Event();
            }
        }
    }
}
