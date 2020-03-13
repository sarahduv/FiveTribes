using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveTribes
{
    public abstract class TileAction
    {
        abstract public void Action();
        abstract public string GetImagePath();
    }
}
