using System;
using System.Collections.Generic;
using System.Linq;

namespace Harmonia.Sort
{
    public static class SortHelper
    {
        public static void Swap<TSource>(this IList<TSource> source, int index1, int index2)
        {
            var e = source[index1];
            source[index1] = source[index2];
            source[index2] = e;
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
