using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace FiveTribes
{
    public abstract class Meeple
    {
        public abstract int GetPoints();
        public abstract bool IsKept();

        public string GetImage()
        {
            return @"Images\Meeples\" + GetType().Name +"2";
        }

        public Texture2D GetTexture()
        {
            return Resources.Load<Texture2D>(this.GetImage());
        }
    }
}
