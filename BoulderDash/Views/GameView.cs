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
        }
    }
}
