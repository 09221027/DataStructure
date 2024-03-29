﻿using System;

namespace DataStructure
{
    /// <summary>
    /// 二叉树集合
    /// </summary>
    /// <typeparam name="E"></typeparam>
    public class BST1Set<E> : ISet<E> where E : IComparable<E>
    {
        private BST1<E> bst;

        public bool IsEmpty => bst.IsEmpty;
        public int Count => bst.Count;
        public void Add(E e)
        {
            bst.Add(e);
        }

        public void Remove(E e)
        {
            bst.Remove(e);
        }

        public bool Contains(E e)
        {
            return bst.Contains(e);
        }
    }
}