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
            position.Occupant = null;
        }

        public override bool MoveTo(Tile position, Tile destination, Direction direction)
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

        public override bool Collide(Tile position, Tile collider, Direction direction)
        {
            return false;
        }

        public override bool Roam(Tile position) { return false; }
    }
}
