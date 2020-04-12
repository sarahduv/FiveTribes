using System;
using System.Collections.Generic;
using System.Text;

namespace FiveTribes
{
    public class Vizier : Meeple
    {
        public const int MAX = 16;

        public override int GetPoints()
        {
            return 1;
        }
        public override bool IsKept()
        {
            return true;
        }
    }
}
