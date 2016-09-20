using System;
using System.Collections.Generic;
using System.Linq;

namespace Harmonia.Sort
{
    public static class BubbleSortHelper
    {
        /// <summary>
        /// 要素をキーに従って昇順に並べ替えます。
        /// バブル ソートを使用します。
        /// </summary>
        /// <typeparam name="TSource">要素の型。</typeparam>
        /// <typeparam name="TKey">キーの型。</typeparam>
        /// <param name="source">並べ替える配列。</param>
        /// <param name="keySelector">キーを抽出する関数。</param>
        /// <returns>並べ替えられた配列。</returns>
        public static TSource[] BubbleSort<TSource, TKey>(this TSource[] source, Func<TSource, TKey> keySelector) where TKey : IComparable<TKey>
        {
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            var keyed = source.Select(e => new KeyedObject<TSource, TKey>(e, keySelector(e))).ToArray();
            BubbleSort(keyed);
            return keyed.Select(_ => _.Target).ToArray();
        }

        /// <summary>
        /// 指定された配列自身をバブル ソートで並べ替えます。
        /// </summary>
        /// <typeparam name="TSource">要素の型。</typeparam>
        /// <param name="source">並べ替える配列。</param>
        /// <returns>並べ替えられた配列。参照は <paramref name="source"/> と同じ。</returns>
        public static TSource[] BubbleSort<TSource>(this TSource[] source) where TSource : IComparable<TSource>
        {
            TSource e;

            for (var i = 0; i < source.Length; i++)
            {
                for (var j = source.Length - 1; i < j; j--)
                {
                    // if target[j - 1] > target[j],
                    if (source[j - 1].CompareTo(source[j]) > 0)
                    {
                        e = source[j - 1];
                        source[j - 1] = source[j];
                        source[j] = e;
                    }
                }
            }
            return source;
        }
    }
}
