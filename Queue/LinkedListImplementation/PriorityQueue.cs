using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AlgoAndDataStructure.Queue.LinkedListImplementation
{
    public class PriorityQueue<T> : IEnumerable<T> where T : IComparable<T>
    {
        private LinkedList<T> _items = new LinkedList<T>();

        public void Enqueue(T item)
        {
            if (_items.Count == 0)
            {
                _items.AddLast(item);
            }
            else
            {
                var current = _items.First;

                while (current != null && current.Value.CompareTo(item) > 0)
                {
                    current = current.Next;
                }

                if (current == null)
                {
                    //we made it to the end of the list
                    _items.AddLast(item);
                }
                else
                {
                    //the current time is <= the one being added
                    //so add the item before it
                    _items.AddBefore(current, item);
                }
            }
        }

        public T Dequeue(T item)
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }
            //store the last value in a temporary variable
            T value = _items.First.Value;
            _items.RemoveFirst();
            return value;
        }

        public T Peek()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }
            return _items.First.Value;
        }

        public int Count
        {
            get { return _items.Count; }
        }

        public void Clear()
        {
            _items.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}