using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoulderDash.Enums;

namespace BoulderDash.Models.GameObjects
{
    public class Boulder : Rubble
    {
        public override void Explode(Tile position)
        {
            position.Occupant = null;
        }

        public override bool MoveTo(Tile position, Tile destination, Direction direction)
        {
            if (direction == Direction.LEFT || direction == Direction.RIGHT)
            {
                if (destination.Occupant != null)
                {
                    return false;
                }

                if (destination.Move(direction))
                {
                    destination.Occupant = this;
                    return true;
                }
            }
            return false;
        }

        public override ConsoleColor GetColor()
        {
            return (ConsoleColor)SymbolColors.Boulder;
        }

        public override char GetSymbol()
        {
            return (char)Symbol.Boulder;
        }

        public override bool Collide(Tile position, Tile collider, Direction direction)
        {
            return false;
        }

        public override bool Roam(Tile position) { return false; }
    }
}
