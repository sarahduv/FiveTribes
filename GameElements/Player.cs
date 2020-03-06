using System;
using System.Collections.Generic;
using System.Text;

namespace FiveTribes.GameElements
{
    class Player
    {
        public string Name;
        public int FakirCount = 0;
        public int YellowMeepleCount = 0;
        public int WhiteMeepleCount = 0;
        public int Coins = 0;
        public Table table;
        public List<MarketItem> MarketItems = new List<MarketItem>();
        public List<Djinn> Djinns = new List<Djinn>();
        public List<Tile> OwnedTiles = new List<Tile>();

        public int getCurrentScore()
        {
            int score = Coins;
            score += WhiteMeepleCount * 2;
            score += YellowMeepleCount;

            foreach (var player in table.Players)
            {
                if (player.YellowMeepleCount < this.YellowMeepleCount)
                {
                    score += 10;
                }
            }

            foreach (var tile in OwnedTiles)
            {
                score += tile.Score;
                score += tile.PalaceCount * 5;
                score += tile.TreeCount * 3;
            }

            return score;
        }
    }
}
