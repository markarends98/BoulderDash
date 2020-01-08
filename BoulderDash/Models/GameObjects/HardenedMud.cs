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
                if (position.TileLeft.Occupant is Mud || position.TileLeft.Occupant is HardenedMud
                    || position.TileLeft.Occupant is Boulder || position.TileLeft.Occupant is Diamond)
                {
                    supportedOnLeft = true;
                }
            }

            if (position.TileRight.Occupant != null)
            {
                if (position.TileRight.Occupant is Mud || position.TileRight.Occupant is HardenedMud
                    || position.TileRight.Occupant is Boulder || position.TileRight.Occupant is Diamond)
                {
                    supportedOnRight = true;
                }
            }

            if (position.TileAbove.Occupant != null)
            {
                if (position.TileAbove.Occupant is Mud || position.TileAbove.Occupant is HardenedMud
                    || position.TileAbove.Occupant is Boulder || position.TileAbove.Occupant is Diamond)
                {
                    supportedOnTop = true;
                }
            }

            List<bool> boolList = new List<bool> { supportedOnTop, supportedOnLeft, supportedOnRight };
            return boolList.Count(b => b) >= 2;
        }

        public override bool Move(Tile destination, Direction direction)
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

        public override bool Pickup(Tile destination, Direction direction, int score)
        {
            return false;
        }

        public override void Explode(Tile position)
        {
            throw new NotImplementedException();
        }
    }
}
