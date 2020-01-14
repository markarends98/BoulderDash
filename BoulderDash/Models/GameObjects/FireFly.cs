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
        private Direction FaceDirection { get; set; }

        public FireFly()
        {
            IsSquashable = true;
            BreaksFall = false;
            FaceDirection = Direction.RIGHT;
        }
        public override void Explode(Tile position)
        {
            position.Occupant = null;

            // top row
            position.TileAbove.Explode();
            position.TileAbove.TileLeft.Explode();
            position.TileAbove.TileRight.Explode();

            // center row
            position.TileRight.Explode();
            position.TileLeft.Explode();

            // bottom row
            position.TileBeneath.Explode();
            position.TileBeneath.TileLeft.Explode();
            position.TileBeneath.TileRight.Explode();
        }

        public override bool MoveTo(Tile position, Tile destination, Direction direction)
        {
            return false;
        }

        public override ConsoleColor GetColor()
        {
            return (ConsoleColor)SymbolColors.FireFly;
        }

        public override char GetSymbol()
        {
            return (char)Symbol.FireFly;
        }

        public override bool Collide(Tile position, Tile collider, Direction direction)
        {
            if (collider.Occupant is Boulder || collider.Occupant is Diamond)
            {
                Explode(position);
                return true;
            }
            return false;
        }

        public void Die(Tile position)
        {
            position.Occupant = null;
            ScoreBoard.Instance.AddScore(250);
        }

        public override bool Roam(Tile position)
        {
            Tile destination = GetDestination(position);
            if (destination != null)
            {
                destination.Occupant = this;
                if (RockFordNearby(destination))
                {
                    destination.Explode();
                }
                return true;
            }
            return false;
        }

        private bool RockFordNearby(Tile destination)
        {
            if (destination.TileAbove != null && destination.TileAbove.Occupant is RockFord)
            {
                return true;
            }
            else if (destination.TileRight != null && destination.TileRight.Occupant is RockFord)
            {
                return true;
            }
            else if (destination.TileBeneath != null && destination.TileBeneath.Occupant is RockFord)
            {
                return true;
            }
            else if (destination.TileLeft != null && destination.TileLeft.Occupant is RockFord)
            {
                return true;
            }
            return false;
        }

        private Tile GetDestination(Tile position)
        {
            if (FaceDirection == Direction.RIGHT) // facing right
            {
                if (position.TileAbove != null && position.TileAbove.Occupant == null)  //check can move left
                {
                    FaceDirection = Direction.UP;
                    return position.TileAbove;
                }
                else if (position.TileRight != null && position.TileRight.Occupant == null) // check current direction
                {
                    FaceDirection = Direction.RIGHT;
                    return position.TileRight;
                }else if (position.TileBeneath != null && position.TileBeneath.Occupant == null) // check can go right
                {
                    FaceDirection = Direction.DOWN;
                    return position.TileBeneath;
                }
                else if (position.TileLeft != null && position.TileLeft.Occupant == null) // check can turn around
                {
                    FaceDirection = Direction.LEFT;
                    return position.TileLeft;
                }
            }
            else if (FaceDirection == Direction.DOWN) // facing down
            {
                if (position.TileRight != null && position.TileRight.Occupant == null)  //check can move left
                {
                    FaceDirection = Direction.RIGHT;
                    return position.TileRight;
                }
                else if (position.TileBeneath != null && position.TileBeneath.Occupant == null) // check current direction
                {
                    FaceDirection = Direction.DOWN;
                    return position.TileBeneath;
                }
                else if (position.TileLeft != null && position.TileLeft.Occupant == null) // check can go right
                {
                    FaceDirection = Direction.LEFT;
                    return position.TileLeft;
                }
                else if (position.TileAbove != null && position.TileAbove.Occupant == null) // check can turn around
                {
                    FaceDirection = Direction.UP;
                    return position.TileAbove;
                }
            }
            else if (FaceDirection == Direction.LEFT) // facing left
            {
                if (position.TileBeneath != null && position.TileBeneath.Occupant == null)  //check can move left
                {
                    FaceDirection = Direction.DOWN;
                    return position.TileBeneath;
                }
                else if (position.TileLeft != null && position.TileLeft.Occupant == null) // check current direction
                {
                    FaceDirection = Direction.LEFT;
                    return position.TileLeft;
                }
                else if (position.TileAbove != null && position.TileAbove.Occupant == null) // check can go right
                {
                    FaceDirection = Direction.UP;
                    return position.TileAbove;
                }
                else if (position.TileRight != null && position.TileRight.Occupant == null) // check can turn around
                {
                    FaceDirection = Direction.RIGHT;
                    return position.TileRight;
                }
            }
            else if (FaceDirection == Direction.UP) // facing up
            {
                if (position.TileLeft != null && position.TileLeft.Occupant == null)  //check can move left
                {
                    FaceDirection = Direction.LEFT;
                    return position.TileLeft;
                }
                else if (position.TileAbove != null && position.TileAbove.Occupant == null) // check current direction
                {
                    FaceDirection = Direction.UP;
                    return position.TileAbove;
                }
                else if (position.TileRight != null && position.TileRight.Occupant == null) // check can go right
                {
                    FaceDirection = Direction.RIGHT;
                    return position.TileRight;
                }
                else if (position.TileBeneath != null && position.TileBeneath.Occupant == null) // check can turn around
                {
                    FaceDirection = Direction.DOWN;
                    return position.TileBeneath;
                }
            }
            return null;
        }

    }
}
