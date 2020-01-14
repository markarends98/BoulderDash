using BoulderDash.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Models.GameObjects
{
    public class HardenedMud : Rubble
    {
        public int DigHealth { get; set; }

        public HardenedMud()
        {
            DigHealth = 3;
        }

        public override bool CanFallDown(Tile position)
        {
            if (position.TileBeneath.Occupant == null)
            {
                return !IsSupported(position);
            }
            return false;
        }

        private bool IsSupported(Tile position)
        {
            bool supportedOnTop = false;
            bool supportedOnLeft = false;
            bool supportedOnRight = false;
            if (position.TileLeft.Occupant != null)
            {
                if (position.TileLeft.Occupant is Mud || position.TileLeft.Occupant is HardenedMud)
                {
                    supportedOnLeft = true;
                }
            }

            if (position.TileRight.Occupant != null)
            {
                if (position.TileRight.Occupant is Mud || position.TileRight.Occupant is HardenedMud)
                {
                    supportedOnRight = true;
                }
            }

            if (position.TileAbove.Occupant != null)
            {
                if (position.TileAbove.Occupant is Mud || position.TileAbove.Occupant is HardenedMud)
                {
                    supportedOnTop = true;
                }
            }

            List<bool> boolList = new List<bool> { supportedOnTop, supportedOnLeft, supportedOnRight };
            return boolList.Count(b => b) >= 2;
        }

        public override bool MoveTo(Tile position, Tile destination, Direction direction)
        {
            if (DigHealth == 0)
            {
                return true;
            }

            DigHealth--;
            return false;
        }

        public override ConsoleColor GetColor()
        {
            return (ConsoleColor)SymbolColors.HardenedMud;
        }

        public override char GetSymbol()
        {
            return (char)Symbol.HardenedMud;
        }

        public override void Explode(Tile position)
        {
            position.Occupant = null;
        }

        public override bool Collide(Tile position, Tile collider, Direction direction)
        {
            return false;
        }

        public override bool Roam(Tile position) { return false; }
    }
}
