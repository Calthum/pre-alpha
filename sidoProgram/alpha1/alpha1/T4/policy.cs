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

namespace alpha1.T4
{
    /// <summary>
    /// En policy innehåller endast namn, effekt och kostnad, två konstruktorere och en overload, inga metoder.
    /// </summary>
    class policy
    {
        // Members

        public string name;
        public string effect;
        public int cost;

        // Constructors

        /// <summary>
        /// Skapar en policy med givna parametrar.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="effect"></param>
        /// <param name="cost"></param>
        public policy(string name, string effect, int cost)
        {
            this.name = name;
            this.effect = effect;
            this.cost = cost;
        }

        /// <summary>
        /// Skapar en blank policy.
        /// </summary>
        public policy()
        {
            this.name = "blankName";
            this.effect = "blankEffect";
            this.cost = 100;
        }

        // Overloads

        /// <summary>
        /// Returnerar en sträng med information om policyn.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Namn: " + name + "\n" +
                   "Effekt: " + effect + "\n" +
                   "Kostnad: " + cost;
        }
    }
}
