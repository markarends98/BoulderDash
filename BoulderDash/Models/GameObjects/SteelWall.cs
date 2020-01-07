using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoulderDash.Enums;

namespace BoulderDash.Models.GameObjects
{
    public class SteelWall : Wall
    {
        public override void Explode(Tile tile)
        {
            return;
        }

        public override char GetSymbol()
        {
            return (char)Symbol.SteelWall;
        }
    }
}
