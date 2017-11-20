using System;
using System.Collections.Generic;
using System.Text;

namespace myHeap
{
    public class Heap<T> : IHeap<T> where T : IComparable<T>
    {
        private IList<T> _listHeap = new List<T>();

        private int GetLeftIndex(int i) =>  2 * i + 1; 
        private int GetRightIndex(int i) => 2 * i + 2;

        private int _size = 0;

        public int Size
        {
            get { return _size; }
        }

        private IComparer<T> _comparer;

        public IComparer<T> Comparer
        {
            set
            {
                this._comparer = value;
            }
        }

        public void Push(T item)
        {
            _listHeap.Add(item);
            this._size++;
        }

        public T Pop()
        {
            this.Build();
            T item = _listHeap[0];
            int last = _listHeap.Count - 1;
            _listHeap[0] = _listHeap[last];
            _listHeap.RemoveAt(last);

            this._size--;
            return item;
        }

        private void Build()
        {
            for (int i = this._listHeap.Count / 2 - 1; i >=0; i--)
            {
                this.Heapify(i);
            }
        }

        private void Heapify(int i)
        {
            int index=i;

            if (this.GetLeftIndex(i) > (this._listHeap.Count - 1)) return;

            if (this.GetRightIndex(i) > (this._listHeap.Count - 1))
            {
                index = this.GetLeftIndex(i);
            }
            else
            {
                if (_comparer.Compare(this._listHeap[GetRightIndex(i)], this._listHeap[GetLeftIndex(i)])>0)
                {
                    index = this.GetLeftIndex(i);
                }
                else
                {
                    index = this.GetRightIndex(i);
                }
            }

            if (_comparer.Compare(this._listHeap[i], this._listHeap[index]) > 0)
            {
                this.Swap(i, index);
                this.Heapify(index);
            }

        }

        private void Swap(int i, int j)
        {
            T tmp = _listHeap[i];
            _listHeap[i] = _listHeap[j];
            _listHeap[j] = tmp;
        }       
    }
}
