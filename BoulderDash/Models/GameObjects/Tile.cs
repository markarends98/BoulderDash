using BoulderDash.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Models.GameObjects
{
    public class Tile
    {
        public Tile TileAbove;
        public Tile TileBeneath;
        public Tile TileRight;
        public Tile TileLeft;

        public GameObject Occupant;
        public bool IsExit;
        public bool IsExitVisible;

        public bool Move(Direction direction)
        {
            // if tile is empty
            if (Occupant == null) { return true; }

            Tile destinationTile = null;

            if (direction == Direction.UP) { destinationTile = TileAbove; }
            if (direction == Direction.DOWN) { destinationTile = TileBeneath; }
            if (direction == Direction.LEFT) { destinationTile = TileLeft; }
            if (direction == Direction.RIGHT) { destinationTile = TileRight; }

            if (destinationTile == null) { return false; };

            // check if occupant has moved
            bool moved = Occupant.MoveTo(this, destinationTile, direction);
            if (moved)
            {
                Occupant = null;
            }

            return moved;
        }

        public void Explode()
        {
            if (Occupant != null)
            {
                Occupant.Explode(this);
            }
        }

        // check if collider can take over postion
        public bool Collide(Tile collider, Direction direction)
        {
            // if tile is empty
            if (Occupant == null) { return true; }

            if (collider == null) { return false; };

            // check if occupant has collided
           return Occupant.Collide(this, collider, direction);
        }

        public bool Fall()
        {
            if (Occupant is Rubble rubble)
            {
                bool fell = rubble.Fall(this);
                if (fell)
                {
                    Occupant = null;
                }
                return fell;
            }
            return false;
        }

        public void CheckExplode()
        {
            if (Occupant is TNT tnt)
            {
                if (tnt.ExplodesCounter == ScoreBoard.Instance.MovesMade)
                {
                    Explode();
                }
            }
        }

        public void Roam()
        {
            if (Occupant is FireFly)
            {
                bool moved = Occupant.Roam(this);
                if (moved)
                {
                    Occupant = null;
                }
            }
        }

        internal ConsoleColor GetColor()
        {
            if (IsExit && IsExitVisible && Occupant == null)
            {
                return (ConsoleColor)SymbolColors.Exit;
            }
            return Occupant == null ? (ConsoleColor)SymbolColors.Empty : Occupant.GetColor();
        }

        public char GetSymbol()
        {
            if (IsExit && IsExitVisible && Occupant == null)
            {
                return (char)Symbol.Exit;
            }
            return Occupant == null ? (char)Symbol.Empty : Occupant.GetSymbol();
        }
    }
}
