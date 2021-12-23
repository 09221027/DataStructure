using System;
using System.Text;

namespace DataStructure
{
    public class LinkedList2<E>
    {
        class Node
        {
            public E e { get; set; }
            public Node next { get; set; }

            public Node(E e, Node next)
            {
                this.e = e;
                this.next = next;
            }

            public Node(E e)
            {
                this.e = e;
                this.next = null;
            }

            public override string ToString()
            {
                return e.ToString();
            }
        }

        private Node head;
        private Node tail;

        public int Count { get; private set; }

        public bool IsEmpty => Count == 0;

        public LinkedList2()
        {
            head = null;
            tail = null;
            Count = 0;
        }

        public void AddLast(E e)
        {
            var node = new Node(e);
            if (IsEmpty)
            {
                head = node;
                tail = node;
            }
            else
            {
                tail.next = node;
                tail = node;
            }

            Count++;
        }

        public E RemoveFirst()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("链表为空");
            }

            var e = head.e;
            head = head.next;

            Count--;

            if (head == null)
            {
                tail = null;
            }

            return e;
        }

        public E GetFirst()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("链表为空");
            }

            return head.e;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            var cur = head;
            while (cur != null)
            {
                stringBuilder.Append(cur + "->");
                cur = cur.next;
            }

            stringBuilder.Append("Null");
            return base.ToString();
        }
    }
}