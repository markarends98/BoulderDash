﻿using BoulderDash.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash
{
    class Program
    {
        static void Main(string[] args)
        {
            GameController gameController = new GameController();
            gameController.StartGame();
        }
    }
}
