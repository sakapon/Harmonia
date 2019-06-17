using System;

namespace Harmonia.Search
{
    public static class BinarySearch
    {
        // ソート済であることを前提とします。
        public static int GetIndex(int[] array, int value)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (array.Length == 0) return -1;

            return Search(0, array.Length);

            int Search(int start, int count)
            {
                if (count == 1)
                    return array[start] == value ? start : -1;

                var c1 = count >> 1;
                var s2 = start + c1;
                return value < array[s2] ?
                    Search(start, c1) :
                    Search(s2, count - c1);
            }
        }

        // ソート済であることを前提とします。
        // a[i] <= x < a[i+1] のとき、i を返します。
        public static int GetIndexByRange(int[] array, int value)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (array.Length == 0) return -1;

            return Search(0, array.Length);

            int Search(int start, int count)
            {
                if (count == 1)
                    return array[start] <= value ? start : -1;

                var c1 = count >> 1;
                var s2 = start + c1;
                return value < array[s2] ?
                    Search(start, c1) :
                    Search(s2, count - c1);
            }
        }
    }
}
