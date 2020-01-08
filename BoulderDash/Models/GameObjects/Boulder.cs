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
            throw new NotImplementedException();
        }

        public override bool Move(Tile destination, Direction direction)
        {
            if (direction == Direction.LEFT || direction == Direction.RIGHT)
            {
                if(destination.Occupant != null)
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

        public override bool Pickup(Tile destination, Direction direction, int score)
        {
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
    }
}
