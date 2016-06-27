﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace preAlphaLibrary
{
    class city
    {
        private string name;
        private string owner;
        private int cityID;
        private int foodStash;
        private int peopleCap;
        private int unassignedPeople;
        private int[] cityYield = new int[5];
        public int unitplusCap = 0;

        private infoLib infoLibrary;
        public tileLib tileLibrary;
        private List<building> buildingList = new List<building> { };

        public city(string name, string owner, tileLib tileLibrary, int cityID)
        {
            this.name = name;
            this.owner = owner;
            this.peopleCap = 1;
            this.foodStash = 0;
            this.tileLibrary = tileLibrary;
            this.cityID = cityID;
        }

        /// <summary>
        /// returnerar stadens yield ifrån folk som arbetar utanför staden
        /// </summary>
        /// <returns></returns>
        public int[] CityYieldFromPeopleWorking()
        {
            int[] sum = new int[5] { 0, 0, 0, 0, 0 };
            for (int i = 0; i < tileLibrary.Count; i++)
            {
                if (tileLibrary.Tile_AtIndex(i).WorkedByCity == cityID)
                {
                    for (int i2 = 0; i2 < sum.Length; i2++)
                    {
                        sum[i2] = sum[i2] + tileLibrary.tileYield_AtIndex(i)[i2];
                    }
                }
            }
            return sum;
        }
        /// <summary>
        /// Bool som bestämmer om du kan assigna en person att worka en tile,
        /// om den kan så tar den bort en unassigned person.
        /// </summary>
        /// <returns></returns>
        public bool CanAssignWorkedTile()
        {
            if (unassignedPeople > 0)
            {
                unassignedPeople--;
                return true;
            }
            return false;
        }
        /// <summary>
        /// returnerar den cityYield+ som alla byggnader i staden ger
        /// </summary>
        /// <returns></returns>
        public int[] CityYieldFromBuildings()
        {
            int[] sum = new int[5] { 0, 0, 0, 0, 0 };
            for (int i = 0; i < buildingList.Count; i++)
            {
                for (int i2 = 0; i2 < sum.Length; i2++)
                {
                    sum[i2] = sum[i2] + infoLibrary.getCityYieldFromEffect(buildingList[i].effect)[i2];
                }
            }
            return sum;
        }
        /// <summary>
        /// returnerar en sträng som visar vad staden har för yield i textform
        /// </summary>
        /// <returns></returns>
        public string CityYieldString()
        {
            string temp = "";
            if (cityYield[0] > 0)
            {
                temp += cityYield[0] + " f";
            }
            if (cityYield[1] > 0)
            {
                temp += " " + cityYield[1] + " p";
            }
            if (cityYield[2] > 0)
            {
                temp += " " + cityYield[2] + " g";
            }
            if (cityYield[3] > 0)
            {
                temp += " " + cityYield[3] + " c";
            }
            if (cityYield[4] > 0)
            {
                temp += " " + cityYield[4] + " s";
            }
            return temp;
        }
        /// <summary>
        /// Uppdaterar cityYield utifrån invånare, policy och byggnader
        /// </summary>
        public void UpdateTileYield()
        {
            cityYieldZero();
            cityYield = cityYieldAdd(infoLibrary.getTileTypeYield(tileLibrary.FindTile_AtCityID(cityID).TileTypeString));
            cityYield = cityYieldAdd(CityYieldFromBuildings());
            cityYield[5] = peopleCap;
            cityYield[4] = peopleCap / 2;
        }
        /// <summary>
        /// Resettar cityYield till 0 på alla värden.
        /// </summary>
        public void cityYieldZero()
        {
            cityYield = new int[5] { 0, 0, 0, 0, 0 };
        }
        /// <summary>
        /// Adderar cityYield med en annan array av storlek 5 parallelt.
        /// </summary>
        /// <param name="input1"></param>
        /// <param name="input2"></param>
        /// <returns></returns>
        private int[] cityYieldAdd(int[] input2)
        {
            int[] sum = new int[5];
            for (int i = 0; i < sum.Length; i++)
            {
                sum[i] = cityYield[i] + input2[i];
            }
            return sum;
        }
        public void AddBuilding(building building)
        {
            buildingList.Add(building);
        }
        public void updateUnitplusCap()
        {
            unitplusCap = 0;
            for (int i = 0; i < buildingList.Count; i++)
            {
                unitplusCap += infoLibrary.getUnitCapFromEffect(buildingList[i].effect);
            }
        }
    }
}
