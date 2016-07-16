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
    /// En quest innehåller bara ett namn och 2 strängar kring vad den ska göra och få, två konstruktorer och en overload.
    /// </summary>
    class quest
    {
        // Members

        public string name;
        public string questNeeds;
        public string questGains;

        // Constructors

        /// <summary>
        /// Skapar en quest med givna parametrar.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="questNeeds"></param>
        /// <param name="questGains"></param>
        public quest(string name, string questNeeds, string questGains)
        {
            this.name = name;
            this.questNeeds = questNeeds;
            this.questGains = questGains;
        }

        /// <summary>
        /// Skapar en blank quest.
        /// </summary>
        public quest()
        {
            this.name = "blankName";
            this.questNeeds = "blankNeed";
            this.questGains = "blankGains";
        }

        // Overloads

        /// <summary>
        /// Returnerar en sträng med information kring questen.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Namn: " + name + "\n" +
                   "Att göra: " + questNeeds + "\n" +
                   "Reward: " + questGains;
        }
    }
}
