using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace preAlphaLibrary
{
    class tile
    {
        // Datamedlemmar
        /// <summary>
        /// tom string by default
        /// annars har den en tileType string som beskriver om den är en hill eller inte osv.
        /// </summary>
        private string tileTypeString = "";
        /// <summary>
        /// -1 om tilen inte har en stad på sig
        /// annars har den en postitiv integer som specificerar vilken stad den har på sig
        /// </summary>
        private int cityID = -1;
        /// <summary>
        /// -1 om tilen inte är ägd utav någon, 0-x om den är ägd av spelare 0-x.
        /// </summary>
        private int playerOwner = -1;
        /// <summary>
        /// int lista över vilka units som finns på tilen
        /// dessa representeras då genom sin ID
        /// </summary>
        private List<int> unitIDs;
        private int x = 0;
        private int y = 0;
        private int z = 0;
        /// <summary>
        /// tilens yield i form av en int array size 5, i ordningen:
        /// food, prod, gold, culture, science 
        /// </summary>
        private int[] tileYield = new int[5] { 0, 0, 0, 0, 0 };
        private infoLib infoLibrary;

        // Konstruktorer
        /// <summary>
        /// initerar en tile med de värden som du ger den
        /// </summary>
        /// <param name="tileTypeString"></param>
        /// <param name="cityID"></param>
        /// <param name="unitIDs"></param>
        public tile(string tileTypeString, int cityID, List<int> unitIDs, int x, int y, int z)
        {
            this.tileTypeString = tileTypeString;
            this.cityID = cityID;
            this.unitIDs = unitIDs;
            this.x = x;
            this.y = y;
            this.z = z;
        }
        /// <summary>
        /// initerar en tom tile med dessa värden
        /// colorString = "noColor"
        /// cityID = -1
        /// unitIDs = {}
        /// x = 0, y = 0, z = 0
        /// </summary>
        public tile()
        {
            this.tileTypeString = "";
            this.cityID = -1;
            this.unitIDs.Clear();
            this.x = 0;
            this.y = 0;
            this.z = 0;
        }
        /// <summary>
        /// initerar en tile med de värden som du ger den
        /// fast denna tar en array av coordinater istället
        /// </summary>
        /// <param name="tileTypeString"></param>
        /// <param name="cityID"></param>
        /// <param name="unitIDs"></param>
        public tile(string tileTypeString, int cityID, List<int> unitIDs, int[] XYZarray)
        {
            this.tileTypeString = tileTypeString;
            this.cityID = cityID;
            this.unitIDs = unitIDs;
            this.x = XYZarray[0];
            this.y = XYZarray[1];
            this.z = XYZarray[2];
        }

        // Metoder
        /// <summary>
        /// returnerar en sträng som visar vad tilen har för yield i textform
        /// </summary>
        /// <returns></returns>
        public string TileYieldString()
        {
            string temp = "";
            if (tileYield[0] > 0)
            {
                temp += tileYield[0] + " f";
            }
            if (tileYield[1] > 0)
            {
                temp += " " + tileYield[1] + " p";
            }
            if (tileYield[2] > 0)
            {
                temp += " " + tileYield[2] + " g";
            }
            if (tileYield[3] > 0)
            {
                temp += " " + tileYield[3] + " c";
            }
            if (tileYield[4] > 0)
            {
                temp += " " + tileYield[4] + " s";
            }
            return temp;
        }
        /// <summary>
        /// Uppdaterar tileYielden utifrån tileType, improvements och spelarens policies
        /// </summary>
        public void UpdateTileYield(player Player)
        {
            tileYieldZero();
            tileYield = tileYieldAdd(infoLibrary.getTileTypeYield(tileTypeString));
            tileYield = tileYieldAdd(Player.TileYieldFromPolicy(tileTypeString));
        }
        /// <summary>
        /// Resettar tileyielden till 0 på alla värden.
        /// </summary>
        public void tileYieldZero()
        {
            tileYield = new int[5] { 0, 0, 0, 0, 0 };
        }
        /// <summary>
        /// Adderar tileYielden med en annan array av storlek 5 parallelt.
        /// </summary>
        /// <param name="input1"></param>
        /// <param name="input2"></param>
        /// <returns></returns>
        private int[] tileYieldAdd(int[] input2)
        {
            int[] sum = new int[5];
            for (int i = 0; i < sum.Length; i++)
            {
                sum[i] = tileYield[i] + input2[i];
            }
            return sum;
        }
        /// <summary>
        /// get + set för colorString
        /// </summary>
        public string TileTypeString
        {
            get { return tileTypeString; }
            set
            {
                if (value == "")
                {
                    tileTypeString = "";
                }
                else
                {
                    tileTypeString = value;
                }
            }
        }
        /// <summary>
        /// get + set för cityID
        /// om du ger den en cityID under -1
        /// så blir den -1
        /// </summary>
        public int CityID
        {
            get { return cityID; }
            set
            {
                if (value < -1)
                {
                    cityID = -1;
                }
                else
                {
                    cityID = value;
                }
            }
        }
        /// <summary>
        /// returnerar en lista med alla units i den.
        /// </summary>
        public List<int> UnitList
        {
            get { return unitIDs; }
        }
        /// <summary>
        /// tar bort en enhet med specificerad ID från tilen
        /// </summary>
        /// <param name="ID"></param>
        public void removeUnit(int ID)
        {
            unitIDs.Remove(ID);
        }
        /// <summary>
        /// lägger till en unit med specificerad ID på tilen
        /// </summary>
        /// <param name="ID"></param>
        public void addUnit(int ID)
        {
            unitIDs.Add(ID);
        }
        /// <summary>
        /// returnerar tilens xz coordinater i spelet i form av 2 doublar, x först sedan z,
        /// utifrån dess matematiska xyz coordinater.
        /// du får dessutom bestämma hexagonernas radie med r
        /// </summary>
        /// <returns></returns>
        public double[] XZcoordinates(double r)
        {
            double xCoord = r * 1 / 2 * (2 * x + y - z);
            double zCoord = r * Math.Sqrt(3) / 2 * (y + z);
            return new double[2] { xCoord, zCoord };
        }
        /// <summary>
        /// returnerar tilens xyz coordinater i spelet i form av 3 doublar, x, y, z
        /// utifrån dess matematiska xyz coordinater.
        /// du får dessutom bestämma hexagonernas radie med r
        /// y är alltid 0
        /// </summary>
        /// <returns></returns>
        public double[] XYZUnityCoordinates(double r)
        {
            double xCoord = r * 1 / 2 * (2 * x + y - z);
            double zCoord = r * Math.Sqrt(3) / 2 * (y + z);
            return new double[2] { xCoord, zCoord };
        }
        /// <summary>
        /// returnerar tilens xz coordinater i spelet i form av 3 doublar, x, y, z
        /// utifrån dess matematiska xyz coordinater.
        /// default r = 1
        /// y = 0
        /// </summary>
        /// <returns></returns>
        public double[] XYZUnityCoordinates()
        {
            double r = 1;
            double xCoord = r * 1 / 2 * (2 * x + y - z);
            double zCoord = r * Math.Sqrt(3) / 2 * (y + z);
            return new double[3] { xCoord, 0, zCoord };
        }
        /// <summary>
        /// returnerar tilens 3 libraryCoordinates, x, y, z
        /// </summary>
        /// <returns></returns>
        public int[] XYZLibraryCoordinates()
        {
            return new int[3] { x, y, z };
        }
        /// <summary>
        /// returnerar tilens 3 libraryCoordinates, x, y, z
        /// som om tilen skulle tagit ett steg DownRight
        /// </summary>
        /// <returns></returns>
        public int[] XYZLibraryCoordinatesDownRight()
        {
            return new int[3] { x + 1, y, z - 1 };
        }
        /// <summary>
        /// returnerar tilens 3 libraryCoodinates, x, y, z
        /// som om tilen skulle tagit ett steg UpRight
        /// </summary>
        /// <returns></returns>
        public int[] XYZLibraryCoordinatesUpRight()
        {
            return new int[3] { x + 1, y + 1, z };
        }
    }
}
