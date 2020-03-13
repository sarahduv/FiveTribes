using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace FiveTribes
{
    public abstract class Djinn
    {
        public Djinn(string name, int score, DjinnCost cost, string desc)
        {
            Name = name;
            Score = score;
            Desc = desc;
        }
        public string Name;
        public int Score;
        public DjinnCost Cost;
        public string Desc;

        public virtual int ExtraScore(Player player)
        {
            return 0;
        }

        public virtual int GetMerchandiseWildcards(Player player)
        {
            return 0;
        }

        public string GetImage()
        {
            return @"Images\Djinns\" + GetType().Name.Replace("Djinn","");
        }

        public Texture2D GetTexture()
        {
            return Resources.Load<Texture2D>(this.GetImage());
        }

        public string GetCostDesc()
        {
            // Special
            if ((Cost & DjinnCost.OneOrMoreFakir) != 0)
            {
                return "One or more Fakir";
            }

            List<string> costs = new List<string>();
            if ((Cost & DjinnCost.Elder) != 0)
            {
                costs.Add("1 Elder");
            }
            if ((Cost & DjinnCost.Fakir) != 0)
            {
                costs.Add("1 Fakir");
            }
            if ((Cost & DjinnCost.ElderOrFakir) != 0)
            {
                costs.Add("1 Elder/Fakir");
            }

            return string.Join(" + ", costs.ToArray());
        }
    }

    [Flags]
    public enum DjinnCost
    {
        Free = 0,
        Elder = 1,
        Fakir = 2,
        ElderOrFakir = 4,
        OneOrMoreFakir = 8
    }

    public class DjinnAlAmin : Djinn
    {
        public DjinnAlAmin() : base(
            "Al-Amin", 
            5, 
            DjinnCost.Free,
            "At game end, each pair of Fakirs\n"+
            "you hold acts as 1 Wild Merchandise\n"+
            "of your choice."
        ) { }

        public override int GetMerchandiseWildcards(Player player)
        {
            return (int)Math.Floor(player.FakirCount / 2.0f);
        }
    }

    public class DjinnAnunNak : Djinn
    {
        public DjinnAnunNak() : base(
            "Anun-Nak", 
            8, 
            DjinnCost.ElderOrFakir,
            "Choose an empty Tile (with no\n"+
            "Camel, Meeple, Palm Tree or\n"+
            "Palace). Place 3 Meeples on that\n"+
            "tile (drawn at random from the\n"+
            "bag)."
        ) { }
    }

    public class DjinnBaal : Djinn
    {
        public DjinnBaal() : base(
            "Ba'al",
            6,
            DjinnCost.Free,
            "Each time someone gets a Djinn,\n"+
            "collect 1 GC if it’s you,\n"+
            "2 GCs if it’s an opponent."
        )
        { }
    }

    public class DjinnBoaz : Djinn
    {
        public DjinnBoaz() : base(
            "Boaz",
            6,
            DjinnCost.Free,
            "Your Elders and Viziers are\n"+
            "protected from Assassins."
        )
        { }
    }

    public class DjinnBouraq: Djinn
    {
        public DjinnBouraq() : base(
            "Bouraq",
            6,
            DjinnCost.ElderOrFakir,
            "Place 1 Palace on any Village."
        )
        { }
    }

    // Column 2

    public class DjinnEchidna : Djinn
    {
        public DjinnEchidna() : base(
            "Echidna",
            4,
            DjinnCost.Elder | DjinnCost.ElderOrFakir,
            "Double the amount of GCs your\n"+
            "Builders get this turn."
        )
        { }
    }

    public class DjinnEnki : Djinn
    {
        public DjinnEnki() : base(
            "Enki",
            8,
            DjinnCost.ElderOrFakir,
            "Place 1 Palm Tree on any Oasis."
        )
        { }
    }

    public class DjinnHagis : Djinn
    {
        public DjinnHagis() : base(
            "Hagis",
            10,
            DjinnCost.ElderOrFakir,
            "When placing a Palace, you may\n"+
            "drop it on any neighboring Tile\n"+
            "instead."
        )
        { }
    }

    public class DjinnHaurvatat : Djinn
    {
        public DjinnHaurvatat() : base(
            "Haurvatat",
            8,
            DjinnCost.Free,
            "At game end, each of your Palm\n"+
            "Trees is worth 5 VPs instead of 3."
        )
        { }

        public override int ExtraScore(Player player)
        {
            return player.getOwnedTreeCount() * 2;
        }
    }

    public class DjinnIblis : Djinn
    {
        public DjinnIblis() : base(
            "Iblis",
            8,
            DjinnCost.ElderOrFakir,
            "Your Assassins kill 2 Meeples of\n"+
            "any color on the same Tile or kill\n"+
            "2 Elders and / or Viziers from the\n"+
            "same opponent."
        )
        { }
    }

    public class DjinnJafaar : Djinn
    {
        public DjinnJafaar() : base(
            "Jafaar",
            6,
            DjinnCost.Free,
            "At game end, each Vizier you hold\n"+
            "is worth 3 VPs instead of 1."
        )
        { }

        public override int ExtraScore(Player player)
        {
            return player.VizierCount * 2;
        }
    }

    // Column 3

    public class DjinnKandicha : Djinn
    {
        public DjinnKandicha() : base(
            "Kandicha",
            6,
            DjinnCost.Free,
            "Each time your Assassins kill:\n" +
            "a Merchant: draw 1 Resource card\n" +
            "from the top of the Resource pile;\n" +
            "a Builder: take the GCs that Builder\n" +
            "would have taken;\n" +
            "a Vizier or Elder: place it in front\n" +
            "of you instead of killing it."
        )
        { }
    }

    public class DjinnKumarbi : Djinn
    {
        public DjinnKumarbi() : base(
            "Kumarbi",
            6,
            DjinnCost.OneOrMoreFakir,
            "When bidding for Turn Order,\n"+
            "for each Fakir you discard your\n"+
            "bidding cost is reduced by 1 spot."
        )
        { }
    }

    public class DjinnLamia : Djinn
    {
        public DjinnLamia() : base(
            "Lamia",
            10,
            DjinnCost.ElderOrFakir,
            "When building a Palm Tree,\n"+
            "you may place it on a neighboring\n"+
            "Tile instead."
        )
        { }
    }

    public class DjinnLeta : Djinn
    {
        public DjinnLeta() : base(
            "Leta",
            4,
            DjinnCost.Elder | DjinnCost.ElderOrFakir,
            "Take control of 1 empty Tile (no\n"+
            "Camel, Meeple, Palm Tree or\n"+
            "Palace); place 1 of your Camels\n"+
            "on it."
        )
        { }
    }

    public class DjinnMarid : Djinn
    {
        public DjinnMarid() : base(
            "Marid",
            6,
            DjinnCost.Free,
            "Each time a Meeple is dropped\n"+
            "on one of your Tiles during a\n"+
            "Move, collect:\n"+
            "1 GC if you did the Move;\n"+
            "2 GCs if one of your opponents did."
        )
        { }
    }

    public class DjinnMonkir : Djinn
    {
        public DjinnMonkir() : base(
            "Monkir",
            6,
            DjinnCost.Free,
            "Each time a Palace is placed,\n"+
            "collect:\n"+
            "1 GC if you did it;\n"+
            "2 GCs if your opponents did."
        )
        { }
    }

    // Column 4

    public class DjinnNekir : Djinn
    {
        public DjinnNekir() : base(
            "Nekir",
            6,
            DjinnCost.Free,
            "Each time Assassins kill Meeple(s),\n"+
            "collect:\n"+
            "1 GC if you did the Killing;\n"+
            "2 GCs if an opponent did."
        )
        { }
    }

    public class DjinnShamhat : Djinn
    {
        public DjinnShamhat() : base(
            "Shamhat",
            6,
            DjinnCost.Free,
            "At game end, each of your Elders\n"+
            "is worth 4 VPs instead of 2."
        )
        { }

        public override int ExtraScore(Player player)
        {
            return player.ElderCount * 2;
        }
    }

    public class DjinnSibittis : Djinn
    {
        public DjinnSibittis() : base(
            "Sibittis",
            4,
            DjinnCost.Elder | DjinnCost.ElderOrFakir,
            "Draw the top 3 Djinns from the\n"+
            "top of the Djinns pile; keep 1,\n"+
            "discard the 2 others."
        )
        { }
    }

    public class DjinnSloar : Djinn
    {
        public DjinnSloar() : base(
            "Sloar",
            8,
            DjinnCost.Fakir,
            "Take the top card from the\n"+
            "Resource pile."
        )
        { }
    }

    public class DjinnUtug : Djinn
    {
        public DjinnUtug() : base(
            "Utug",
            4,
            DjinnCost.Elder | DjinnCost.ElderOrFakir,
            "Take control of 1 Tile with only\n"+
            "Meeples on it(no Camel, Palm\n"+
            "Tree or Palace); place 1 of your\n"+
            "Camels on it."
        )
        { }
    }
}
