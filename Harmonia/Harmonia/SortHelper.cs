using System;
using System.Collections.Generic;
using System.Linq;

namespace Harmonia
{
    public static class SortHelper
    {
        /// <summary>
        /// 指定された配列自身をマージ ソートで並べ替えます。
        /// </summary>
        /// <typeparam name="TSource">要素の型。</typeparam>
        /// <param name="source">並べ替える配列。</param>
        /// <returns>並べ替えられた配列。参照は <paramref name="source"/> と同じ。</returns>
        public static TSource[] MergeSort<TSource>(this TSource[] source) where TSource : IComparable<TSource>
        {
            if (source.Length == 2)
            {
                // 最適化のため、配列の長さが 2 の場合は処理を簡略化します。
                if (source[0].CompareTo(source[1]) > 0)
                {
                    var e = source[0];
                    source[0] = source[1];
                    source[1] = e;
                }
            }
            else if (source.Length > 2)
            {
                var m = source.Length / 2;
                var a1 = MergeSort(source.Take(m).ToArray());
                var a2 = MergeSort(source.Skip(m).ToArray());
                var i1 = 0;
                var i2 = 0;
                while (i1 < a1.Length || i2 < a2.Length)
                {
                    if (i2 == a2.Length || i1 < a1.Length && a1[i1].CompareTo(a2[i2]) <= 0)
                    {
                        source[i1 + i2] = a1[i1];
                        i1++;
                    }
                    else
                    {
                        source[i1 + i2] = a2[i2];
                        i2++;
                    }
                }
            }
            return source;
        }

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

    struct KeyedObject<TSource, TKey> : IComparable<KeyedObject<TSource, TKey>> where TKey : IComparable<TKey>
    {
        public TSource Target { get; }
        public TKey Key { get; }

        public KeyedObject(TSource target, TKey key)
        {
            Target = target;
            Key = key;
        }

        public int CompareTo(KeyedObject<TSource, TKey> other) => Key.CompareTo(other.Key);
    }
}
