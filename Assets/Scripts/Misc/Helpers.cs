using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using UnityEngine;

namespace FiveTribes
{
    static class Helpers
    {
        public static List<T> Shuffle<T>(this IEnumerable<T> unshuffled)
        {
            return unshuffled.OrderBy(x => Guid.NewGuid()).ToList();
        }

        public static T Pop<T>(this List<T> list)
        {
            if (list.Count == 0)
            {
                return default(T);
            }

            var last = list.Last();
            list.RemoveAt(list.Count - 1);
            return last;
        }

        public static void AddMultiple<T>(this List<T> list, Func<T> fn, int times)
        {
            for (int i = 0; i < times; ++i)
            {
                list.Add(fn());
            }
        }

        public static int GetScore(
            this List<Merchandise> merchs,
            int wildcards = 0
        ) {
            var setScoring = new int[] {0, 1, 3, 7, 13, 21, 30, 40, 50, 60};
            var countPerKind = merchs.GroupBy(x => x.Kind).ToDictionary(x => x.Key, x => x.Count());
            var sets = countPerKind.Values.Max();
            var kinds = countPerKind.Keys;

            var score = 0;
            for (int set = 0; set < sets; ++ set)
            {
                int distinctMerchKinds = 0;
                foreach (var kind in kinds)
                {
                    if (countPerKind[kind] == 0) continue;
                    distinctMerchKinds++;
                    countPerKind[kind]--;
                }

                // Use wildcards as early as possible
                while (wildcards > 0 && distinctMerchKinds < setScoring.Length - 1)
                {
                    wildcards--;
                    distinctMerchKinds++;
                }

                score += setScoring[distinctMerchKinds];
            }
            return score;
        }

        public static float GetDistance(float x1, float y1, float x2, float y2) { return Math.Abs(x2 - x1) + Math.Abs(y2 - y1); }
        public static float GetDistance(Vector2 v1, Vector2 v2) { return GetDistance(v1.x, v1.y, v2.x, v2.y); }

        public static bool IsAdjacent(float x1, float y1, float x2, float y2) { return GetDistance(x1, y1, x2, y2) == 1; }
        public static bool IsAdjacent(Vector2 v1, Vector2 v2) { return IsAdjacent(v1.x, v1.y, v2.x, v2.y); }
    }
}
