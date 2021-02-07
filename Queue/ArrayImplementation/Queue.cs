using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AlgoAndDataStructure.Queue.ArrayImplementation
{
    public class Queue<T> : IEnumerable<T>
    {
        private T[] _items = new T[0];

        //the number of items in the queue
        private int _size = 0;

        //the index of the first(oldest) item in the queue
        private int _head = 0;

        //the index of the last(newest) item in the queue
        private int _tail = -1;

        public void Enqueue(T item)
        {
            if (_items.Length == _size)
            {
                int newLength = (_size == 0) ? 4 : _size * 2;
                T[] newArray = new T[newLength];
                if (_size > 0)
                {
                    //copy content
                    //if the array has no wrapping just cpy the valid range
                    //else copy fro the head to the end of the array and them from 0 to the tail
                    //if tail is less than head then we have wrapped
                    int targetIndex = 0;
                    if (_tail < _head)
                    {
                        //copy normal item
                        for (int index = _head; index < _items.Length; index++)
                        {
                            newArray[targetIndex] = _items[index];
                            targetIndex++;
                        }

                        //copy wrapped items
                        for (int index = 0; index <= _tail; index++)
                        {
                            newArray[targetIndex] = _items[index];
                            targetIndex++;
                        }
                    }
                    else
                    {
                        //no wrapping
                        for (int index = _head; index <= _tail; index++)
                        {
                            newArray[targetIndex] = _items[index];
                            targetIndex++;
                        }
                    }
                    _head = 0;
                    _tail = targetIndex - 1;
                }
                else
                {
                    _head = 0;
                    _tail = -1;
                }
                _items = newArray;
            }

            if (_tail == _items.Length - 1)
            {
                _tail = 0;
            }
            else
            {
                _tail++;
            }
            _items[_tail] = item;
            _size++;
        }

        public T Dequeue()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }
            T value = _items[_head];
            if (_head == _items.Length - 1)
            {
                _head = 0;
            }
            else
            {
                _head++;
            }
            _size--;
            return value;
        }

        public T Peek()
        {
            if (_size == 0)
            {
                throw new InvalidOperationException("The queue is empty");
            }
            return _items[_head];//.First.Value;
        }

        public int Count
        {
            get { return _size; }
        }

        public void Clear()
        {
            _size = 0;
            _head = 0;
            _tail = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (_size > 0)
            {
                //if the queue wraps then handle that case
                if (_tail < _head)
                {
                    //head ->end
                    for (int index = _head; index < _items.Length; index++)
                    {
                        yield return _items[index];
                    }
                    //0->tail
                    for (int index = 0; index <= _tail; index++)
                    {
                        yield return _items[index];
                    }
                }
                else
                {
                    for (int index = _head; index < _tail; index++)
                    {
                        yield return _items[index];
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}