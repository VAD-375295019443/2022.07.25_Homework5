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
            //DateTime d3 = d2 - d1;

            TimeSpan z = d2 - d1;

            double s = z.TotalSeconds;


            //int x = (int)z.TotalSeconds;

            //int f = (int)(d2 - d1).TotalSeconds;




            Console.WriteLine(z);
            //Console.WriteLine(f);



        }
    }
}



