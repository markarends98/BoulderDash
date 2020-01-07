using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Views
{
    public class MenuView
    {
        public int ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("┌────────────────────────────────────────────────────┐");
            Console.WriteLine("| Welkom to  BoulderDash                             |");
            Console.WriteLine("|                                                    |");
            Console.WriteLine("|    Meaning of the symbols   |   Goal of the game   |");
            Console.WriteLine("|-----------------------------|----------------------|");
            Console.WriteLine("|      R : RockFord           |   Collect all        |");
            Console.WriteLine("|      M : Mud                |   Diamonds           |");
            Console.WriteLine("|      H : HardenedMud        |                      |");
            Console.WriteLine("|      B : Boulder            |                      |");
            Console.WriteLine("|      D : Diamond            |                      |");
            Console.WriteLine("|      W : Wall               |                      |");
            Console.WriteLine("|      S : Steel Wall         |                      |");
            Console.WriteLine("|      F : FireFly            |                      |");
            Console.WriteLine("|      T : TNT                |                      |");
            Console.WriteLine("|      E : Exit               |                      |");
            Console.WriteLine("└────────────────────────────────────────────────────┘");
            Console.WriteLine();
            Console.WriteLine("Choose a level, s = stop");

            while (true)
            {
                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.S)
                {
                    Environment.Exit(0);
                }

                char[] levels = { '1', '2', '3'};

                if (levels.Contains(key.KeyChar))
                {
                    return Int32.Parse(key.KeyChar.ToString());
                }

                ShowMenu();
            }
        }
    }
}
