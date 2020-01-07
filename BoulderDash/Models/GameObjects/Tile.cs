﻿using BoulderDash.Enums;
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

            // check if block has moved
            bool moved = Occupant.Move(destinationTile, direction);
            if (moved)
            {
                Occupant = null;
            }

            return moved;
        }

        public char GetSymbol()
        {
            return Occupant == null ? (char)Symbol.Empty : Occupant.GetSymbol();
        }
    }
}