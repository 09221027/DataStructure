using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace DataStructure
{
    /// <summary>
    /// 二叉树键值
    /// </summary>
    /// <typeparam name="Key"></typeparam>
    /// <typeparam name="Value"></typeparam>
    public class BST2<Key, Value> where Key : IComparable<Key>
    {
        class Node
        {
            public Key key;
            public Value value;
            public Node left;
            public Node right;

            public Node(Key e, Value value)
            {
                this.key = e;
                this.value = value;
                left = null;
                right = null;
            }
        }

        private Node root;
        public int Count { get; private set; }

        public BST2()
        {
            root = null;
            Count = 0;
        }

        public bool IsEmpty => Count == 0;


        public void Add(Key key, Value value)
        {
            Add(root, key, value);
        }

        private Node Add(Node node, Key key, Value value)
        {
            if (node == null)
            {
                Count++;
                return new Node(key, value);
            }

            if (key.CompareTo(node.key) < 0)
            {
                node.left = Add(node.left, key, value);
            }
            else if (key.CompareTo(node.key) > 0)
            {
                node.right = Add(node.right, key, value);
            }
            else
            {
                node.value = value;
            }

            return node;
        }

        public Key Min()
        {
            if (IsEmpty)
            {
                throw new ArgumentException("空树");
            }

            return Min(root).key;
        }

        private Node Min(Node node)
        {
            if (node.left == null)
            {
                return node;
            }

            return Min(node.left);
        }

        public Key Max()
        {
            if (IsEmpty)
            {
                throw new ArgumentException("空树");
            }

            return Max(root).key;
        }

        private Node Max(Node node)
        {
            if (node.right == null)
            {
                return node;
            }

            return Max(node.right);
        }

        public Key RemoveMin()
        {
            Key ret = Min();
            root = RemoveMin(root);
            return ret;
        }

        private Node RemoveMin(Node node)
        {
            if (node.left == null)
            {
                Count--;
                return node.right;
            }

            node.left = RemoveMin(node.left);
            return node;
        }

        public Key RemoveMax()
        {
            Key ret = Max();
            root = RemoveMin(root);
            return ret;
        }

        private Node RemoveMax(Node node)
        {
            if (node.right == null)
            {
                Count--;
                return node.left;
            }

            node.right = RemoveMin(node.right);
            return node;
        }

        public void Remove(Key e)
        {
            root = Remove(root, e);
        }

        private Node Remove(Node node, Key e)
        {
            if (node == null)
            {
                return null;
            }

            if (e.CompareTo(node.key) < 0)
            {
                node.left = Remove(node.left, e);
                return node;
            }
            else if (e.CompareTo(node.key) > 0)
            {
                node.right = Remove(node.right, e);
                return node;
            }
            else
            {
                if (node.right == null)
                {
                    Count--;
                    return node.left;
                }

                if (node.left == null)
                {
                    Count--;
                    return node.right;
                }

                var s = Min(node.right);
                s.right = RemoveMin(node);
                s.left = node.left;

                return s;
            }
        }

        private Node GetNode(Node node, Key key)
        {
            if (node == null) return null;

            if (key.CompareTo(node.key) < 0)
            {
                return GetNode(node.left, key);
            }
            else if (key.CompareTo(node.key) > 0)
            {
                return GetNode(node.right, key);
            }
            else
            {
                return node;
            }
        }

        public bool Contains(Key key)
        {
            return GetNode(root, key) != null;
        }

        public Value Get(Key key)
        {
            var node = GetNode(root, key);

            if (node == null)
            {
                throw new ArgumentException("不存在");
            }

            return node.value;
        }

        public void Set(Key key, Value newValue)
        {
            var node = GetNode(root, key);

            if (node == null)
            {
                throw new ArgumentException("不存在");
            }
            else
            {
                node.value = newValue;
            }
        }

        //前序遍历，深度优先
        public void PreOrder()
        {
            PreOrder(root);
        }

        private void PreOrder(Node node)
        {
            if (node == null)
            {
                return;
            }

            Console.WriteLine(node.key);
            PreOrder(node.left);
            PreOrder(node.right);
        }

        //中序遍历
        public void InOrder()
        {
            InOrder(root);
        }

        private void InOrder(Node node)
        {
            if (node == null)
            {
                return;
            }

            InOrder(node.left);
            Console.WriteLine(node.key);
            InOrder(node.right);
        }

        //后序遍历
        public void PostOrder()
        {
            PostOrder(root);
        }

        private void PostOrder(Node node)
        {
            if (node == null)
            {
                return;
            }

            PostOrder(node.left);
            PostOrder(node.right);
            Console.WriteLine(node.key);
        }

        public void LevelOrder()
        {
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);

            while (q.Count != 0)
            {
                Node cur = q.Dequeue();
                Console.WriteLine(cur.key);

                if (cur.left != null)
                {
                    q.Enqueue(cur.left);
                }

                if (cur.right != null)
                {
                    q.Enqueue(cur.right);
                }
            }
        }

        public int MaxHeight()
        {
            return MaxHeight(root);
        }

        private int MaxHeight(Node node)
        {
            if (node == null) return 0;
            return Math.Max(MaxHeight(node.left), MaxHeight(node.right)) + 1;
        }
    }
}