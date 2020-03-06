using System;
using System.Collections.Generic;
using System.Text;

namespace FiveTribes.GameElements
{
    class RedMeeple : Meeple
    {
        public override int getPoints()
        {
            return 0;
        }
        public override bool isKept()
        {
            return false;
        }
    }
}
