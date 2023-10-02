using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2.Classes
{
    public class ProjectLinkedList
    {
        public sealed class Node
        {
            /// <summary>
            /// Data of current ProjectNode
            /// </summary>
            public Project data;
            /// <summary>
            /// Next Project Node
            /// </summary>
            public Node next;

            public Node(Project data)
            {
                this.data = data;
                this.next = null;
            }

            /// <summary>
            /// Adds <paramref name="data"/> to end of ProjectNode
            /// </summary>
            /// <param name="data"><paramref name="data"/> to add to ProjectNode</param>
            public void AddToEnd(Project data)
            {
                if (next == null)
                {
                    next = new Node(data);
                }
                else
                {
                    next.AddToEnd(data);
                }
            }

            /// <summary>
            /// Adds and sorts <paramref name="data"/> to ProjectNode
            /// </summary>
            /// <param name="data"><paramref name="data"/> to add to ProjectNode</param>
            public void AddSorted(Project data)
            {
                if (next == null)
                {
                    next = new Node(data);
                }
                else if (data.CompareTo(next.data) < 0)
                {
                    Node temp = new Node(data);
                    temp.next = this.next;
                    this.next = temp;
                }
                else
                {
                    next.AddSorted(data);
                }
            }
        }

        public Node Head; // List start address

        /// <summary>
        /// Initialization of LinkedList
        /// </summary>
        public ProjectLinkedList()
        {
            this.Head = null;
        }

        /// <summary>
        /// Sorts data while adding it
        /// </summary>
        /// <param name="data">Project data to add</param>
        public void AddSorted(Project data)
        {
            if (Head == null)
            {
                Head = new Node(data);
            }
            else if(data.CompareTo(Head.data) < 0)
            {
                AddToStart(data);
            } else
            {
                Head.AddSorted(data);
            }
        }

        /// <summary>
        /// Adds Project to start of the LinkedList
        /// </summary>
        /// <param name="data">Project to add</param>
        public void AddToStart(Project data)
        {
            if (Head == null) 
            {
                Head = new Node(data);
            } else
            {
                Node temp = new Node(data);
                temp.next = Head;
                Head = temp;
            }
        }

        /// <summary>
        /// Adds Project to the end of the LinkedList
        /// </summary>
        /// <param name="data">Project to add</param>
        public void AddToEnd(Project data)
        {
            if (Head == null)
            {
                Head = new Node(data);
            }
            else
            {
                Head.AddToEnd(data);
            }
        }

    }
}