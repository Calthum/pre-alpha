using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace preAlphaLibrary
{
    public class building
    {
        public string name = "defaultBuilding";
        public string info = "en default building";
        public string effect = "noeffect";
        public int prodCost = 50;
        public int goldCost = 100;

        /// <summary>
        /// Skapar en ny byggnad med givna värden. Namnet och info kommer visas för spelaren, effect används av library för att bestämma vad byggnaden gör
        /// </summary>
        /// <param name="name"></param>
        /// <param name="info"></param>
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
    }
}
