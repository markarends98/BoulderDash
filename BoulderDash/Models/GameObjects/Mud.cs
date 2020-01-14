using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoulderDash.Enums;

namespace BoulderDash.Models.GameObjects
{
    public class Mud : GameObject
    {
        public override void Explode(Tile position)
        {
            position.Occupant = null;
        }

        public override bool MoveTo(Tile position, Tile destination, Direction direction)
        {
            var movedBy = GetMovedBy(position, direction);
            if (movedBy.Occupant is RockFord)
            {
                return true;
            }
            return false;
        }

        public override ConsoleColor GetColor()
        {
            return (ConsoleColor)SymbolColors.Mud;
        }

        public override char GetSymbol()
        {
            return (char)Symbol.Mud;
        }

        public override bool Collide(Tile position, Tile collider, Direction direction)
        {
            return false;
        }

        public override bool Roam(Tile position) { return false; }
    }
}
