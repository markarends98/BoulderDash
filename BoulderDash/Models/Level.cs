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
        public Tile First { get; set; }
        public bool ExitVisible { get; private set; }
        public Level(int chosenLevel)
        {
            BuildLevel(chosenLevel);
            ExitVisible = false;
        }

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

        public bool MovePlayer(Direction direction)
        {
            if (IsAlive())
            {
                this.GetTiles().Find(t => t.Occupant is RockFord).Move(direction);
                return true;
            }
            return false;
        }

        private void checkTNT()
        {
            this.GetTiles().FindAll(t => t.Occupant is TNT)
                    .ForEach(t => t.CheckExplode());
        }

        public void CheckExit()
        {
            if (!ExitVisible && ScoreBoard.Instance.DiamondsLeft == 0)
            {
                UnlockExit();
            }
        }

        public void Update()
        {
            letObjectsFall();
            letObjectsRoam();
            checkTNT();
        }

        private Tile GetTile(int PosX, int PosY)
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

        private void letObjectsFall()
        {
            this.GetTiles().FindAll(t => t.Occupant is Rubble)
                .ForEach(t => t.Fall());
        }

        private void letObjectsRoam()
        {
            this.GetTiles().FindAll(t => t.Occupant is FireFly)
                .ForEach(t => t.Roam());
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

        public int GetDiamondAmount()
        {
            return GetTiles().Count(a => a.Occupant is Diamond);
        }

        public bool IsLevelComplete()
        {
            Tile tile = GetTiles().FirstOrDefault(t => t.Occupant is RockFord);
            if (tile != null)
            {
                return tile.IsExit && tile.IsExitVisible;
            }
            return false;
        }

        public bool IsAlive() { 
            return GetTiles().FirstOrDefault(t => t.Occupant is RockFord) != null; 
        }

        public void UnlockExit()
        {
            var tile = GetTiles().Find(t => t.IsExit);
            tile.IsExitVisible = true;
            ExitVisible = true;
        }

        private void BuildLevel(int chosenLevel)
        {
            var levelData = LevelData.GetLevel(chosenLevel);
            int maxX = LevelData.Level_width;
            int maxY = LevelData.Level_height;

            for (int y = 0; y < maxY; y++)
            {
                for (int x = 0; x < maxX; x++)
                {
                    char ch = (char)levelData.GetValue(y, x);

                    Tile tile = new Tile();

                    switch (ch)
                    {
                        case (char)Symbol.Rockford:
                            tile.Occupant = new RockFord();
                            break;
                        case (char)Symbol.Mud:
                            tile.Occupant = new Mud();
                            break;
                        case (char)Symbol.HardenedMud:
                            tile.Occupant = new HardenedMud();
                            break;
                        case (char)Symbol.Boulder:
                            tile.Occupant = new Boulder();
                            break;
                        case (char)Symbol.Diamond:
                            tile.Occupant = new Diamond();
                            break;
                        case (char)Symbol.Wall:
                            tile.Occupant = new Wall();
                            break;
                        case (char)Symbol.SteelWall:
                            tile.Occupant = new SteelWall();
                            break;
                        case (char)Symbol.FireFly:
                            tile.Occupant = new FireFly();
                            break;
                        case (char)Symbol.TNT:
                            tile.Occupant = new TNT();
                            break;
                        case (char)Symbol.Exit:
                            tile.IsExit = true;
                            break;
                        default:
                            break;
                    }

                    AddTile(tile, x, y);
                }
            }
        }
    }
}
