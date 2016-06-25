using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace preAlphaLibrary
{
    class player
    {
        private int gold = 0;
        private int culture = 0;

        private infoLib infoLibrary;
        private List<string> policyList = new List<string> { };

        public player()
        {
            this.gold = 0;
            this.culture = 0;
            policyList.Clear();
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
    }
}
