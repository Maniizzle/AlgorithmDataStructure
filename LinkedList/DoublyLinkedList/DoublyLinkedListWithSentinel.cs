using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoAndDataStructure.LinkedList.DoublyLinkedList
{
    public class Node<T>
    {
        private T element; // reference to the element stored at this node
        private Node<T> prev; // reference to the previous node in the list
        private Node<T> next; // reference to the subsequent node in the list
        public Node(T e, Node<T> p, Node<T> n)
        {
            element = e;
            prev = p;
            next = n;
        }
        public T GetElement() { return element; }
        public Node<T> GetPrev() { return prev; }
        public Node<T> GetNext() { return next; }
        public void SetPrev(Node<T> p) { prev = p; }
        public void SetNext(Node<T> n) { next = n; }
    } 

    public class DoublyLinkedListSentinel<T>
    {  
        //---------------- nested Node class ----------------
       
         // instance variables of the DoublyLinkedList
         private Node<T> _header; // header sentinel
         private Node<T> _trailer; // trailer sentinel
         private int _size = 0; // number of elements in the list
         //∗∗ Constructs a new empty list. ∗/
        public DoublyLinkedListSentinel()
        {
           _header = new Node<T>(default(T), null, null); // create header
           _trailer = new Node<T>(default(T), _header, null); // trailer is preceded by header
           _header.SetNext(_trailer); // header is followed by trailer
         }
            //∗∗ Returns the number of elements in the linked list. ∗/
            public int Size() { return _size; }
            //∗∗ Tests whether the linked list is empty. ∗/
            public bool IsEmpty() { return _size == 0; }
            //∗∗ Returns(but does not remove) the first element of the list. ∗/
            public T First()
            {
                if (IsEmpty()) return default(T);
                return _header.GetNext().GetElement(); // first element is beyond header
            }
        //∗∗ Returns(but does not remove) the last element of the list. ∗/
        public T last()
        {
             if (IsEmpty()) return default(T);
             return _trailer.GetPrev().GetElement(); // last element is before trailer
        }

        //Code Fragment 3.17:Implementation of the DoublyLinkedList class. (Continues in Code Fragment 3.18.). Doubly Linked Lists 137
        // public update methods
        //∗∗ Adds element e to the front of the list. ∗/
        public void AddFirst(T e)
        {
             AddBetween(e, _header, _header.GetNext()); // place just after the header
        }
        //∗∗ Adds element e to the end of the list. ∗/
         public void AddLast(T e)
         {
             AddBetween(e, _trailer.GetPrev(), _trailer); // place just before the trailer
         }
        //∗∗ Removes and returns the first element of the list. ∗/
            public T RemoveFirst()
            {
               if (IsEmpty()) return default(T); // nothing to remove
                return Remove(_header.GetNext()); // first element is beyond header
            }
        //∗∗ Removes and returns the last element of the list. ∗/
        public T RemoveLast()
        {
           if (IsEmpty()) return default(T); // nothing to remove
           return Remove(_trailer.GetPrev()); // last element is before trailer
        }

        // private update methods
        //∗∗ Adds element e to the linked list in between the given nodes. ∗/
        private void AddBetween(T e, Node<T> predecessor, Node<T> successor)
        {
           // create and link a new node
           Node<T> newest = new Node<T>(e, predecessor, successor);
           predecessor.SetNext(newest);
           successor.SetPrev(newest);
           _size++;
        }
        //∗∗ Removes the given node from the list and returns its element. ∗/
        private T Remove(Node<T> node)
        {
          Node<T> predecessor = node.GetPrev();
          Node<T> successor = node.GetNext();
          predecessor.SetNext(successor);
          successor.SetPrev(predecessor);
          _size--;
          return node.GetElement();
        }
 } 
}
