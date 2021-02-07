using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AlgoAndDataStructure.LinkedList.DoublyLinkedList
{
    internal class DoublyLinkedList<T> : ICollection<T>
    {
        public DoublyLinkedListNode<T> Head { get; private set; }
        public DoublyLinkedListNode<T> Tail { get; private set; }
        public int Count { get; private set; }

        public void AddFirst(T value)
        {
            AddFirst(new DoublyLinkedListNode<T>(value));
        }

        public void AddFirst(DoublyLinkedListNode<T> node)
        {
            DoublyLinkedListNode<T> temp = Head;
            //point head to node
            Head = node;
            //insert the rest to the list behind
            Head.Next = temp;
            Count++;
            if (Count == 1)
            {
                Tail = Head;
            }
            else
            {
                //Before:Head-----> 5 <-> 7 ->null
                //After:Head----->3<-> 5 <-> 7 ->null
                temp.Previous = Head;
            }
        }

        public void AddLast(T value)
        {
            AddLast(new DoublyLinkedListNode<T>(value));
        }

        public void AddLast(DoublyLinkedListNode<T> node)
        {
            if (Count == 0)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
                //Before: Head->3 <-->5->null
                //After: Head->3 <-->5<->7->null
                node.Previous = Tail;
            }
            Tail = node;
            Count++; Tail.Next = node;
        }

        public void RemoveFirst()
        {
            if (Count != 0)
            {
                //Before: Head-> 3<->5
                //After: Head----->5
                Head = Head.Next;
                Count--;
            }
            if (Count == 0)
            {
                Tail = null;
            }
            else
            {
                //5. Previous was 3 now null
                Head.Previous = null;
            }
        }

        public void RemoveLast()
        {
            if (Count != 0)
            {
                if (Count == 1)
                {
                    Head = null;
                    Tail = null;
                }
                else
                {
                    //Before:Head-->3-->5-->7
                    //       Tail=7
                    //After:Head-->3-->5-->null
                    //        Tail=5
                    Tail.Previous.Next = null;
                    Tail = Tail.Previous;
                }
            }
        }

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(T item)
        {
            AddFirst(item);
        }

        public void Clear()
        {
            Tail = null;
            Head = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            DoublyLinkedListNode<T> current = Head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            DoublyLinkedListNode<T> current = Head;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        public bool Remove(T item)
        {
            DoublyLinkedListNode<T> previous = null;
            DoublyLinkedListNode<T> current = Head;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    if (previous != null)
                    {
                        //Before:Head-->3->5->null
                        //After:Head-->3---->null
                        previous.Next = current.Next;

                        //if item to be deleted does not have a next node
                        //once it is deleted previous node becomes Tail
                        if (current.Next == null)
                        {
                            Tail = previous;
                        }
                        else
                        {
                            //Before:Head->3<->5<->7->null
                            //After:Head->3<---->7->null

                            //Previous=3
                            //current=5
                            //current.Next=7
                            //so.....7.Previous=3
                            current.Next.Previous = previous;
                        }
                        Count--;
                    }
                    else
                    {
                        //if Count=1
                        RemoveFirst();
                    }
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            DoublyLinkedListNode<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();//  throw new NotImplementedException();
        }
    }
}