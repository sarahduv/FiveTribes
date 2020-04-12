using System;
using System.Collections.Generic;
using System.Text;

namespace FiveTribes
{
    public class Elder : Meeple
    {
        public const int MAX = 20;

        public override int GetPoints()
        {
            return 2;
        }
        public override bool IsKept()
        {
            return true;
        }
    }
}
