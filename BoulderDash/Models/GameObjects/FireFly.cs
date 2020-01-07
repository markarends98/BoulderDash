using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoulderDash.Enums;

namespace BoulderDash.Models.GameObjects
{
    public class FireFly : GameObject
    {
        public override void Explode(Tile tile)
        {
            throw new NotImplementedException();
        }

        public override bool Fall()
        {
            return false;
        }

        public override char GetSymbol()
        {
            return (char)Symbol.FireFly;
        }

        public override bool Move(Tile destination, Direction direction)
        {
            throw new NotImplementedException();
        }

        public override bool Pickup(Tile destination, Direction direction, int score)
        {
            throw new NotImplementedException();
        }
    }
}
