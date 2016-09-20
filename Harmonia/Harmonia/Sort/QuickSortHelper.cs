using System;
using System.Collections.Generic;
using System.Linq;

namespace Harmonia.Sort
{
    public static class QuickSortHelper
    {
        public static void QuickSort<TSource>(this IList<TSource> source, Func<TSource, TSource, int> compare) =>
            QuickSort(source, compare, 0, source.Count);

        public static void QuickSort<TSource>(this IList<TSource> source, IComparer<TSource> comparer) =>
            source.QuickSort((x1, x2) => comparer.Compare(x1, x2));

        public static void QuickSort<TSource>(this IList<TSource> source) =>
            source.QuickSort(Comparer<TSource>.Default);

        public static void QuickSort2<TSource>(this IList<TSource> source) where TSource : IComparable<TSource> =>
            source.QuickSort((x1, x2) => x1.CompareTo(x2));

        public static void QuickSort<TSource>(this IList<TSource> source, Func<TSource, TSource, int> compare, int start, int count)
        {
            if (count < 2) return;

            // 長さが 2 の場合は最適化します。
            if (count == 2)
            {
                if (compare(source[start], source[start + 1]) > 0)
                    source.Swap(start, start + 1);
                return;
            }

            var m = source[start];
            // cursor1: x <= m が保証されるインデックス。
            // cursor2: x > m が保証されるインデックス。
            var cursor1 = start;
            var cursor2 = start + count;

            while (true)
            {
                cursor1 = AssertLessThanOrEqual(source, compare, cursor1 + 1, cursor2 - 1, m);
                if (cursor1 == cursor2 - 1)
                    break;

                cursor2 = AssertGreaterThan(source, compare, cursor2 - 1, cursor1 + 2, m);
                if (cursor2 == cursor1 + 2)
                {
                    cursor2--;
                    break;
                }

                cursor1++;
                cursor2--;
                source.Swap(cursor1, cursor2);
            }

            if (start != cursor1)
                source.Swap(start, cursor1);

            // start <= i < cursor1
            source.QuickSort(compare, start, cursor1 - start);
            // cursor2 <= i < start + count
            source.QuickSort(compare, cursor2, start + count - cursor2);
        }

        static int AssertLessThanOrEqual<TSource>(this IList<TSource> source, Func<TSource, TSource, int> compare, int start, int end, TSource m)
        {
            for (var i = start; i <= end; i++)
                if (compare(source[i], m) > 0)
                    return i - 1;

            return end;
        }

        static int AssertGreaterThan<TSource>(this IList<TSource> source, Func<TSource, TSource, int> compare, int start, int end, TSource m)
        {
            for (var i = start; i >= end; i--)
                if (compare(source[i], m) <= 0)
                    return i + 1;

            return end;
        }
    }
}
