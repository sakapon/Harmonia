using System;
using System.Collections.Generic;
using System.Linq;

namespace Harmonia.Sort
{
    public static class BubbleSortHelper
    {
        /// <summary>
        /// シーケンスの要素をキーに従って昇順に並べ替えます。
        /// バブル ソートを使用します。
        /// </summary>
        /// <typeparam name="TSource">要素の型。</typeparam>
        /// <typeparam name="TKey">キーの型。</typeparam>
        /// <param name="source">並べ替えるシーケンス。</param>
        /// <param name="keySelector">キーを抽出する関数。</param>
        /// <returns>並べ替えられたシーケンス。</returns>
        public static IEnumerable<TSource> BubbleSort<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            var keyed = source.Select(e => new KeyedObject0<TSource, TKey>(e, keySelector(e))).ToArray();
            var comparer = Comparer<TKey>.Default;
            keyed.BubbleSort((x1, x2) => comparer.Compare(x1.Key, x2.Key));
            return keyed.Select(_ => _.Target);
        }

        /// <summary>
        /// 指定された配列自身をバブル ソートで並べ替えます。
        /// </summary>
        /// <typeparam name="TSource">要素の型。</typeparam>
        /// <param name="source">並べ替える配列。</param>
        /// <param name="compare">2 つの値を比較する関数。</param>
        public static void BubbleSort<TSource>(this TSource[] source, Func<TSource, TSource, int> compare)
        {
            TSource e;

            for (var i = 0; i < source.Length; i++)
            {
                for (var j = source.Length - 1; i < j; j--)
                {
                    // if source[j - 1] > source[j],
                    if (compare(source[j - 1], source[j]) > 0)
                    {
                        e = source[j - 1];
                        source[j - 1] = source[j];
                        source[j] = e;
                    }
                }
            }
        }

        public static void BubbleSort<TSource>(this IList<TSource> source, Func<TSource, TSource, int> compare)
        {
            for (var i = 0; i < source.Count; i++)
                for (var j = source.Count - 1; i < j; j--)
                    if (compare(source[j - 1], source[j]) > 0)
                        source.Swap(j - 1, j);
        }

        public static void BubbleSort<TSource>(this IList<TSource> source, IComparer<TSource> comparer) =>
            source.BubbleSort((x1, x2) => comparer.Compare(x1, x2));

        public static void BubbleSort<TSource>(this IList<TSource> source) =>
            source.BubbleSort(Comparer<TSource>.Default);

        public static void BubbleSort2<TSource>(this IList<TSource> source) where TSource : IComparable<TSource> =>
            source.BubbleSort((x1, x2) => x1.CompareTo(x2));
    }
}
