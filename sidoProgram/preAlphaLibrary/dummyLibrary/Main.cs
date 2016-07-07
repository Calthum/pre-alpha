using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace preAlphaLibrary
{
    class Main
    {
        public infoLib infoLibrary;
        public tileLib tileLibrary;
        public playerLib playerLibrary;
        public cityLib cityLibrary;
        public unitLib unitLibrary;

        public Main()
        {
            initializeAll();
            DrawTileList(tileLibrary.TileList);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(tileLibrary.Tile_IsAdjacentTo(tileLibrary.Tile_AtIndex(85), tileLibrary.Tile_AtIndex(95)));
            Console.ReadKey();
        }

        public void initializeAll()
        {
            infoLibrary = new infoLib();
            tileLibrary = new tileLib();
            playerLibrary = new playerLib();
            cityLibrary = new cityLib(tileLibrary);
            unitLibrary = new unitLib(tileLibrary);
        }

        public void nextTurn()
        {
            playerLibrary.newTurn(cityLibrary);
            cityLibrary.allCitiesNewTurn(playerLibrary);
            unitLibrary.allUnitsNewTurn();
        }

        public static void DrawTileList(List<tile> tileList)
        {
            for (int i = 0; i < tileList.Count; i++)
            {
                if (tileList[i].TileTypeString == "Blue")
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                }
                if (tileList[i].TileTypeString == "Beige")
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                }
                if (tileList[i].TileTypeString == "Green")
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
                //Console.Write(i);
                Console.Write(tileList[i].XYZLibraryCoordinates()[0] + " ");
                Console.Write(tileList[i].XYZLibraryCoordinates()[1] + " ");
                Console.Write(tileList[i].XYZLibraryCoordinates()[2]);

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
                if (tileList[i].UnitList.Count > 0)
                {
                    if (tileList[i].UnitList[0] == 1)
                    {
                        Console.SetCursorPosition(x - 2, y);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("SCOUT");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    if (tileList[i].UnitList[0] == 2)
                    {
                        Console.SetCursorPosition(x - 2, y);
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("HERO1");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            }
        }
    }
}
