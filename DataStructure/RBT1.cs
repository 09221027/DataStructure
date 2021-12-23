using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace DataStructure
{
    /// <summary>
    /// 左倾红黑树
    /// </summary>
    /// <typeparam name="E"></typeparam>
    public class RBT1<E> where E : IComparable<E>
    {
        private const bool Red = true;
        private const bool Black = false;

        class Node
        {
            public E e;
            public Node left;
            public Node right;
            public bool color;

            public Node(E e)
            {
                this.e = e;
                left = null;
                right = null;
                color = Red;
            }
        }

        private Node root;
        public int Count { get; private set; }

        public RBT1()
        {
            root = null;
            Count = 0;
        }

        public bool IsEmpty => Count == 0;

        private bool IsRed(Node node)
        {
            if (node == null)
            {
                return Black;
            }

            return node.color;
        }

        private Node LeftRotate(Node node)
        {
            var x = node.right;
            node.right = x.left;
            x.left = node;
            x.color = node.color;
            node.color = Red;
            return x;
        }

        private void FlipColors(Node node)
        {
            node.color = Red;
            node.left.color = Black;
            node.right.color = Black;
        }

        private Node RightRotate(Node node)
        {
            var x = node.left;
            node.left = x.right;
            x.right = node;
            x.color = node.color;
            node.color = Red;
            return x;
        }

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

            //维护特殊规则
            //右子节点为红，左子节点为黑色
            if (IsRed(node.right) && !IsRed(node.left))
            {
                node = LeftRotate(node);
            }

            //连续子节点为红色
            if (IsRed(node.left) && IsRed(node.left.left))
            {
                node = RightRotate(node);
            }

            //左右子节点都为红色
            if (IsRed(node.left) && IsRed(node.right))
            {
                FlipColors(node);
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