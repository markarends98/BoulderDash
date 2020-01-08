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
        public bool IsVisible { get; set; }
        public GameObject Occupant { get; set; }

        public Exit()
        {
            IsVisible = false;
            Occupant = null;
        }

        public override void Explode(Tile position)
        {
            return;
        }

        public override bool Move(Tile destination, Direction direction)
        {
            throw new NotImplementedException();
        }

        public override bool Pickup(Tile destination, Direction direction, int score)
        {
            return false;
        }

        public override ConsoleColor GetColor()
        {
            if (Occupant != null)
            {
                return Occupant.GetColor();
            }
            if (!IsVisible)
            {
                return (ConsoleColor)SymbolColors.Empty;
            }
            return (ConsoleColor)SymbolColors.Exit;
        }

        public override char GetSymbol()
        {
            if (Occupant != null)
            {
                return Occupant.GetSymbol();
            }
            if (!IsVisible)
            {
                return (char)Symbol.Empty;
            }
            return (char)Symbol.Exit;
        }
    }
}
