using System;
using System.Collections.Generic;
using System.Text;

namespace FiveTribes.GameElements
{
    class YellowMeeple : Meeple
    {
        public override int getPoints()
        {
            return 1;
        }
        public override bool isKept()
        {
            return true;
        }
    }
}
