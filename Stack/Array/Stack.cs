using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AlgoAndDataStructure.Stack.Array
{
    public class Stack<T> : IEnumerable<T>
    {
        private T[] items = new T[0];

        //current number of item in the stack
        private int _size;

        public void Push(T item)
        {
            if (_size == items.Length)
            {
                int newLength = _size == 0 ? 4 : _size * 2;
                T[] newArray = new T[newLength];
                items.CopyTo(newArray, 0);
                items = newArray;
            }
            items[_size] = item;
            _size++;
        }

        public T Pop()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            _size--;
            return items[_size];
        }

        public T Peek()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            return items[_size - 1];
        }

        public int Count { get { return _size; } }

        public void Clear()
        {
            _size = 0;//.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _size - 1; i >= 0; i--)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}