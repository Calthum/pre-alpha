using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace preAlphaLibrary
{
     public class unitLib
    {
        public List<unit> unitList = new List<unit>();
        private infoLib infoLibrary = new infoLib();

        public unitLib(tileLib tileLibrary)
        {
            CreateNewUnit(infoLibrary.Scout("max", 0), 104, tileLibrary);
            CreateNewUnit(infoLibrary.Warrior("max", 0), 87, tileLibrary);
            CreateNewUnit(infoLibrary.Warrior("barb", 0), 125, tileLibrary);

            CreateNewUnit(infoLibrary.Hero("max", 0), 53, tileLibrary);
            CreateNewUnit(infoLibrary.Hero("barb", 0), 126, tileLibrary);

            //unitList.Add(infoLibrary.Scout("max", 0));
            //unitList.Add(infoLibrary.Warrior("max", 0));
            //unitList.Add(infoLibrary.Warrior("max", 0));

            // tempTileList[104].addUnit(0);
            // tempTileList[87].addUnit(1);
            // tempTileList[125].addUnit(2);


        }

        public int FindIndexOfUnit_AtUnitID(int unitID)
        {
            for (int i = 0; i < unitList.Count; i++)
            {
                if (unitList[i].unitID == unitID)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Skapar en ny enhet på  givet index i världen, kräver inte att du ger en annan unitID än 0
        /// ge den dessutom en index i världen att vara
        /// </summary>
        /// <param name="UnitType"></param>
        public void CreateNewUnit(unit UnitType, int index, tileLib tileLibray)
        {
            UnitType.unitID = lastUnitID();
            unitList.Add(UnitType);
            if (UnitType.unitID == 3)
            {
                Debug.Log("Create 3");
            }
            tileLibray.TileList[index].addUnit(UnitType.unitID);
        }

        /// <summary>
        /// Låter två enheter slåss och om de dör så försvinner de som dog
        /// </summary>
        /// <param name="Attacker"></param>
        /// <param name="Defender"></param>
        public void FIGHT(unit Attacker, unit Defender)
        {
            Attacker.BattleAnotherUnit(Defender);
            if (Attacker.CurrentHp <= 0)
            {
                unitList.RemoveAt(FindIndexOfUnit_AtUnitID(Attacker.unitID));
            }
            if (Defender.CurrentHp <= 0)
            {
                unitList.RemoveAt(FindIndexOfUnit_AtUnitID(Defender.unitID));
            }
        }
        
        public void allUnitsNewTurn()
        {
            for (int i = 0; i < unitList.Count; i++)
            {
                unitList[i].newTurn();
            }
        }

        public int lastUnitID()
        {
            if (unitList.Count == 0)
            {
                return 0;
            }
            return unitList[unitList.Count - 1].unitID + 1;
        }
    }
}