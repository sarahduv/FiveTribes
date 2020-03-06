using System;
using System.Collections.Generic;
using System.Text;

namespace FiveTribes.GameElements
{
    class Tile
    {
        public int Score = 0;
        public int PalaceCount = 0;
        public int TreeCount = 0;
        public bool Walkable = true;
        public Player Owner;
        public List<Meeple> Meeples = new List<Meeple>();
    }
}
