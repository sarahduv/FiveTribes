using System;
using System.Collections.Generic;
using System.Text;

namespace FiveTribes
{
    public class Player
    {
        public string Name;
        public int FakirCount = 0;
        public int VizierCount = 0;
        public int ElderCount = 0;
        public int CamelCount = 0;
        public int TurnMarkerCount = 0;
        public int Coins = 0;
        public Table table;
        public List<Merchandise> Merchendise = new List<Merchandise>();
        public List<Djinn> Djinns = new List<Djinn>();
        public List<Tile> OwnedTiles = new List<Tile>();
        public int Index;

        public int getOwnedTreeCount()
        {
            var treeCount = 0;
            foreach (var tile in OwnedTiles)
            {
                treeCount += tile.TreeCount;
            }
            return treeCount;
        }

        public int getCurrentScore()
        {
            int score = Coins;
            score += ElderCount * 2;
            score += VizierCount;

            foreach (var player in table.Players)
            {
                if (player.VizierCount < this.VizierCount)
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

            int wildcards = 0;
            foreach (var djinn in Djinns)
            {
                // The actual score listed on the djinn card
                score += djinn.Score;

                // The score the djinn adds based on its specific action
                score += djinn.ExtraScore(this);

                wildcards += djinn.GetMerchandiseWildcards(this);
            }

            score += Merchendise.GetScore(wildcards);

            return score;
        }
    }
}
