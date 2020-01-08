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
        public override void Explode(Tile position)
        {
            return;
        }

        public override ConsoleColor GetColor()
        {
            return (ConsoleColor)SymbolColors.SteelWall;
        }

        public override char GetSymbol()
        {
            return (char)Symbol.SteelWall;
        }
    }
}
