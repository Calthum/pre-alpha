using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alpha1.T4
{
    /// <summary>
    /// En ability innehåller inga metoder, utan endast två konstruktorer och en overload.
    /// </summary>
    class ability
    {
        // Members

        public string name;
        public string effect;
        public byte cooldown;

        // Constructors
        
        /// <summary>
        /// Skapar en ability med givna parametrar.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="effect"></param>
        /// <param name="cooldown"></param>
        public ability(string name, string effect, byte cooldown)
        {
            this.name = name;
            this.effect = effect;
            this.cooldown = cooldown;
        }

        /// <summary>
        /// Skapar en blank ability.
        /// </summary>
        public ability()
        {
            this.name = "blankAbility";
            this.effect = "blankEffect";
            this.cooldown = 0;
        }

        // Overloads

        /// <summary>
        /// Returnerar abilityn som en sträng som förklarar vad abilityn har för information i sig.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Namn: " + name + "\n" +
                   "Effekt: " + effect + "\n" +
                   "Cooldown: " + cooldown;
        }
    }
}
