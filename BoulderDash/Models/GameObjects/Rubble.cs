using BoulderDash.Enums;

namespace BoulderDash.Models.GameObjects
{
    public abstract class Rubble : GameObject
    {
        public bool IsFalling { get; set; }
        protected const int FallLeft = 2;
        protected const int FallRight = 1;
        protected const int FallNot = 0;

        /// <summary>
        /// behaviour to let gameobject fall
        /// </summary>
        /// <param name="position">position of gameobject</param>
        /// <returns>if has fallen</returns>
        public virtual bool Fall(Tile position)
        {
            // execute fall
            Tile newPosition = DoFall(position);

            // check if object has fallen
            bool hasFallen = (position != newPosition);

            // handle things after falling
            AfterFall(hasFallen, newPosition);
            return hasFallen;
        }

        public virtual void AfterFall(bool hasFallen, Tile newPosition)
        {
            if (hasFallen)
            {
                if (newPosition.TileBeneath.Occupant != null && newPosition.TileBeneath.Occupant.BreaksFall)
                {
                    IsFalling = false;
                }
            }
        }

        public virtual Tile DoFall(Tile position)
        {
            Tile newPosition = position;

            if (CanFallDown(position))
            {
                IsFalling = true;
            }

            if (IsFalling)
            {
                if (position.TileBeneath != null && position.TileBeneath.Occupant != null)
                {
                    bool collides = position.TileBeneath.Collide(position, Direction.DOWN);
                    if (collides)
                    {
                        newPosition = position.TileBeneath;
                    }
                }
                else
                {
                    newPosition = position.TileBeneath;
                }
            }

            if (position == newPosition)
            {
                int slide = TrySlideOf(position);
                if (slide != FallNot)
                {
                    if (slide == FallRight)
                    {
                        newPosition = position.TileBeneath.TileRight;

                    }
                    else if (slide == FallLeft)
                    {
                        newPosition = position.TileBeneath.TileLeft;
                    }
                }
            }

            if (position != newPosition)
            {
                newPosition.Occupant = this;
            }
            return newPosition;
        }

        public int TrySlideOf(Tile position)
        {
            if (position.TileBeneath != null && position.TileBeneath.Occupant != null && position.TileBeneath.Occupant is Rubble)
            {
                // check slide to right
                bool isRightFree = (position.TileRight != null && position.TileRight.Occupant == null);
                if (isRightFree)
                {
                    bool canFallToRight = (position.TileBeneath.TileRight != null && position.TileBeneath.TileRight.Occupant == null);
                    bool canSquashRight = (position.TileBeneath.TileRight.Occupant != null && position.TileBeneath.TileRight.Occupant.IsSquashable);

                    if (canFallToRight)
                    {
                        return FallRight;
                    }else if (canSquashRight)
                    {
                        if (position.TileBeneath.TileRight.Collide(position, Direction.DOWN))
                        {
                            return FallRight;
                        }
                    }
                }

                // check slide to left
                bool isLeftFree = (position.TileLeft != null && position.TileLeft.Occupant == null);
                if (isLeftFree)
                {
                    bool canFallToLeft = (position.TileBeneath.TileLeft != null && position.TileBeneath.TileLeft.Occupant == null);
                    bool canSquashLeft = (position.TileBeneath.TileLeft.Occupant != null && position.TileBeneath.TileLeft.Occupant.IsSquashable);

                    if (canFallToLeft)
                    {
                        return FallLeft;
                    }else if (canSquashLeft)
                    {
                        if (position.TileBeneath.TileLeft.Collide(position, Direction.DOWN))
                        {
                            return FallLeft;
                        }
                    }
                }
            }
            return FallNot;
        }

        public virtual bool CanFallDown(Tile position)
        {
            if (position.TileBeneath.Occupant == null)
            {
                return true;
            }
            return false;
        }
    }
}
