using BoulderDash.Enums;
using BoulderDash.Models;
using BoulderDash.Models.GameObjects;
using BoulderDash.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace BoulderDash.Controllers
{
    public class GameController
    {
        private GameView _gameView;
        private MenuView _menuView;
        private Level _level;
        private int chosenLevel;

        public GameController()
        {
            _gameView = new GameView();
            _menuView = new MenuView();
        }

        public void StartGame()
        {
            chosenLevel = _menuView.ShowMenu();
            playGameLoop();
        }

        private void playGameLoop()
        {
            BuildLevel();
            while (true)
            {
                var keyPressed = Console.ReadKey(true).Key;

                if (keyPressed == (ConsoleKey)Direction.UP)
                    _level.MovePlayer(Direction.UP);
                if (keyPressed == (ConsoleKey)Direction.RIGHT)
                    _level.MovePlayer(Direction.RIGHT);
                if (keyPressed == (ConsoleKey)Direction.DOWN)
                    _level.MovePlayer(Direction.DOWN);
                if (keyPressed == (ConsoleKey)Direction.LEFT)
                    _level.MovePlayer(Direction.LEFT);

                _gameView.RenderLevel(_level);
            }
        }

        private void BuildLevel()
        {
            _level = new Level();

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
                            tile.Occupant = new Exit();
                            break;
                        default:
                            break;
                    }

                    _level.AddTile(tile, x, y);
                }
            }
        }
    }
}
