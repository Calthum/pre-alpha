using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dummyLibrary
{
    class tile
    {
        // Datamedlemmar
        /// <summary>
        /// noColor by default
        /// annars har den en color i string som man kan förvänta sig
        /// </summary>
        private string colorString = "noColor";
        /// <summary>
        /// -1 om tilen inte har en stad på sig
        /// annars har den en postitiv integer som specificerar vilken stad den har på sig
        /// </summary>
        private int cityID = -1;
        /// <summary>
        /// int lista över vilka units som finns på tilen
        /// dessa representeras då genom sin ID
        /// </summary>
        private List<int> unitIDs;
        private int x = 0;
        private int y = 0;
        private int z = 0;

        // Konstruktorer
        /// <summary>
        /// initerar en tile med de värden som du ger den
        /// </summary>
        /// <param name="colorString"></param>
        /// <param name="cityID"></param>
        /// <param name="unitIDs"></param>
        public tile(string colorString, int cityID, List<int> unitIDs, int x, int y, int z)
        {
            this.colorString = colorString;
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
            this.colorString = "noColor";
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
        /// <param name="colorString"></param>
        /// <param name="cityID"></param>
        /// <param name="unitIDs"></param>
        public tile(string colorString, int cityID, List<int> unitIDs, int[] XYZarray)
        {
            this.colorString = colorString;
            this.cityID = cityID;
            this.unitIDs = unitIDs;
            this.x = XYZarray[0];
            this.y = XYZarray[1];
            this.z = XYZarray[2];
        }

        // Metoder
        /// <summary>
        /// get + set för colorString
        /// om du ger den en tom string ""
        /// så blir färgen "noColor"
        /// </summary>
        public string Color
        {
            get { return colorString; }
            set
            {
                if (value == "")
                {
                    colorString = "noColor";
                }
                else
                {
                    colorString = value;
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
        /// returnerar tilens xz coordinater i spelet i form av 2 doublar, x först sedan z,,
        /// utifrån dess matematiska xyz coordinater.
        /// default r = 1
        /// </summary>
        /// <returns></returns>
        public double[] XZcoordinates()
        {
            double r = 1;
            double xCoord = r * 1 / 2 * (2 * x + y - z);
            double zCoord = r * Math.Sqrt(3) / 2 * (y + z);
            return new double[2] { xCoord, zCoord };
        }
        /// <summary>
        /// returnerar tilens 3 spelcoordinater, x, y, z
        /// </summary>
        /// <returns></returns>
        public int[]XYZGameCoordinates()
        {
            return new int[3] { x, y, z };
        }
        /// <summary>
        /// returnerar tilens 3 spelcoordinater, x, y, z
        /// som om tilen skulle tagit ett steg DownRight
        /// </summary>
        /// <returns></returns>
        public int[] XYZGameCoordinatesDownRight()
        {
            return new int[3] { x + 1, y, z - 1};
        }
        /// <summary>
        /// returnerar tilens 3 spelcoordinater, x, y, z
        /// som om tilen skulle tagit ett steg UpRight
        /// </summary>
        /// <returns></returns>
        public int[] XYZGameCoordinatesUpRight()
        {
            return new int[3] { x + 1, y + 1, z};
        }
    }
}
