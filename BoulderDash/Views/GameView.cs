using BoulderDash.Enums;
using BoulderDash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Views
{
    public class GameView
    {
        public void RenderLevel(Level level)
        {
            Console.Clear();

            //render header
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Diamonds left: {ScoreBoard.Instance.DiamondsLeft}     Score: {ScoreBoard.Instance.Score}        Moves: {ScoreBoard.Instance.MovesMade}");

            //render grid
            level.GetTiles().ForEach(tile => {
                char symbol = tile.GetSymbol();
                Console.ForegroundColor = tile.GetColor();
                Console.Write(symbol);

                if (tile.TileRight == null) 
                {
                    Console.Write("\n");
                }
            });

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine("> Use the arrow keys to move, press spacebar to wait a turn");
        }

        public bool ShowGameOver()
        {
            Console.WriteLine();
            Console.WriteLine("#######################################");
            Console.WriteLine("#                                     #");
            Console.WriteLine("#              GAME OVER              #");
            Console.WriteLine("#                                     #");
            Console.WriteLine("#######################################");

            ConsoleKey key;
            do
            {
                Console.WriteLine();
                Console.WriteLine("> Try again? (y/n)");
                key = Console.ReadKey().Key;
                if (key == ConsoleKey.Y || key == ConsoleKey.N)
                {
                    break;
                }
            } while (true);

            return key == ConsoleKey.Y;
        }

        public bool ShowLevelComplete()
        {
            Console.WriteLine();
            Console.WriteLine("#######################################");
            Console.WriteLine("#                                     #");
            Console.WriteLine("#          LEVEL COMPLETE!!!          #");
            Console.WriteLine("#                                     #");
            Console.WriteLine("#######################################");

            ConsoleKey key;
            do
            {
                Console.WriteLine();
                Console.WriteLine("> Play again? (y/n)");
                key = Console.ReadKey().Key;
                if (key == ConsoleKey.Y || key == ConsoleKey.N)
                {
                    break;
                }
            } while (true);

            return key == ConsoleKey.Y;
        }
    }
}
