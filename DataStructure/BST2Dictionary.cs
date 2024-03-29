﻿using System;

namespace DataStructure
{
    /// <summary>
    /// 二叉树映射
    /// </summary>
    /// <typeparam name="Key"></typeparam>
    /// <typeparam name="Value"></typeparam>
    public class BST2Dictionary<Key, Value> : IDictionary<Key, Value> where Key : IComparable<Key>
    {
        private BST2<Key, Value> bst;
        public int Count => bst.Count;
        public bool IsEmpty => bst.IsEmpty;
        public void Add(Key key, Value value)
        {
            bst.Add(key, value);
        }

        public bool ContainsKey(Key key)
        {
            return bst.Contains(key);
        }

        public Value Get(Key key)
        {
            return bst.Get(key);
        }

        public void Set(Key key, Value newValue)
        {
            bst.Set(key, newValue);
        }
    }
}