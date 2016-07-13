using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using alpha1.T0;
using alpha1.T1;
using alpha1.T2;
using alpha1.T3;
using alpha1.T4;

namespace alpha1
{
    class consoleTest
    {
        static void Main(string[] args)
        {
            testYield();
            Console.WriteLine();
            testBuilding();
        }

        /// <summary>
        /// Testar yields.
        /// </summary>
        public static void testYield()
        {
            yield yield1 = new yield(1, 2, 3, 4, 5);
            yield yield2 = new yield(5, 4, 3, 2, 1);

            yield yield3 = yield1 + yield2;

            Console.WriteLine(yield3);
            
            Console.ReadKey();
        }

        /// <summary>
        /// Testar buildings.
        /// </summary>
        public static void testBuilding()
        {
            building b1 = new building("Slott", "Slott är starka mot attacker, men dyra att köpa.", "castle_simple", 100, 500);
            building b2 = new building();

            Console.WriteLine("b1: ---------------------------");
            Console.WriteLine(b1);

            Console.WriteLine();

            Console.WriteLine("b2: ---------------------------");
            Console.WriteLine(b2);

            Console.ReadKey();
        }
    }
}
