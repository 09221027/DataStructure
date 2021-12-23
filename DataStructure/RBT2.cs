using System;

namespace DataStructure
{
    public class RBT2<Key, Value> where Key : IComparable<Key>
    {
        private const bool Red = true;
        private const bool Black = false;

        class Node
        {
            public Key key;
            public Value value;
            public Node left;
            public Node right;
            public bool color;

            public Node(Key e, Value value)
            {
                this.key = e;
                this.value = value;
                left = null;
                right = null;
                color = Red;
            }
        }

        private Node root;
        public int Count { get; private set; }

        public RBT2()
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