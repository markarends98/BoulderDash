using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoulderDash.Enums;

namespace BoulderDash.Models.GameObjects
{
    public class Mud : GameObject
    {
        public int DigHealth => 1;

        public override void Explode(Tile tile)
        {
            throw new NotImplementedException();
        }

        public override bool Fall()
        {
            throw new NotImplementedException();
        }

        public override char GetSymbol()
        {
            return (char)Symbol.Mud;
        }

        public override bool Move(Tile destination, Direction direction)
        {
            throw new NotImplementedException();
        }

        public override bool Pickup(Tile destination, Direction direction, int score)
        {
            return false;
        }
    }
}
