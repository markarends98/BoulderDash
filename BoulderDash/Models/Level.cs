using BoulderDash.Enums;
using BoulderDash.Models.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Models
{
    public class Level
    {
        public Tile First;

        public void AddTile(Tile tile, int PosX, int PosY)
        {
            if (First == null)
            {
                First = tile;
                return;
            }

            // get individual tiles
            var tileAbove = GetTile(PosX, PosY - 1);
            var tileRight = GetTile(PosX + 1, PosY);
            var tileBeneath = GetTile(PosX, PosY + 1);
            var tileLeft = GetTile(PosX - 1, PosY);

            // link tiles to eachother
            LinkTiles(tile, tileAbove, tileRight, tileBeneath, tileLeft);
        }

        private void LinkTiles(Tile tile, Tile tileAbove, Tile tileRight, Tile tileBeneath, Tile tileLeft)
        {
            if (tileAbove != null) tileAbove.TileBeneath = tile;
            if (tileRight != null) tileRight.TileLeft = tile;
            if (tileBeneath != null) tileBeneath.TileAbove = tile;
            if (tileLeft != null) tileLeft.TileRight = tile;

            tile.TileAbove = tileAbove;
            tile.TileRight = tileRight;
            tile.TileBeneath = tileBeneath;
            tile.TileLeft = tileLeft;
        }

        public void MovePlayer(Direction direction)
        {
            this.GetTiles().Find(t => t.Occupant is RockFord).Move(direction);
        }

        public Tile GetTile(int PosX, int PosY)
        {
            var currentTile = First;

            // when out of index return null
            if ((PosX == -1) || (PosY == -1))
            {
                return null;
            }

            // iterate to the right trough linked list
            for (int i = 0; i < PosX; i++)
            {
                if (currentTile != null)
                {
                    currentTile = currentTile.TileRight;
                }
            }

            // iterate down trough linked list
            for (int i = 0; i < PosY; i++)
            {
                if (currentTile != null)
                {
                    currentTile = currentTile.TileBeneath;
                }
            }

            return currentTile;
        }

        public List<Tile> GetTiles()
        {
            var tiles = new List<Tile>();

            int PosX = 0;
            int PosY = 0;

            // get first tile
            var currentTile = GetTile(PosX, PosY);

            while (currentTile != null)
            {
                tiles.Add(currentTile);

                // iterate to the right trough linked list
                if (currentTile.TileRight != null)
                {
                    PosX++;
                }
                else
                {
                    // iterate 1 row down and begin on front
                    PosX = 0;
                    PosY++;
                }

                currentTile = GetTile(PosX, PosY);
            }

            return tiles;
        }

        public bool IsLevelComplete()
        {
            return GetTiles().Any(t => t.Occupant is Diamond);
        }
    }
}
