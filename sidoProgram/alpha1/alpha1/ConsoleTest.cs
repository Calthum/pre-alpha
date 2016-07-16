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

            testAll();
        }

        public static void testAll()
        {
            testYield();
            Console.WriteLine();

            testBuilding();
            Console.WriteLine();

            abilityTest();
            Console.WriteLine();

            policyTest();
            Console.WriteLine();

            questTest();
            Console.WriteLine();

            techTest();
            Console.WriteLine();
        }

        public static void testYield()
        {
            yield yield1 = new yield(1, 2, 3, 4, 5);
            yield yield2 = new yield(5, 4, 3, 2, 1);

            yield yield3 = yield1 + yield2;

            Console.WriteLine("  " + yield1);
            Console.WriteLine("+ " + yield2);
            Console.WriteLine();
            Console.WriteLine("  " + yield3);

            Console.ReadKey();
        }

        public static void testBuilding()
        {
            building b1 = new building("Slott", "Slott är starka mot attacker, men dyra att köpa.", "castle_simple", 100, 500);
            building b2 = new building();

            Console.WriteLine(b1);
            Console.WriteLine();
            Console.WriteLine(b2);

            Console.ReadKey();
        }

        public static void abilityTest()
        {
            ability a1 = new ability("Heal", "heal_target", 2);
            ability a2 = new ability();

            Console.WriteLine(a1);
            Console.WriteLine();
            Console.WriteLine(a2);

            Console.ReadKey();
        }

        public static void policyTest()
        {
            policy p1 = new policy("Water People", "ocean_gold", 100);
            policy p2 = new policy();

            Console.WriteLine(p1);
            Console.WriteLine();
            Console.WriteLine(p2);

            Console.ReadKey();
        }

        public static void questTest()
        {
            quest q1 = new quest("Fight for the king!", "killStuff_1", "randomReward_1");
            quest q2 = new quest();

            Console.WriteLine(q1);
            Console.WriteLine();
            Console.WriteLine(q2);

            Console.ReadKey();
        }

        public static void techTest()
        {
            tech t1 = new tech("Animal Husbandry", "animalAncient", 20);
            tech t2 = new tech();

            Console.WriteLine(t1);
            Console.WriteLine();
            Console.WriteLine(t2);

            Console.ReadKey();
        }
    }
}
