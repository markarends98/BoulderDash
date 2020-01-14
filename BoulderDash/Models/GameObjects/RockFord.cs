using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoulderDash.Enums;

namespace BoulderDash.Models.GameObjects
{
    public class RockFord : GameObject
    {
        public RockFord()
        {
            IsSquashable = true;
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
            bool moved = destination.Move(direction);
            if (moved)
            {
                destination.Occupant = this;
            }
            return moved;
        }

        public override ConsoleColor GetColor()
        {
            return (ConsoleColor)SymbolColors.Rockford;
        }

        public override char GetSymbol()
        {
            return (char)Symbol.Rockford;
        }

        public override bool Collide(Tile position, Tile collider, Direction direction)
        {
            if (collider.Occupant is Rubble)
            {
                if (collider.Occupant is Diamond diamond)
                {
                    diamond.CollectDiamond(collider);
                    return false;
                }

                if (collider.Occupant is TNT)
                {
                    collider.Explode();
                    return false;
                }

                position.Explode();
                return true;
            }
            return false;
        }

        public override bool Roam(Tile position) { return false; }
    }
}
