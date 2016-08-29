using System;
using System.Collections.Generic;
using System.Linq;

namespace Harmonia
{
    public static class SortHelper
    {
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
