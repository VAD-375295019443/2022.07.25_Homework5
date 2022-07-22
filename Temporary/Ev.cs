using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temporary
{
    internal class Ev
    {

        


        public delegate void Delegate(int x);
        public event Delegate? Event;


        public void EventPhoneNumber1(int x)
        {
            if (Event != null)
            {
                Event(x);
            }
        }




    }
}

