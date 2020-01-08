using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoulderDash.Enums;

namespace BoulderDash.Models.GameObjects
{
    public class TNT : Rubble
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
            throw new NotImplementedException();
        }

        public override ConsoleColor GetColor()
        {
            return (ConsoleColor)SymbolColors.TNT;
        }

        public override char GetSymbol()
        {
            return (char)Symbol.TNT;
        }
    }
}
