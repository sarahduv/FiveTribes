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

        public Dictionary<int, int> TurnSlots = new Dictionary<int, int>();
        public Dictionary<string, int> Bids = new Dictionary<string, int>();

        public TurnBidding()
        {
            Bids["0A"] = NONE;
            Bids["0B"] = NONE;
            Bids["0C"] = NONE;
            Bids["1"] = NONE;
            Bids["2"] = NONE;
            Bids["3"] = NONE;
            Bids["4"] = NONE;
            Bids["5"] = NONE;
            Bids["6"] = NONE;

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
