using System;
using System.Collections.Generic;

namespace myHeap
{
    class Program
    {
        static void Main(string[] args)
        {
            IHeap<int> heap = new Heap<int>()
            {
                Comparer = new HeapSortByDescending<int>()
            };
            int? input;
            while ((input = ReadNumber()) != null)
            {
                heap.Push(input.Value);

            }

            while (heap.Size > 0)
            {
                Console.Write("{0}, ", heap.Pop());
            }

            Console.ReadKey();

        }

        static int? ReadNumber()
        {

            Console.Write("Please, enter the number or anything else to stop: ");

            int result;

            if (int.TryParse(Console.ReadLine(), out result))
                return result;

            return null;
        }
    }
}


