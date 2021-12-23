using System;
using System.Text;

namespace DataStructure
{
    /// <summary>
    /// 链表
    /// 不需要管理内存
    /// Add,Remove 更优秀
    /// </summary>
    /// <typeparam name="E"></typeparam>
    public class LinkedList1<E>
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

        public int Count { get; private set; }

        public bool IsEmpty => Count == 0;

        public void Add(int index, E e)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentException("数组索引越界");
            }

            if (index == 0)
            {
                head = new Node(e, head);
            }
            else
            {
                var pre = head;
                for (int i = 0; i < index; i++)//指针移动到本节点前
                {
                    pre = pre.next;
                }

                pre.next = new Node(e, pre.next);
            }

            Count++;
        }

        public void AddFirst(E e)
        {
            Add(0, e);
        }

        public void AddLast(E e)
        {
            Add(Count, e);
        }

        public E Get(int index)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentException("数组索引越界");
            }

            var cur = head;
            for (int i = 0; i < index; i++)
            {
                cur = cur.next;
            }

            return cur.e;
        }

        public E GetFirst()
        {
            return Get(0);
        }

        public E GetLast()
        {
            return Get(Count - 1);
        }

        public void Set(int index, E newE)
        {
            var cur = head;
            for (int i = 0; i < index; i++)
            {
                cur = cur.next;
            }

            cur.e = newE;
        }

        public bool Contains(E e)
        {
            var cur = head;
            while (cur != null)
            {
                if (cur.e.Equals(e))
                {
                    return true;
                }

                cur = cur.next;
            }

            return false;
        }

        public E RemoveAt(int index)
        {
            if (index == 0)//需要移动head
            {
                var delNode = head;
                head = head.next;
                Count--;
                return delNode.e;
            }
            else
            {
                var cur = head;
                for (int i = 0; i < index; i++)
                {
                    cur = cur.next;
                }

                var delNode = cur.next;
                cur.next = cur.next.next;
                Count--;
                return delNode.e;
            }
        }

        public E RemoveFirst()
        {
            return RemoveAt(0);
        }

        public E RemoveLast()
        {
            return RemoveAt(Count - 1);
        }

        public void RemoveAtFirst()
        {
            RemoveAt(0);
        }

        public void Remove(E e)
        {
            if (head == null)
            {
                return;
            }

            if (head.e.Equals(e))
            {
                head = head.next;
                Count--;
            }
            else
            {
                Node cur = head;
                Node pre = null;
                while (cur != null)
                {
                    if (cur.e.Equals(e))
                    {
                        break;
                    }

                    pre = cur;
                    cur = cur.next;
                }

                if (cur != null)
                {
                    pre.next = cur.next;
                    Count--;
                }
            }
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