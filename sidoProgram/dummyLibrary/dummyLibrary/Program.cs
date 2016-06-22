using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dummyLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            tilesLib tileLibrary = new tilesLib();
            DrawTileList(tileLibrary.TileList);
            Console.ReadKey();
        }

        public static void DrawTileList(List<tile> tileList)
        {
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
