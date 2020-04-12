using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace FiveTribes
{
    public class Table
    {
        public static Table Instance;
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
        public TurnBidding Bidding = new TurnBidding();
        public Tile[,] Tiles = new Tile[BoardRows, BoardCols];

        public GamePhase Phase;

        public bool IsDuel { get { return Players.Count == 2; } }

        public void Setup()
        {
            Instance = this;

            // Meeples bag
            MeepleBag.AddMultiple(() => new Vizier(), Vizier.MAX);
            MeepleBag.AddMultiple(() => new Builder(), Builder.MAX);
            MeepleBag.AddMultiple(() => new Assassin(), Assassin.MAX);
            MeepleBag.AddMultiple(() => new Merchant(), Merchant.MAX);
            MeepleBag.AddMultiple(() => new Elder(), Elder.MAX);
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
            tileBag.Add(new Tile(10, TileColor.Blue, sacredPlaceAction, 0, 0));
            tileBag.Add(new Tile(6, TileColor.Red, smallMarketAction, 1, 0));
            tileBag.Add(new Tile(6, TileColor.Blue, sacredPlaceAction, 2, 0));
            tileBag.Add(new Tile(5, TileColor.Blue, palaceAction, 3, 1));
            tileBag.Add(new Tile(6, TileColor.Red, smallMarketAction, 4, 0));
            tileBag.Add(new Tile(8, TileColor.Red, treeAction, 5, 0));

            tileBag.Add(new Tile(8, TileColor.Red, treeAction, 6, 0));
            tileBag.Add(new Tile(4, TileColor.Red, bigMarketAction, 7, 0));
            tileBag.Add(new Tile(4, TileColor.Red, bigMarketAction, 8, 1));
            tileBag.Add(new Tile(8, TileColor.Red, treeAction, 9, 0));
            tileBag.Add(new Tile(4, TileColor.Red, bigMarketAction, 10, 2));
            tileBag.Add(new Tile(6, TileColor.Blue, sacredPlaceAction, 11, 0));

            tileBag.Add(new Tile(6, TileColor.Red, smallMarketAction, 12, 0));
            tileBag.Add(new Tile(5, TileColor.Blue, palaceAction, 13, 1));
            tileBag.Add(new Tile(12, TileColor.Blue, sacredPlaceAction, 14, 0));
            tileBag.Add(new Tile(6, TileColor.Red, smallMarketAction, 15, 1));
            tileBag.Add(new Tile(8, TileColor.Red, treeAction, 16, 1));
            tileBag.Add(new Tile(6, TileColor.Red, smallMarketAction, 17, 1));

            tileBag.Add(new Tile(6, TileColor.Blue, sacredPlaceAction, 18, 0));
            tileBag.Add(new Tile(8, TileColor.Red, treeAction, 19, 1));
            tileBag.Add(new Tile(6, TileColor.Red, smallMarketAction, 20, 1));
            tileBag.Add(new Tile(4, TileColor.Red, bigMarketAction, 21, 0));
            tileBag.Add(new Tile(15, TileColor.Blue, sacredPlaceAction, 22, 0));
            tileBag.Add(new Tile(5, TileColor.Blue, palaceAction, 23, 0));

            tileBag.Add(new Tile(6, TileColor.Red, smallMarketAction, 24, 2));
            tileBag.Add(new Tile(5, TileColor.Blue, palaceAction, 25, 0));
            tileBag.Add(new Tile(6, TileColor.Blue, sacredPlaceAction, 26, 0));
            tileBag.Add(new Tile(8, TileColor.Red, treeAction, 27, 1));
            tileBag.Add(new Tile(5, TileColor.Blue, palaceAction, 28, 0));
            tileBag.Add(new Tile(6, TileColor.Red, smallMarketAction, 29, 2));
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
            Player.Players = new Dictionary<int, FiveTribes.Player>();
            for (int playerIndex = 0; playerIndex < Players.Count; ++playerIndex)
            {
                var player = Players[playerIndex];
                player.CamelsLeft = IsDuel ? 11 : 8;
                player.TurnMarkerCount = IsDuel ? 2 : 1;
                player.Coins = 50;
                player.Index = playerIndex;
                Player.Players[player.Index] = player;
            }
            Players = Players.Shuffle();

            
            if (IsDuel)
            {
                Bidding.TurnSlots[0] = Players[0].Index;
                Bidding.TurnSlots[1] = Players[1].Index;
                Bidding.TurnSlots[2] = Players[1].Index;
                Bidding.TurnSlots[3] = Players[0].Index;
            }
            else
            {
                for (var slot = 0; slot < Bidding.TurnSlots.Count; ++slot)
                {
                    Bidding.TurnSlots[slot] = TurnBidding.NONE;
                }
                for (var p = 0; p < Players.Count; ++p)
                {
                    Bidding.TurnSlots[p] = Players[p].Index;
                }
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

            Phase = GamePhase.Bidding;
        }

        public Player GetCurrentPlayer()
        {
            var playerIndex = Bidding.GetCurrentPlayer();
            if (playerIndex == TurnBidding.NONE)
            {
                return null;
            }
            return Player.Players[playerIndex];
        }

        public bool TryBid(int index)
        {
            int nextBidSlot = Bidding.GetNextBidSlot();
            // This should never happen because it shouldn't be clickable
            if (
                Phase != GamePhase.Bidding ||
                nextBidSlot == TurnBidding.NONE // no players to bid
            ) {
                return false;
            }

            var player = Player.Players[Bidding.TurnSlots[nextBidSlot]];
            var cost = TurnBidding.BidCosts[index];

            if (cost > player.Coins)
            {
                // Not enough coins
                return false;
            }

            if (!Bidding.IsAvailable(index))
            {
                // Already occupied
                return false;
            }
            
            // Remove from 
            Bidding.TurnSlots[nextBidSlot] = TurnBidding.NONE;
            Bidding.SetBid(index, player.Index);
            player.Coins -= cost;

            return true;
        }
    }

    public enum GamePhase
    {
        Bidding,
        Playing,
    }
}