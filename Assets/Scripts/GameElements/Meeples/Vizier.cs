using System;
using System.Collections.Generic;
using System.Text;

namespace FiveTribes
{
    public class Vizier : Meeple
    {
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
