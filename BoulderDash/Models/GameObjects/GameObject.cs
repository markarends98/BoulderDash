using BoulderDash.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoulderDash.Models.GameObjects
{
    public abstract class GameObject
    {
        /// <summary>
        /// behaviour to handle picking up items etc.
        /// </summary>
        /// <param name="destination">tile containing the gameobject to pickup</param>
        /// <param name="direction">direction to movement was going</param>
        /// <param name="score">currentscore of player</param>
        /// <returns>has gameobject been pickuped</returns>
        public abstract bool Pickup(Tile destination, Direction direction, int score);

        /// <summary>
        /// behaviour to move the gameobject to a destination or when an gameobject wants to move onto the current gameobject
        /// </summary>
        /// <param name="destination">tile to move to</param>
        /// <param name="direction">direction to movement was going</param>
        /// <returns>has gameobject moved</returns>
        public abstract bool Move(Tile destination, Direction direction);

        /// <summary>
        /// behaviour to make gameobject explode
        /// </summary>
        /// <param name="tile">tile where the explosion takes place</param>
        public abstract void Explode(Tile position);

        /// <summary>
        /// get the symbol of the gameobject
        /// </summary>
        /// <returns>symbol</returns>
        public abstract char GetSymbol();

        /// <summary>
        /// get the foreground color of the gameobject
        /// </summary>
        /// <returns>color</returns>
        public abstract ConsoleColor GetColor();
    }
}