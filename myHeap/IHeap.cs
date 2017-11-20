using System;
using System.Collections.Generic;
using System.Text;


namespace myHeap
{
    public interface IHeap<T> 
    {
        void Push(T item);

        T Pop();

        int Size { get; }

        IComparer<T> Comparer { set; }
    }
}
