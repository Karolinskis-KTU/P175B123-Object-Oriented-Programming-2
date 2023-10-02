using System.Collections;
using System;
using System.Collections.Generic;

namespace Lab3.Classes
{
    public class LinkList<T> : IEnumerable<T>, IComparable<LinkList<T>>, IEquatable<LinkList<T>> where T: IComparable<T>, IEquatable<T>
    {
        class Node
        {
            /// <summary>
            /// Data of current Node
            /// </summary>
            public T Data;
            /// <summary>
            /// Next Node
            /// </summary>
            public Node Next;

            public Node(T data, Node next = null)
            {
                this.Data = data;
                this.Next = next;
            }

        }

        private Node head; // List start address
        private Node tail;

        /// <summary>
        /// Creates an empty linked list
        /// </summary>
        public LinkList()
        {
        }

        /// <summary>
        /// Creates a linked list with <paramref name="other"/> data
        /// </summary>
        /// <param name="other">Data to add</param>
        public LinkList(IEnumerable<T> other)
        {
            foreach (var value in other)
            {
                Add(value);
            }
        }

        /// <summary>
        /// adds object to start of a list
        /// </summary>
        /// <param name="data">object to add</param>
        public void Add(T data)
        {
            Node node = new Node(data, null);
            if (tail != null && head != null)
            {
                tail.Next = node;
                tail = node;
            }
            else
            {
                tail = node;
                head = node;
            }
        }

        /// <summary>
        /// Count how many elements are in the list
        /// </summary>
        /// <returns>Number of stored elements in list</returns>
        public int Count()
        {
            int count = 0;
            for (Node node = head; node != null; node = node.Next)
            {
                count++;
            }
            return count;
        }

        /// <summary>
        /// sorts user list
        /// </summary>
        public void Sort()
        {
            for (Node node1 = head; node1.Next != null; node1 = node1.Next)
            {
                Node max = node1;
                for (Node node2 = node1; node2 != null; node2 = node2.Next)
                {
                    if (node2.Data.CompareTo(max.Data) < 0)
                        max = node2;
                }
                T temp = node1.Data;
                node1.Data = max.Data;
                max.Data = temp;
            }

        }

        /// <summary>
        /// Enumerate all elements in list
        /// </summary>
        /// <returns>Enumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (Node node = head; node != null; node = node.Next)
            {
                yield return node.Data;
            }
        }

        /// <summary>
        /// Enumerate all elements in list
        /// </summary>
        /// <returns>Enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Comapres ordering of two lists
        /// </summary>
        /// <param name="other">Other list to compare to</param>
        /// <returns></returns>
        public int CompareTo(LinkList<T> other)
        {
            var otherEnumerator = other.GetEnumerator();
            foreach (var value in this)
            {
                if (otherEnumerator.MoveNext())
                {
                    int comparison = value.CompareTo(otherEnumerator.Current);
                    if (comparison != 0)
                    {
                        return comparison;
                    }
                } else
                {
                    return -1;
                }
            }

            if (otherEnumerator.MoveNext())
            {
                return 1;
            }

            return 0;
        }

        /// <summary>
        /// Checks if both linked lists have the same values
        /// </summary>
        /// <param name="other">Linked list to compare to</param>
        /// <returns>True if both lists have the same values; Otherwise False</returns>
        public bool Equals(LinkList<T> other)
        {
            var otherEnumerator = other.GetEnumerator();
            foreach (var value in this)
            {
                if (otherEnumerator.MoveNext())
                {
                    if (!value.Equals(otherEnumerator.Current))
                    {
                        // If not all elements in list are equal
                        return false;
                    }
                }
                else
                {
                    // If other list has less elements
                    return false;
                }
            }

            if (otherEnumerator.MoveNext())
            {
                // If other list had more values left
                return false;
            }

            // If both lists have the same values and are the same size
            return true;
        }
    }
}