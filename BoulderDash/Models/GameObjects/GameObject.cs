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
        /// bool to check if object can be squashed by other objects
        /// </summary>
        public bool IsSquashable { get; set; }

        public bool BreaksFall { get; set; }

        public GameObject()
        {
            BreaksFall = true;
        }

        /// <summary>
        /// behaviour to handle collisions with a gameobject
        /// </summary>
        /// <param name="position">position of gameobject</param>
        /// <param name="collider">position of colliding gameobject</param>
        /// <param name="direction">direction to movement was going</param>
        /// <returns>has gameobject moved</returns>
        public abstract bool Collide(Tile position, Tile collider, Direction direction);

        /// <summary>
        /// behaviour to move the gameobject to a destination or when an gameobject wants to move onto the current gameobject
        /// </summary>
        /// <param name="position">current position of gameobject</param>
        /// <param name="destination">tile to move to</param>
        /// <param name="direction">direction to movement was going</param>
        /// <returns>has gameobject moved</returns>
        public abstract bool MoveTo(Tile position, Tile destination, Direction direction);

        /// <summary>
        /// behaviour to make gameobject explode
        /// </summary>
        /// <param name="position">tile where the explosion takes place</param>
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

        /// <summary>
        /// get the foreground color of the gameobject
        /// </summary>
        /// <param name="position">current position for gameobject</param>
        public abstract bool Roam(Tile position);

        public Tile GetMovedBy(Tile position, Direction direction)
        {
            if (direction == Direction.DOWN)
            {
                return position.TileAbove;
            }else if (direction == Direction.UP)
            {
                return position.TileBeneath;
            }
            else if (direction == Direction.RIGHT)
            {
                return position.TileLeft;
            }
            else if(direction == Direction.LEFT)
            {
                return position.TileRight;
            }
            return null;
        }

        public Tile GetDestination(Tile position, Direction direction)
        {
            if (position == null)
                return null;

            switch (direction)
            {
                case Direction.DOWN:
                    return position.TileBeneath;
                case Direction.LEFT:
                    return position.TileLeft;
                case Direction.RIGHT:
                    return position.TileRight;
                case Direction.UP:
                    return position.TileAbove;
                case Direction.WAIT:
                    return position;
                default:
                    return null;
            }
        }
    }
}