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
        public int ExplodesCounter { get; set; }

        public TNT()
        {
            ExplodesCounter = 30;
            BreaksFall = false;
        }

        public override void Explode(Tile position)
        {
            position.Occupant = null;

            // top row
            position.TileAbove.Explode();
            position.TileAbove.TileLeft.Explode();
            position.TileAbove.TileRight.Explode();

            // center row
            position.TileRight.Explode();
            position.TileLeft.Explode();

            // bottom row
            position.TileBeneath.Explode();
            position.TileBeneath.TileLeft.Explode();
            position.TileBeneath.TileRight.Explode();
        }

        public override bool MoveTo(Tile position, Tile destination, Direction direction)
        {
            var movedBy = GetMovedBy(position, direction);
            if (movedBy.Occupant is RockFord)
            {
                position.Occupant = null;
                return true;
            }
            return false;
        }

        public override ConsoleColor GetColor()
        {
            return (ConsoleColor)SymbolColors.TNT;
        }

        public override char GetSymbol()
        {
            return (char)Symbol.TNT;
        }

        public override bool Collide(Tile position, Tile collider, Direction direction)
        {
            if (collider.Occupant is Rubble)
            {
                Explode(collider);
                return true;
            }
            return false;
        }

        public override void AfterFall(bool hasFallen, Tile newPosition)
        {
            if (!hasFallen && IsFalling)
            {
                Explode(newPosition);
            }
        }

        public override bool Roam(Tile position) { return false; }
    }
}
