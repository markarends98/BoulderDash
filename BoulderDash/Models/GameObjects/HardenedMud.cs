using BoulderDash.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Models.GameObjects
{
    public class HardenedMud : Mud
    {
        public new int DigHealth => 3;

        public override bool Fall()
        {
            throw new NotImplementedException();
        }

        public override char GetSymbol()
        {
            return (char)Symbol.HardenedMud;
        }

        public override bool Move(Tile destination, Direction direction)
        {
            throw new NotImplementedException();
        }
    }
}
