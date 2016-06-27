using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace preAlphaLibrary
{
    class infoLib
    {
        public int[] getTileTypeYield(string tileTypeString)
        {
            if (tileTypeString == "Sand") { return new int[5] { 0, 1, 1, 0, 0 }; }
            if (tileTypeString == "Forest") { return new int[5] { 1, 2, 0, 0, 0 }; }
            if (tileTypeString == "Ocean") { return new int[5] { 2, 0, 1, 0, 0 }; }

            // om den inte finner en tiletype i databasen så ger den tillbaka en rolig tile
            return new int[5] { 1, 3, 3, 7, 0 };
        }

        public int[] getTileYieldFromPolicy(string tileType, string policyString)
        {
            if (tileType == "Forest" && policyString == "LandPeople") { return new int[5] { 1, 0, 0, 0, 0 }; }
            if (tileType == "Sand" && policyString == "LandPeople") { return new int[5] { 1, 0, 0, 0, 0 }; }

            if (tileType == "Sand" && policyString == "OceanPeople") { return new int[5] { 0, 0, 2, 0, 0 }; }
            if (tileType == "Ocean" && policyString == "OceanPeople") { return new int[5] { 0, 0, 2, 0, 0 }; }

            return new int[5] { 0, 0, 0, 0, 0 };
        }

        public int[] getCityYieldFromEffect(string effect)
        {
            if (effect == "granaryEffect")
            {
                return new int[5] { 5, 0, 0, 0, 0 };
            }

            return new int[5] { 0, 0, 0, 0, 0 };
        }

        public int getCityHpFromEffect(string effect)
        {
            if (effect == "wallEffect")
            {
                return 100;
            }

            return 0;
        }

        public int getUnitCapFromEffect(string effect)
        {
            if (effect == "1unitcap+")
            {
                return 1;
            }

            return 0;
        }

        public building Granary()
        { return new building("Granary", "Ger din stad 5 food", "granaryEffect", 100, 120); }
        public building Walls()
        { return new building("Walls", "Ger din stad 100 mer hp", "wallEffect", 50, 200); }
        public building Barracks()
        { return new building("Barracks", "Ger dig 1 mer unitcap", "1unitcap+", 70, 70); }
    }
}
