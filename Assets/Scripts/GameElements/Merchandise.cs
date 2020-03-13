using System;
using System.Collections.Generic;
using System.Text;

namespace FiveTribes
{
    public class Merchandise
    {
        public Merchandise(MerchandiseKind kind)
        {
            this.Kind = kind;
        }

        public MerchandiseKind Kind { get; set; }

        internal string GetImage()
        {
            return @"Images\Merch\" + Kind.ToString();
        }
    }
}

public enum MerchandiseKind
{
    // x2
    Ivory,
    Jewel,
    Gold,

    // x4
    Papyrus,
    Silk,
    Spice,

    // x6
    Fish,
    Wheat,
    Pottery,

    // x18
    Fakir,
}
