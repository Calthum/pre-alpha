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

            for (int i1 = 3; i1 < 8; i1++)
            {
                for (int i2 = 5; i2 < 13; i2++)
                {
                    tileList[i2 * 10 + i1].Color = "Beige";
                }
            }
            
            for (int i1 = 4; i1 < 7; i1++)
            {
                for (int i2 = 6; i2 < 12; i2++)
                {
                    tileList[i2 * 10 + i1].Color = "Green";
                }
            }

            tileList[54].CityID = 0;

            for (int i = 0; i < tileList.Count; i++)
            {
                if (tileList[i].Color == "Blue")
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                if (tileList[i].Color == "Beige")
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                }
                if (tileList[i].Color == "Green")
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                }
                int x = Convert.ToInt32(tileList[i].XZcoordinates(4)[0] + 3);
                int y = Convert.ToInt32(tileList[i].XZcoordinates(2.3)[1] + 5);
                Console.SetCursorPosition(x - 1, y - 1);
                Console.Write("   ");
                Console.SetCursorPosition(x - 1, y + 1);
                Console.Write("   ");
                Console.SetCursorPosition(x - 2, y);
                Console.Write(" " + i);
                if (i < 10)
                {
                    Console.Write(" ");
                }
                if (i < 100)
                {
                    Console.Write(" ");
                }
                Console.Write(" ");

                if (tileList[i].CityID == 0)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.SetCursorPosition(x - 2, y - 2);
                    Console.Write("     ");
                    Console.SetCursorPosition(x - 3, y - 1);
                    Console.Write("       ");
                    Console.SetCursorPosition(x - 3, y + 1);
                    Console.Write("       ");
                    Console.SetCursorPosition(x - 2, y + 2);
                    Console.Write("     ");
                    Console.SetCursorPosition(x - 3, y);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write(" town  ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }
}
