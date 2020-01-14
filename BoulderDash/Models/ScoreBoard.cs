using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Models
{
    public sealed class ScoreBoard
    {
        public int Score { get; private set; }
        public int DiamondAmount { get; private set; }
        public int DiamondsLeft { get; private set; }
        public static ScoreBoard Instance { get; } = new ScoreBoard();
        public bool LevelComplete { get; private set; }
        public int MovesMade { get; private set; }

        static ScoreBoard() { }
        private ScoreBoard() { }

        public void CollectDiamond(int score)
        {
            DiamondsLeft--;
            AddScore(score);
        }

        public void AddScore(int amount)
        {
            Score += amount;
        }

        public void SetLevelComplete()
        {
            LevelComplete = true;
        }

        public void InitScoreboard(int amount)
        {
            Score = 0;
            DiamondAmount = amount;
            DiamondsLeft = amount;
            LevelComplete = false;
            MovesMade = 0;
        }

        public void AddMove()
        {
            MovesMade++;
        }
    }
}
