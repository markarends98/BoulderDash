using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Models
{
    public class Game
    {
        private List<GameObject> _gameObjects;

        public Game(List<GameObject> gameObjects)
        {
            this._gameObjects = gameObjects;
        }
    }
}
