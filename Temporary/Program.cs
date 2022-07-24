using Temporary;
using System;
using System.Linq;

namespace Temporary
{            
    



    internal class Program
    {
        public static void Main(string[] args)
        {
            DateTime d1 = DateTime.Now;
            DateTime d2 = d1.AddSeconds(120);

            int int1;

            if(d1 > d2)
            {
                int1 = 12;

            }
            else
            {
                int1 = 1;
            }

            Console.WriteLine(int1);
            //Console.WriteLine(f);



        }
    }
}



