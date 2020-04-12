using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveTribes
{
    public class TurnBidding
    {
        public const int NONE = -1;

        public static int[] BidCosts = new int[] { 0, 1, 3, 5, 8, 12, 18 };
        private static string[] BidPlayOrder = new string[] {
          "6",
          "5",
          "4",
          "3",
          "2",
          "1",
          "0A",
          "0B",
          "0C",
        };

        public Dictionary<int, int> TurnSlots = new Dictionary<int, int>();
        public Dictionary<string, int> Bids = new Dictionary<string, int>();

        public TurnBidding()
        {
            foreach (var bidname in BidPlayOrder)
            {
                Bids[bidname] = NONE;
            }

            TurnSlots[0] = NONE;
            TurnSlots[1] = NONE;
            TurnSlots[2] = NONE;
            TurnSlots[3] = NONE;
        }

        public int GetNextBidSlot()
        {
            for (var i = 0; i < TurnSlots.Count; ++i)
            {
                if (TurnSlots[i] != NONE)
                {
                    return i;
                }
            }
            return NONE;
        }

        public int GetCurrentPlayer()
        {
            foreach (var bidname in BidPlayOrder)
            {
                if (Bids[bidname] != NONE)
                {
                    return Bids[bidname];
                }
            }
            return NONE;
        }

        public bool IsAvailable(int index)
        {
            if (index > 0)
            {
                return Bids[index.ToString()] == NONE;
            }
            else
            {
                return Bids["0A"] == NONE ||
                    Bids["0B"] == NONE ||
                    Bids["0C"] == NONE;
            }
        }

        public void SetBid(int index, int player)
        {
            if (index == 0)
            {
                // Push the other zeroes up
                Bids["0C"] = Bids["0B"];
                Bids["0B"] = Bids["0A"];
                Bids["0A"] = player;
            } 
            else
            {
                Bids[index.ToString()] = player;
            }
        }
    }
}
