using ATE;
using System;
using System.Linq;

namespace Strings
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<Subscriber> subscriber = new List<Subscriber>();









            subscriber.Add(new Subscriber("ghg", "ghjgjh", "jhghjghjg", DateOnly.Parse("06.01.2022")));

            subscriber[0].Event += CalcPhoneNumber;

            subscriber[0].Put();





        }

        public static void CalcPhoneNumber()
        {
            //z[0].    //.PhoneNumber = "562487";

            Console.WriteLine($"Номер абонента: ") ;
        }
        
    }
}
