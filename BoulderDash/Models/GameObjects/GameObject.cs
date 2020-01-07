using BoulderDash.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoulderDash.Models.GameObjects
{
    public abstract class GameObject
    {
        public abstract bool Pickup(Tile destination, Direction direction, int score);
        public abstract bool Move(Tile destination, Direction direction);
        public abstract bool Fall();
        public abstract void Explode(Tile centerTile);
        public abstract char GetSymbol();
    }
}