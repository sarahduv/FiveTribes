using System;
using System.Collections.Generic;
using System.Text;

namespace FiveTribes.GameElements
{
    abstract class Meeple
    {
        public abstract int getPoints();
        public abstract bool isKept();
    }
}
