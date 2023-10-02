using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2.Classes
{
    public class StudentLinkedList
    {
        public sealed class Node
        {
            /// <summary>
            /// Data of current StudentNode
            /// </summary>
            public Student data;
            /// <summary>
            /// Next StudentNode
            /// </summary>
            public Node next;

            /// <summary>
            /// Initialize new StudentNode
            /// </summary>
            /// <param name="data"><paramref name="data"/> to add to StudentNode</param>
            public Node(Student data)
            {
                this.data = data;
                this.next = null;
            }

            /// <summary>
            /// Adds <paramref name="data"/> to end of StudentNode
            /// </summary>
            /// <param name="data"><paramref name="data"/> to add to StudentNode</param>
            public void AddToEnd(Student data)
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
        }

        public Node Head; // LinkedList start adress

        /// <summary>
        /// Initialization of LinkedList
        /// </summary>
        public StudentLinkedList()
        {
            this.Head = null;
        }

        /// <summary>
        /// Adds Student to start of the LinkedList
        /// </summary>
        /// <param name="data">Student to add</param>
        public void AddToStart(Student data)
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
        /// Adds Student to end of the LinkedList
        /// </summary>
        /// <param name="data">Student to add</param>
        public void AddToEnd(Student data)
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