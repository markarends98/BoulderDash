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
        private int _chosenLevel;

        public GameController()
        {
            _gameView = new GameView();
            _menuView = new MenuView();
        }

        public void StartGame()
        {
            _chosenLevel = _menuView.ShowMenu();
            playGameLoop();
        }

        private void playGameLoop()
        {
            _level = new Level(_chosenLevel);
            ScoreBoard.Instance.InitScoreboard(_level.GetDiamondAmount());
            _gameView.RenderLevel(_level);

            while (true)
            {
                ConsoleKey keyPressed = Console.ReadKey(true).Key;

                bool render = keyPressed switch
                {
                    (ConsoleKey)Direction.UP => _level.MovePlayer(Direction.UP),
                    (ConsoleKey)Direction.DOWN => _level.MovePlayer(Direction.DOWN),
                    (ConsoleKey)Direction.LEFT => _level.MovePlayer(Direction.LEFT),
                    (ConsoleKey)Direction.RIGHT => _level.MovePlayer(Direction.RIGHT),
                    (ConsoleKey)Direction.WAIT => true,
                    _ => false,
                };

                if (render)
                {
                    ScoreBoard.Instance.AddMove();

                    // check if should show the exit
                    _level.CheckExit();

                    // draw player movement
                    _gameView.RenderLevel(_level);

                    // update level
                    _level.Update();

                    // show delay for drawing animation
                    Thread.Sleep(250);

                    // draw updated objects
                    _gameView.RenderLevel(_level);
                }

                if (!_level.IsAlive())
                {
                    bool playAgain = _gameView.ShowGameOver();
                    if (playAgain)
                    {
                        playGameLoop();
                    }
                    else
                    {
                        RestartLevel();
                    }
                    break;
                }

                if (_level.IsLevelComplete())
                {
                    bool playAgain = _gameView.ShowLevelComplete();
                    if (playAgain)
                    {
                        playGameLoop();
                    }
                    else
                    {
                        RestartLevel();
                    }
                    break;
                }
            }
        }

        private void RestartLevel()
        {
            _gameView = new GameView();
            _menuView = new MenuView();
            StartGame();
        }
    }
}
