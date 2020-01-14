using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoulderDash.Enums;

namespace BoulderDash.Models.GameObjects
{
    public class Diamond : Rubble
    {
        public int Value => 10;

        public override void Explode(Tile position)
        {
            position.Occupant = null;
        }

        public override bool MoveTo(Tile position, Tile destination, Direction direction)
        {
            var movedBy = GetMovedBy(position, direction);
            if (movedBy.Occupant is RockFord)
            {
                CollectDiamond(position);
                return true;
            }
            return false;
        }

        public override ConsoleColor GetColor()
        {
            return (ConsoleColor)SymbolColors.Diamond;
        }

        public override char GetSymbol()
        {
            return (char)Symbol.Diamond;
        }

        public override bool Collide(Tile position, Tile collider, Direction direction)
        {
            return false;
        }

        public void CollectDiamond(Tile position)
        {
            position.Occupant = null;
            ScoreBoard.Instance.CollectDiamond(Value);
        }

        public override bool Roam(Tile position) { return false; }
    }
}
