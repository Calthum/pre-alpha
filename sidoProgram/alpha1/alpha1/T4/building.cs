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
    /// En byggnad innehåller en mängd information, två konstruktorer och en toString.
    /// </summary>
    class building
    {
        // Members

        /// <summary>
        /// Namnet på byggnaden.
        /// </summary>
        public string name;
        /// <summary>
        /// En informationssträng om byggnaden.
        /// </summary>
        public string info;
        /// <summary>
        /// En sträng som används för att bestämma vad byggnaden kommer åstadkomma i informationLibrary.
        /// </summary>
        public string effect;

        /// <summary>
        /// En int som bestämmer hur mkt byggnaden kommer kosta att producera.
        /// </summary>
        public int prodCost;
        /// <summary>
        /// En int som bestämmer hur mkt byggnaden kommer kosta att köpa.
        /// </summary>
        public int goldCost;

        // Constructors

        /// <summary>
        /// Skapar en byggnad med givna parametrar.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="info"></param>
        /// <param name="effect"></param>
        /// <param name="prodCost"></param>
        /// <param name="goldCost"></param>
        public building(string name, string info, string effect, int prodCost, int goldCost)
        {
            this.name = name;
            this.info = info;
            this.effect = effect;
            this.prodCost = prodCost;
            this.goldCost = goldCost;
        }
        /// <summary>
        /// Skapar en byggnad med default-värden.
        /// </summary>
        public building()
        {
            this.name = "blankBuilding";
            this.info = "En blank/placeholder byggnad.";
            this.effect = "blankEffect";
            this.prodCost = 100;
            this.goldCost = 200;
        }

        // Overloads

        /// <summary>
        /// Returnerar en sträng som visar upp information om byggnaden på ett fint sätt
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Namn: " + name + "\n" +
                   "Info: " + info + "\n" +
                   "Effekt: " + effect + "\n\n" +
                   "Prod: " + prodCost + "\n" +
                   "Gold: " + goldCost + "\n";
        }
    }
}
