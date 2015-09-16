using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            for (int i = 0; i < 100; i++)
            {
                int test = r.Next(0, 100);
                if (test <= 50)
                    Console.WriteLine(test);
            }
            Console.ReadKey();
        }
    }
}
