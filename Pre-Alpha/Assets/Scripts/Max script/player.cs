using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace preAlphaLibrary
{
    class player
    {
        public int gold = 0;
        public int culture = 0;
        public int unitcap = 3;
        public string owner;
        public int science = 0;

        private infoLib infoLibrary;
        private List<string> policyList = new List<string> { };
        private List<building> availableBuildings = new List<building> { };

        public player()
        {
            this.gold = 0;
            this.culture = 0;
            policyList.Clear();
            this.owner = "max";
        }

        /// <summary>
        /// returnerar den tileYield+ som alla policies ger till en specifik tile.
        /// </summary>
        /// <param name="tileTypeString"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public int[] TileYieldFromPolicy(string tileTypeString)
        {
            int[] sum = new int[5] { 0, 0, 0, 0, 0 };
            for (int i = 0; i < policyList.Count; i++)
            {
                for (int i2 = 0; i2 < sum.Length; i2++)
                {
                    sum[i2] = sum[i2] + infoLibrary.getTileYieldFromPolicy(tileTypeString, policyList[i])[i2];
                }
            }
            return sum;
        }
        public void addPolicy(string input)
        {
            if (input == "OceanPeople" && culture > 10)
            {
                policyList.Add("OceanPeople");
                culture -= 10;
            }
            if (input == "LandPeople" && culture > 10)
            {
                policyList.Add("LandPeople");
                culture -= 10;
            }
        }
        public void addCultureAndGoldAndScience(cityLib cityLibrary)
        {
            for (int i = 0; i < cityLibrary.cityList.Count; i++)
            {
                if (cityLibrary.cityList[i].owner == this.owner)
                {
                    culture += cityLibrary.cityList[i].cityYield[3];
                    gold += cityLibrary.cityList[i].cityYield[1];
                    science += cityLibrary.cityList[i].cityYield[4];
                }
            }
        }
    }
}
