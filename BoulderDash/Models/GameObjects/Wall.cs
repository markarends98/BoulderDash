using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoulderDash.Enums;

namespace BoulderDash.Models.GameObjects
{
    public class Wall : GameObject
    {
        public override void Explode(Tile position)
        {
            throw new NotImplementedException();
        }

        public override bool Move(Tile destination, Direction direction)
        {
            return false;
        }

        public override bool Pickup(Tile destination, Direction direction, int score)
        {
            return false;
        }
        public override ConsoleColor GetColor()
        {
            return (ConsoleColor)SymbolColors.Wall;
        }

        public override char GetSymbol()
        {
            return (char)Symbol.Wall;
        }
    }
}
