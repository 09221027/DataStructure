using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Net.Sockets;

namespace DataStructure
{
    /// <summary>
    /// 二叉树
    /// </summary>
    /// <typeparam name="E"></typeparam>
    public class BST1<E> where E : IComparable<E>
    {
        class Node
        {
            public E e;
            public Node left;
            public Node right;

            public Node(E e)
            {
                this.e = e;
                left = null;
                right = null;
            }
        }

        private Node root;
        public int Count { get; private set; }

        public BST1()
        {
            root = null;
            Count = 0;
        }

        public bool IsEmpty => Count == 0;



        public void Add(E e)
        {
            Add(root, e);
        }

        private Node Add(Node node, E e)
        {
            if (node == null)
            {
                Count++;
                return new Node(e);
            }

            if (e.CompareTo(node.e) < 0)
            {
                node.left = Add(node.left, e);
            }
            else if (e.CompareTo(node.e) > 0)
            {
                node.right = Add(node.right, e);
            }

            return node;
        }

        public bool Contains(E e)
        {
            return Contains(root, e);
        }

        private bool Contains(Node node, E e)
        {
            if (node == null)
            {
                return false;
            }

            if (e.CompareTo(node.e) == 0)
            {
                return true;
            }
            else if (e.CompareTo(node.e) < 0)
            {
                return Contains(node.left, e);
            }
            else
            {
                return Contains(node.right, e);
            }
        }

        public E Min()
        {
            if (IsEmpty)
            {
                throw new ArgumentException("空树");
            }

            return Min(root).e;
        }

        private Node Min(Node node)
        {
            if (node.left == null)
            {
                return node;
            }

            return Min(node.left);
        }

        public E Max()
        {
            if (IsEmpty)
            {
                throw new ArgumentException("空树");
            }

            return Max(root).e;
        }

        private Node Max(Node node)
        {
            if (node.right == null)
            {
                return node;
            }

            return Max(node.right);
        }

        public E RemoveMin()
        {
            E ret = Min();
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

        public E RemoveMax()
        {
            E ret = Max();
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

        public void Remove(E e)
        {
            root = Remove(root, e);
        }

        private Node Remove(Node node, E e)
        {
            if (node == null)
            {
                return null;
            }

            if (e.CompareTo(node.e) < 0)
            {
                node.left = Remove(node.left, e);
                return node;
            }
            else if (e.CompareTo(node.e) > 0)
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

            Console.WriteLine(node.e);
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
            Console.WriteLine(node.e);
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
            Console.WriteLine(node.e);
        }

        /// <summary>
        /// 
        /// </summary>
        public void LevelOrder()
        {
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);

            while (q.Count != 0)
            {
                Node cur = q.Dequeue();
                Console.WriteLine(cur.e);

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