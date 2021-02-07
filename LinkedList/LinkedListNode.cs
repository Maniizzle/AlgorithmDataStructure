using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoAndDataStructure.LinkedList
{
    /// <summary>
    /// A node in the linkedlist
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedListNode<T>
    {
        public LinkedListNode(T value)
        {
            Value = value;
        }

        /// <summary>
        /// the node value
        /// </summary>
        public T Value { get; set; }

        public LinkedListNode<T> Next { get; set; }
    }
}