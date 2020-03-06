using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FiveTribes
{
    abstract class Helpers
    {
        public static List<T> Shuffle<T>(IEnumerable<T> unshuffled)
        {
            return unshuffled.OrderBy(x => Guid.NewGuid()).ToList();
        }

        public static T Pop<T>(List<T> list)
        {
            if (list.Count == 0)
            {
                return default(T);
            }

            var last = list.Last();
            list.RemoveAt(list.Count - 1);
            return last;
        }

        public static int GetDistance(int x1, int y1, int x2, int y2)
        {
            return Math.Abs(x2 - x1) + Math.Abs(y2 - y1);
        }

        //public static bool IsAdjacent()
    }
}
