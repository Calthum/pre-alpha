using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace preAlphaLibrary
{
    class tileLib
    {
        // Datamedlemmar
        private List<tile> tileList;

        // Metoder
        /// <summary>
        /// skapar ett nytt library med tiles
        /// Detta library kan sedan användas för att komma åt all
        /// information kring tiles i spelet
        /// i detta library så finns det 1 stad, 2 units, och en ö med hav runtikring sandstränder och skog.
        /// </summary>
        public tileLib()
        {
            tileList = new List<tile>(InitateTileListLonelyIsland()) { };
        }
        /// <summary>
        /// Initerar ön lonelyIsland
        /// </summary>
        /// <returns></returns>
        private List<tile> InitateTileListLonelyIsland()
        {
            List<tile> tempTileList = new List<tile>() { };
            string sideColor = "Blue";

            // En första row med höjden 10 skapas
            for (int i = 0; i < 10; i++)
            {
                tempTileList.Add(new tile(sideColor, -1, new List<int> { }, 0, i, i));
            }

            // Sedan skapas alternerande rows till höger om den förra, se tileList[tileList.Count - 10]
            // Varannan så skapas en row DownRight, varannan skapas en UpRight 
            for (int i = 1; i < 15; i++)
            {
                if (i % 2 == 0)
                {
                    for (int i2 = 0; i2 < 10; i2++)
                    {
                        tempTileList.Add(new tile(sideColor, -1, new List<int> { }, tempTileList[tempTileList.Count - 10].XYZLibraryCoordinatesUpRight()));
                    }
                }
                else
                {
                    for (int i2 = 0; i2 < 10; i2++)
                    {
                        tempTileList.Add(new tile(sideColor, -1, new List<int> { }, tempTileList[tempTileList.Count - 10].XYZLibraryCoordinatesDownRight()));
                    }
                }
            }

            // Ön skapas, innan detta är hela världen hav
            for (int i1 = 3; i1 < 8; i1++)
            {
                for (int i2 = 5; i2 < 13; i2++)
                {
                    tempTileList[i2 * 10 + i1].TileTypeString = "Beige";
                }
            }

            // Skogen skapas innan detta var hela ön sandig
            for (int i1 = 4; i1 < 7; i1++)
            {
                for (int i2 = 6; i2 < 12; i2++)
                {
                    tempTileList[i2 * 10 + i1].TileTypeString = "Green";
                }
            }

            // En stad och två enheter läggs ut
            tempTileList[54].CityID = 0;

            return tempTileList;
        }
        /// <summary>
        /// returnerar hela tileListen
        /// </summary>
        public List<tile> TileList
        {
            get { return tileList; }
        }
        /// <summary>
        /// returnerar den index som den givna tilen existerar i
        /// </summary>
        /// <param name="inTile"></param>
        /// <returns></returns>
        public int FindIndex_AtTile(tile inTile)
        {
            for (int i = 0; i < tileList.Count; i++)
            {
                if (tileList[i] == inTile)
                {
                    return i;
                }
            }
            return 0;
        }
        /// <summary>
        /// returnerar den tile vid givet index
        /// är den utanför index ger den en default tile
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public tile Tile_AtIndex(int index)
        {
            if (index > tileList.Count || index < 0)
            {
                return new tile();
            }
            else
            {
                return tileList[index];
            }
        }
        /// <summary>
        /// returnerar en tile vid givet indexs koordinater i spelvärlden
        /// med default scale då hexagoner har radien 1(m?)
        /// har med sig båda x, y, z då y alltid är 0
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public double[] WorldCoordinates_AtIndex(int index)
        {
            return Tile_AtIndex(index).XYZUnityCoordinates();
        }
        /// <summary>
        /// returnerar en tile vid givet indexs koordinater i spelvärlden
        /// med default scale då hexagoner har radien given
        /// har med sig båda x, y, z då y alltid är 0
        /// </summary>
        /// <param name="index"></param>
        /// <param name="radie"></param>
        /// <returns></returns>
        public double[] WorldCoordinates_AtIndex(int index, double radie)
        {
            return Tile_AtIndex(index).XYZUnityCoordinates(radie);
        }
        /// <summary>
        /// returnerar en lista av ints, med alla unitIDs
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public List<int> UnitList_AtIndex(int index)
        {
            return Tile_AtIndex(index).UnitList;
        }
        /// <summary>
        /// returnerar en tile vid givets indexs cityID
        /// Denna är -1 om tilen inte har en stad
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int CityID_AtIndex(int index)
        {
            return Tile_AtIndex(index).CityID;
        }
        /// <summary>
        /// returnerar en tile vid givet indexs color
        /// denna är "noColor" om den inte har blivit given en color
        /// men hela världen kommer antigen vara: Blå, Beige, eller Green
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string Color_AtIndex(int index)
        {
            return Tile_AtIndex(index).TileTypeString;
        }
        /// <summary>
        /// returnerar en tile vid givet indexs libraryCoordinates
        /// Dessa skall INTE användas för att rita ut hexagoner i världen
        /// utan endast för eventuell mattematik
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int[] LibraryCoordinates_AtIndex(int index)
        {
            return Tile_AtIndex(index).XYZLibraryCoordinates();
        }
        /// <summary>
        /// returnerar en tile vid givna librarycoordinater
        /// </summary>
        /// <param name="XYZCoord"></param>
        /// <returns></returns>
        public tile FindTile_AtLibraryCoordinates(int[] XYZCoord)
        {
            for (int i = 0; i < tileList.Count; i++)
            {
                if (tileList[i].XYZLibraryCoordinates() == XYZCoord)
                {
                    return tileList[i];
                }
            }
            return new tile();
        }
        /// <summary>
        /// returnerar en sträng som visar vad en tile vid givet indexs har för yield
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string tileYield_AtIndex(int index)
        {
            return Tile_AtIndex(index).TileYieldString();
        }
        /// <summary>
        /// tileListens count
        /// </summary>
        public int Count
        {
            get { return tileList.Count; }
        }
        /// <summary>
        /// returnerar den tile som har det givna cityIDn i sig
        /// </summary>
        /// <param name="cityID"></param>
        /// <returns></returns>
        public tile FindTile_AtCityID(int cityID)
        {
            for (int i = 0; i < tileList.Count; i++)
            {
                if (tileList[i].CityID == cityID)
                {
                    return tileList[i];
                }
            }
            return new tile();
        }
        /// <summary>
        /// ge två ettor till xyz, bestäm positivt eller inte, och säg vilken unit som skall göras med
        /// </summary>
        /// <param name="tileIndex"></param>
        /// <param name="unitID"></param>
        /// <param name="postiveORnegative"></param>
        /// <param name="XYZ"></param>
        public void MoveUnit(int unitID, tile tileAt, tile tileTo, unitLib uLib)
        {
            if (tileAt.unitExists(unitID) && Tile_IsAdjacentTo(tileAt, tileTo))
            {
                tileAt.removeUnit(unitID);
                tileTo.addUnit(unitID);

                uLib.unitList[uLib.FindIndexOfUnit_AtUnitID(unitID)].CurrentMovePoints--;
            }
        }
        public bool Tile_IsAdjacentTo(tile tile1, tile tile2)
        {
            int[] temp = new int[3];
            temp = tile1.XYZLibraryCoordinates();
            temp[0]++;
            temp[1]++;
            //temp[2];
            if (temp == tile2.XYZLibraryCoordinates())
            {
                return true;
            }
            temp = tile1.XYZLibraryCoordinates();
            temp[1]++;
            temp[2]++;
            //temp[2];
            if (temp == tile2.XYZLibraryCoordinates())
            {
                return true;
            }
            temp = tile1.XYZLibraryCoordinates();
            temp[2]++;
            temp[0]++;
            //temp[2];
            if (temp == tile2.XYZLibraryCoordinates())
            {
                return true;
            }
            temp = tile1.XYZLibraryCoordinates();
            temp[0]--;
            temp[1]--;
            //temp[2];
            if (temp == tile2.XYZLibraryCoordinates())
            {
                return true;
            }
            temp = tile1.XYZLibraryCoordinates();
            temp[1]--;
            temp[2]--;
            //temp[2];
            if (temp == tile2.XYZLibraryCoordinates())
            {
                return true;
            }
            temp = tile1.XYZLibraryCoordinates();
            temp[2]--;
            temp[0]--;
            //temp[2];
            if (temp == tile2.XYZLibraryCoordinates())
            {
                return true;
            }
            return false;
        }
    }
}
