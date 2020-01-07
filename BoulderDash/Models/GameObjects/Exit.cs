using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoulderDash.Enums;

namespace BoulderDash.Models.GameObjects
{
    public class Exit : GameObject
    {
        public bool IsVisible = false;

        public override void Explode(Tile tile)
        {
            return;
        }

        public override bool Fall()
        {
            return false;
        }

        public override char GetSymbol()
        {
            if (!IsVisible)
            {
                return (char)Symbol.SteelWall;
            }
            return (char)Symbol.Exit;
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
