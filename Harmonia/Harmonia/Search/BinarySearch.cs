using System;

namespace Harmonia.Search
{
    public static class BinarySearch
    {
        public static int GetIndex(int[] array, int value)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (array.Length == 0) return -1;

            return Search(0, array.Length);

            int Search(int start, int count)
            {
                if (count == 1)
                    return array[start] == value ? start : -1;

                var m = start + (count >> 1);
                return array[m] > value ?
                    Search(start, m - start) :
                    Search(m, start + count - m);
            }
        }
    }
}
