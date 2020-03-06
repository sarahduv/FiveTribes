using System;
using System.Collections.Generic;
using System.Text;

namespace FiveTribes.GameElements
{
    class MarketItem
    {
        public MarketItemKind Kind { get; set; }
    }
}

public enum MarketItemKind
{
    Fakir,
    Wheat,
    Gold,
    Gems,
    Urns,
    //TODO: more
}
