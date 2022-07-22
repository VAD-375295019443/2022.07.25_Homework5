using Temporary;
using System;
using System.Linq;

namespace Temporary
{            
    



    internal class Program
    {
        public static void Main(string[] args)
        {
            
            Ev z = new Ev();

            
            
            
            z.Event += EventPhoneNumber;
            z.EventPhoneNumber1(25);
            z.Event -= EventPhoneNumber;

            
        }





        //DateTime.Today.AddDays()

        public static void EventPhoneNumber(int x)
        {
            

            
            /*
            if (Subscriber.Count == 0)
            {
                MaxPhoneNumber = 11111;
                Subscriber[0].PhoneNumber = MaxPhoneNumber;
            }
            else
            {
                MaxPhoneNumber = Subscriber.Max(x => x.PhoneNumber) + 1;
                Subscriber[Subscriber.Count - 1].PhoneNumber = MaxPhoneNumber;
            }
            */

            Console.WriteLine($"Абонент с номером успешно добавлен в базу данных.");

            DateTime s = DateTime.Today.AddDays(-DateTime.Today.Day + 1);
            Console.WriteLine(s);

            Console.ReadLine();
        }



    }

}



