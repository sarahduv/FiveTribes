using System;
using System.Collections.Generic;
using System.Text;

namespace FiveTribes
{
    public class Table
    {
        public const int MerchendiseShowingLimit = 9;
        public const int DjinnShowingLimit = 3;
        public const int BoardRows = 5;
        public const int BoardCols = 6;

        public List<Merchandise> MerchendisesShowing = new List<Merchandise>();
        public List<Merchandise> MerchendisesDeck = new List<Merchandise>();
        public List<Djinn> DjinnsShowing = new List<Djinn>();
        public List<Djinn> DjinnsDeck = new List<Djinn>();
        public List<Meeple> MeepleBag = new List<Meeple>();
        public List<Player> Players = new List<Player>();
        public Tile[,] Tiles = new Tile[BoardRows, BoardCols];

        public bool IsDuel { get { return Players.Count == 2; } }

        public void Setup()
        {
            // Meeples bag
            MeepleBag.AddMultiple(() => new Vizier(), 16);
            MeepleBag.AddMultiple(() => new Builder(), 18);
            MeepleBag.AddMultiple(() => new Assassin(), 18);
            MeepleBag.AddMultiple(() => new Merchant(), 18);
            MeepleBag.AddMultiple(() => new Elder(), 20);
            MeepleBag = MeepleBag.Shuffle();

            // Merchendise deck
            MerchendisesDeck.AddMultiple(() => new Merchandise(MerchandiseKind.Fakir), 18);
            MerchendisesDeck.AddMultiple(() => new Merchandise(MerchandiseKind.Ivory), 2);
            MerchendisesDeck.AddMultiple(() => new Merchandise(MerchandiseKind.Jewel), 2);
            MerchendisesDeck.AddMultiple(() => new Merchandise(MerchandiseKind.Gold), 2);
            MerchendisesDeck.AddMultiple(() => new Merchandise(MerchandiseKind.Papyrus), 4);
            MerchendisesDeck.AddMultiple(() => new Merchandise(MerchandiseKind.Silk), 4);
            MerchendisesDeck.AddMultiple(() => new Merchandise(MerchandiseKind.Spice), 4);
            MerchendisesDeck.AddMultiple(() => new Merchandise(MerchandiseKind.Fish), 6);
            MerchendisesDeck.AddMultiple(() => new Merchandise(MerchandiseKind.Wheat), 6);
            MerchendisesDeck.AddMultiple(() => new Merchandise(MerchandiseKind.Pottery), 6);
            MerchendisesDeck = MerchendisesDeck.Shuffle();

            // Actions that can be taken by landing on tiles
            var sacredPlaceAction = new SacredPlaceTileAction();
            var smallMarketAction = new SmallMarketTileAction();
            var bigMarketAction = new BigMarketTileAction();
            var treeAction = new TreeTileAction();
            var palaceAction = new PalaceTileAction();

            // These are sorted like the image in the manual, 5 rows, 6 cols
            List<Tile> tileBag = new List<Tile>();
            tileBag.Add(new Tile(10, TileColor.Blue, sacredPlaceAction, 0));
            tileBag.Add(new Tile(6, TileColor.Red, smallMarketAction, 1));
            tileBag.Add(new Tile(6, TileColor.Blue, sacredPlaceAction, 2));
            tileBag.Add(new Tile(5, TileColor.Blue, palaceAction, 3));
            tileBag.Add(new Tile(6, TileColor.Red, smallMarketAction, 4));
            tileBag.Add(new Tile(8, TileColor.Red, treeAction, 5));

            tileBag.Add(new Tile(8, TileColor.Red, treeAction, 6));
            tileBag.Add(new Tile(4, TileColor.Red, bigMarketAction, 7));
            tileBag.Add(new Tile(4, TileColor.Red, bigMarketAction, 8));
            tileBag.Add(new Tile(8, TileColor.Red, treeAction, 9));
            tileBag.Add(new Tile(4, TileColor.Red, bigMarketAction, 10));
            tileBag.Add(new Tile(6, TileColor.Blue, sacredPlaceAction, 11));

            tileBag.Add(new Tile(6, TileColor.Red, smallMarketAction, 12));
            tileBag.Add(new Tile(5, TileColor.Blue, palaceAction, 13));
            tileBag.Add(new Tile(12, TileColor.Blue, sacredPlaceAction, 14));
            tileBag.Add(new Tile(6, TileColor.Red, smallMarketAction, 15));
            tileBag.Add(new Tile(8, TileColor.Red, treeAction, 16));
            tileBag.Add(new Tile(6, TileColor.Red, smallMarketAction, 17));

            tileBag.Add(new Tile(6, TileColor.Blue, sacredPlaceAction, 18));
            tileBag.Add(new Tile(8, TileColor.Red, treeAction, 19));
            tileBag.Add(new Tile(6, TileColor.Red, smallMarketAction, 20));
            tileBag.Add(new Tile(4, TileColor.Red, bigMarketAction, 21));
            tileBag.Add(new Tile(15, TileColor.Blue, sacredPlaceAction, 22));
            tileBag.Add(new Tile(5, TileColor.Blue, palaceAction, 23));

            tileBag.Add(new Tile(6, TileColor.Red, smallMarketAction, 24));
            tileBag.Add(new Tile(5, TileColor.Blue, palaceAction, 25));
            tileBag.Add(new Tile(6, TileColor.Blue, sacredPlaceAction, 26));
            tileBag.Add(new Tile(8, TileColor.Red, treeAction, 27));
            tileBag.Add(new Tile(5, TileColor.Blue, palaceAction, 28));
            tileBag.Add(new Tile(6, TileColor.Red, smallMarketAction, 29));
            tileBag = tileBag.Shuffle();

            // Djinn Deck
            DjinnsDeck.Add(new DjinnAlAmin());
            DjinnsDeck.Add(new DjinnAnunNak());
            DjinnsDeck.Add(new DjinnBaal());
            DjinnsDeck.Add(new DjinnBoaz());
            DjinnsDeck.Add(new DjinnBouraq());
            DjinnsDeck.Add(new DjinnEchidna());
            DjinnsDeck.Add(new DjinnEnki());
            DjinnsDeck.Add(new DjinnHagis());
            DjinnsDeck.Add(new DjinnHaurvatat());
            DjinnsDeck.Add(new DjinnIblis());
            DjinnsDeck.Add(new DjinnJafaar());
            DjinnsDeck.Add(new DjinnKandicha());
            DjinnsDeck.Add(new DjinnKumarbi());
            DjinnsDeck.Add(new DjinnLamia());
            DjinnsDeck.Add(new DjinnLeta());
            DjinnsDeck.Add(new DjinnMarid());
            DjinnsDeck.Add(new DjinnMonkir());
            DjinnsDeck.Add(new DjinnNekir());
            DjinnsDeck.Add(new DjinnShamhat());
            DjinnsDeck.Add(new DjinnSibittis());
            DjinnsDeck.Add(new DjinnSloar());
            DjinnsDeck.Add(new DjinnUtug());
            DjinnsDeck = DjinnsDeck.Shuffle();

            // Setup players
            for (int playerIndex = 0; playerIndex < Players.Count; ++playerIndex)
            {
                var player = Players[playerIndex];
                player.CamelCount = IsDuel ? 11 : 8;
                player.TurnMarkerCount = IsDuel ? 2 : 1;
                player.Coins = 50;
                player.Index = playerIndex;
            }

            // Draw first 9 merchendise cards
            for (int i = 0; i < MerchendiseShowingLimit; ++i)
                MerchendisesShowing.Add(MerchendisesDeck.Pop());

            // Draw first 3 djinn cards
            for (int i = 0; i < DjinnShowingLimit; ++i)
                DjinnsShowing.Add(DjinnsDeck.Pop());

            // Draw tiles into board
            for (int row = 0; row < BoardRows; ++row)
            {
                for (int col = 0; col < BoardCols; ++col)
                {
                    var tile = tileBag.Pop();
                    tile.Meeples.AddMultiple(() => MeepleBag.Pop(), 3);
                    Tiles[row, col] = tile;
                }
            }
        }
    }
}
