using System;
using System.Collections.Generic;
using System.Text;

namespace FiveTribes
{
    public class Tile
    {
        public Tile(int score, TileColor color, TileAction tileAction, int tileIndex, int imageVariation)
        {
            Score = score;
            TileAction = tileAction;
            Color = color;
            TileIndex = tileIndex;
            Image = score + (color == TileColor.Blue ? "B" : "R") + imageVariation;
        }

        public int Score = 0;
        public int PalaceCount = 0;
        public int TreeCount = 0;
        public int TileIndex = 0;
        public bool Walkable = true;
        public string Image;
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
