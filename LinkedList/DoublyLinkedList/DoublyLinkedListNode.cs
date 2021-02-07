using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoAndDataStructure.LinkedList.DoublyLinkedList
{
    internal class DoublyLinkedListNode<T>
    {
        public DoublyLinkedListNode(T value)
        {
            Value = value;
        }

        /// <summary>
        /// the node value
        /// </summary>
        public T Value { get; set; }

        public DoublyLinkedListNode<T> Previous { get; set; }
        public DoublyLinkedListNode<T> Next { get; set; }
    }
}