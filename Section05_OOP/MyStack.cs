using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Section05_OOP
{
    public class MyStack<T>
    {
        private T[] _items;

        public int Count { get; private set; }
        public int Capacity { get; set; }

        public MyStack()
        {
            const int defaultCapacity = 3;
            _items = new T[defaultCapacity];
        }

        public MyStack(int capacity)
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
    }
}
