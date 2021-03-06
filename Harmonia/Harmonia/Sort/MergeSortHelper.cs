﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Harmonia.Sort
{
    public static class MergeSortHelper
    {
        /// <summary>
        /// シーケンスの要素をキーに従って昇順に並べ替えます。
        /// マージ ソートを使用します。
        /// </summary>
        /// <typeparam name="TSource">要素の型。</typeparam>
        /// <typeparam name="TKey">キーの型。</typeparam>
        /// <param name="source">並べ替える配列。</param>
        /// <param name="keySelector">キーを抽出する関数。</param>
        /// <returns>並べ替えられたシーケンス。</returns>
        public static IEnumerable<TSource> MergeSort<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            var keyed = source.Select(e => new KeyedObject0<TSource, TKey>(e, keySelector(e))).ToArray();
            var comparer = Comparer<TKey>.Default;
            keyed.MergeSort((x1, x2) => comparer.Compare(x1.Key, x2.Key));
            return keyed.Select(_ => _.Target);
        }

        /// <summary>
        /// 指定された配列自身をマージ ソートで並べ替えます。
        /// </summary>
        /// <typeparam name="TSource">要素の型。</typeparam>
        /// <param name="source">並べ替える配列。</param>
        /// <param name="compare">2 つの値を比較する関数。</param>
        /// <returns>並べ替えられた配列。参照は <paramref name="source"/> と同じ。</returns>
        public static TSource[] MergeSort<TSource>(this TSource[] source, Func<TSource, TSource, int> compare)
        {
            if (source.Length == 2)
            {
                // 最適化のため、配列の長さが 2 の場合は処理を簡略化します。
                if (compare(source[0], source[1]) > 0)
                {
                    var e = source[0];
                    source[0] = source[1];
                    source[1] = e;
                }
            }
            else if (source.Length > 2)
            {
                var m = source.Length / 2;
                var a1 = MergeSort(source.Take(m).ToArray(), compare);
                var a2 = MergeSort(source.Skip(m).ToArray(), compare);
                var i1 = 0;
                var i2 = 0;
                while (i1 < a1.Length || i2 < a2.Length)
                {
                    if (i2 == a2.Length || i1 < a1.Length && compare(a1[i1], a2[i2]) <= 0)
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
    }
}
