using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alpha1.T4
{
    class tech
    {
        // Members

        public string name;
        public string effect;
        public int cost;

        // Constructors

        /// <summary>
        /// Skapar en tech med givna parametrar.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="effect"></param>
        /// <param name="cost"></param>
        public tech(string name, string effect, int cost)
        {
            this.name = name;
            this.effect = effect;
            this.cost = cost;
        }

        /// <summary>
        /// Skapar en blank tech.
        /// </summary>
        public tech()
        {
            this.name = "blankName";
            this.effect = "blankEffect";
            this.cost = 100;
        }

        // Overloads

        /// <summary>
        /// Returnerar en sträng med information om techen.
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
