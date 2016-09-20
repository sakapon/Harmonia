using System;
using System.Collections.Generic;
using System.Linq;

namespace Harmonia
{
    public static class SortHelper
    {
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
