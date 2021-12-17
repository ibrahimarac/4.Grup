using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uzaktan.Core.Utilities.Extensions
{
    public static class LinqExtensions
    {
        public static bool IntersectWith<T>(this IEnumerable<T> source,params T[] target)
        {
            return source.Intersect(target).Count() != 0;
        }
    }
}
