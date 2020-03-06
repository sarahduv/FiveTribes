using System;
using System.Collections.Generic;
using System.Text;

namespace FiveTribes.GameElements
{
    class Table
    {
        public List<MarketItem> MarketItemsShowing = new List<MarketItem>();
        public List<MarketItem> MarketItemsDeck = new List<MarketItem>();
        public List<Djinn> DjinnsShowing = new List<Djinn>();
        public List<Djinn> DjinnsDeck = new List<Djinn>();
        public List<Meeple> MeepleBag = new List<Meeple>();
        public List<Player> Players = new List<Player>();
        public Tile[,] Tiles = new Tile[8, 6]; //TODO: fix
    }
}
