using System;
using System.Collections.Generic;
using System.Text;

namespace FiveTribes
{
    public class Tile
    {
        public Tile(int score, TileColor color, TileAction tileAction, int tileIndex)
        {
            Score = score;
            TileAction = tileAction;
            Color = color;
            TileIndex = tileIndex;
        }

        public int Score = 0;
        public int PalaceCount = 0;
        public int TreeCount = 0;
        public int TileIndex = 0;
        public bool Walkable = true;
        public TileAction TileAction;
        public Player Owner;
        public TileColor Color;
        public List<Meeple> Meeples = new List<Meeple>();
    }

    public enum TileColor
    {
        Blue,
        Red
    }
}
