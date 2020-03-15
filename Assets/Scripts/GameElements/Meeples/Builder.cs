using System;
using System.Collections.Generic;
using System.Text;

namespace FiveTribes
{
    public class Builder : Meeple
    {
        public override int GetPoints()
        {
            return 0;
        }

        public override bool IsKept()
        {
            return false;
        }
    }
}
