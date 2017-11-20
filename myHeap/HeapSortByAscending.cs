using System;
using System.Collections.Generic;
using System.Text;

namespace myHeap
{
    public class HeapSortByAscending<T> : IComparer<T> where T: IComparable<T>
    {
        public int Compare(T x, T y)
        {
            return x.CompareTo(y);
        }
    }
}
