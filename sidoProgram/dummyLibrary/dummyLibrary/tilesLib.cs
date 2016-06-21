using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dummyLibrary
{
    class tilesLib
    {
        private List<tile> tileList;

        /// <summary>
        /// skapa ett nytt library med tiles
        /// </summary>
        public tilesLib()
        {
            string sideColor = "Blue";
            List<int> emptyUnitIDs = new List<int> { };
            tileList = new List<tile>();
            for (int i = 0; i < 10; i++)
            {
                tileList.Add(new tile(sideColor, -1, emptyUnitIDs, 0, i, i));
            }
            for (int i = 1; i < 15; i++)
            {
                if (i % 2 == 0)
                {
                    for (int i2 = 0; i2 < 10; i2++)
                    {
                        tileList.Add(new tile(sideColor, -1, emptyUnitIDs, tileList[tileList.Count - 10].XYZGameCoordinatesUpRight()));
                    }
                }
                else
                {
                    for (int i2 = 0; i2 < 10; i2++)
                    {
                        tileList.Add(new tile(sideColor, -1, emptyUnitIDs, tileList[tileList.Count - 10].XYZGameCoordinatesDownRight()));
                    }
                }
            }

            for (int i = 0; i < tileList.Count; i++)
            {
                Console.SetCursorPosition(Convert.ToInt32(tileList[i].XZcoordinates(4)[0] + 1), Convert.ToInt32(tileList[i].XZcoordinates(4)[1] + 4));
                Console.Write(i);
            }
        }
    }
}
