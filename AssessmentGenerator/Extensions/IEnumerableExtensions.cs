using AssessmentGenerator.Models;
using System;
using System.Collections.Generic;

namespace AssessmentGenerator.Extensions
{
    internal static class IEnumerableExtensions
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> items, IRandom random)
        {
            var list = items.ToList();
            int index = list.Count;

            while (index > 1)
            {
                index--;
                int randomIndex = random.Next(index + 1);
                (list[index], list[randomIndex]) = (list[randomIndex], list[index]);
            }

            return list;
        }
    }
}
