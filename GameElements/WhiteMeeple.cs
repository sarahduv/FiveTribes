using System;
using System.Collections.Generic;
using System.Text;

namespace FiveTribes.GameElements
{
    class WhiteMeeple : Meeple
    {
        public override int getPoints()
        {
            return 2;
        }
        public override bool isKept()
        {
            return true;
        }
    }
}
