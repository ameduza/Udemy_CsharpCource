using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Section05_OOP
{
    public class MyEnumStack<T> : IEnumerable<T>
    {
        private T[] _items;

        public int Count { get; private set; }
        public int Capacity { get; set; }

        public MyEnumStack()
        {
            const int defaultCapacity = 3;
            _items = new T[defaultCapacity];
        }

        public MyEnumStack(int capacity)
        {
            _items = new T[capacity];
        }

        public void Push(T item)
        {
            if (_items.Length == Count)
            {
                Console.WriteLine("You reached arrays capacity, doubling its size...");
                T[] largeArray = new T[Count * 2];
                Array.Copy(_items, largeArray, Count);
                _items = largeArray;
            }
            _items[Count] = item;
            Count++;
        }

        public void Pop()
        {
            if (Count == 0)
            {
                Console.WriteLine("You reached the bottom of array, nothing to pop");
                throw new InvalidOperationException();
            }
            int lastItem = Count - 1;
            Console.WriteLine($"Pop item {lastItem}: {_items[lastItem]}");
            _items[lastItem] = default;
            Count--;
        }

        public T Peek()
        {
            if (Count == 0)
            {
                Console.WriteLine("You reached the bottom of array, nothing to pop");
                throw new InvalidOperationException();
            }
            int lastItem = Count - 1;
            Console.WriteLine($"Peek item {lastItem}: {_items[lastItem]}");
            return _items[lastItem];
        }

        //public IEnumerator<T> GetEnumerator() => new StackEnumerator<T>(_items, Count);

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class StackEnumerator<T> : IEnumerator<T>
    {
        // This class is not needed in case of "yield return _items[i];" implementation inside desired for cycle
        private readonly T[] array;
        private readonly int count;
        private int index;

        public StackEnumerator(T[] array, int count)
        {
            this.array = array;
            this.count = count;
            index = count;
        }
        public T Current => array[index];
        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            index--;
            return index >= 0;
        }

        public void Reset()
        {
            index = count; // ???
        }
    }
}
