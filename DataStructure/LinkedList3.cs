using System;

namespace DataStructure
{
    /// <summary>
    /// 链表键值
    /// </summary>
    /// <typeparam name="Key"></typeparam>
    /// <typeparam name="Value"></typeparam>
    public class LinkedList3<Key, Value>
    {
        private class Node
        {
            public Key key;
            public Value value;
            public Node next;

            public Node(Key key, Value value, Node next)
            {
                this.key = key;
                this.value = value;
                this.next = next;
            }

            public override string ToString()
            {
                return key + ":" + value;
            }
        }

        private Node head;
        public int Count { get; private set; }

        public bool IsEmpty => Count == 0;

        private Node GetNode(Key key)
        {
            var cur = head;
            while (cur != null)
            {
                if (cur.key.Equals(key))
                {
                    return cur;
                }
                cur = cur.next;
            }

            return null;
        }

        public void Add(Key key, Value value)
        {
            var node = GetNode(key);

            if (node == null)
            {
                head = new Node(key, value, head);
                Count++;
            }
            else
            {
                node.value = value;
            }
        }

        public bool Contains(Key key)
        {
            return GetNode(key) == null;
        }

        public Value Get(Key key)
        {
            var node = GetNode(key);
            if (node == null)
            {
                throw new ArgumentException("键" + key + "不存在");
            }
            else
            {
                return node.value;
            }
        }

        public void Set(Key key, Value newValue)
        {
            var node = GetNode(key);
            if (node == null)
            {
                throw new ArgumentException("键" + key + "不存在");
            }
            else
            {
                node.value = newValue;
            }
        }

        public void Remove(Key key)
        {
            if (head == null)
            {
                return;
            }

            if (head.key.Equals(key))
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
                    if (cur.key.Equals(key))
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
    }
}