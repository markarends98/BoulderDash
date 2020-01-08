using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Models.GameObjects
{
    public abstract class Rubble : GameObject
    {
        /// <summary>
        /// behaviour to let gameobject fall
        /// </summary>
        /// <param name="position">position of gameobject</param>
        /// <returns>if has fallen</returns>
        public virtual bool Fall(Tile position)
        {
            if (CanFallDown(position))
            {
                position.TileBeneath.Occupant = this;
                return true;
            }
            
            if (CanSlideOf(position))
            {

            }
            return false;
        }

        private bool CanSlideOf(Tile position)
        {
            return false;
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
