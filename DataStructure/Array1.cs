using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    /// <summary>
    /// 动态数组
    /// 底层采用静态数组
    /// 内存连续，对于index取值为O(1)
    /// Get,Set O(1)
    /// Add,Remove O(n)
    /// </summary>
    public class Array1<TE> : IEnumerable
    {
        private TE[] _data;//静态数组

        public int Count { get; private set; }

        public int Capacity => _data.Length;

        public bool IsEmpty => Count == 0;

        public Array1(int capacity)
        {
            Count = 0;
            _data = new TE[capacity];
        }

        public Array1() : this(10)
        {

        }

        /// <summary>
        /// 增
        /// </summary>
        /// <param name="index"></param>
        /// <param name="e"></param>
        public void Add(int index, TE e)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentException("数组索引越界");
            }

            if (Count == _data.Length)
            {
                ResetCapacity(2 * _data.Length);
            }

            for (int i = Count - 1; i >= index; i--)//从index到静态数组末尾
            {
                _data[i + 1] = _data[i];//逐个后移
            }

            _data[index] = e;//赋值
            Count++;
        }

        public void AddLast(TE e)
        {
            Add(Count, e);
        }

        public void AddFirst(TE e)
        {
            Add(0, e);
        }

        /// <summary>
        /// 查
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public TE Get(int index)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentException("数据索引越界");
            }

            return _data[index];
        }

        public TE GetFirst()
        {
            return Get(0);
        }

        public TE GetLast()
        {
            return Get(Count - 1);
        }

        /// <summary>
        /// 改
        /// </summary>
        /// <param name="index"></param>
        /// <param name="newE"></param>
        public void Set(int index, TE newE)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentException("数据索引越界");
            }

            _data[index] = newE;
        }

        public bool Contains(TE e)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_data[i].Equals(e))
                {
                    return true;
                }
            }

            return false;
        }

        public int IndexOf(TE e)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_data[i].Equals(e))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// 删
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public TE RemoveAt(int index)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentException("数据索引越界");
            }

            var del = _data[index];

            for (int i = index + 1; i < Count - 1; i++)
            {
                _data[i - 1] = _data[i];
            }

            Count--;
            _data[index] = default;

            if (Count == _data.Length / 2)
            {
                ResetCapacity(_data.Length / 2);
            }

            return del;
        }

        public TE RemoveFirst()
        {
            return RemoveAt(0);
        }

        public TE RemoveLast()
        {
            return RemoveAt(Count - 1);
        }

        public void Remove(TE e)
        {
            int index = IndexOf(e);
            if (index < 0) return;
            RemoveAt(index);
        }

        /// <summary>
        /// 内存的动态管理
        /// </summary>
        /// <param name="capacity"></param>
        public void ResetCapacity(int capacity)
        {
            var newData = new TE[capacity];
            for (int i = 0; i < Count; i++)
            {
                newData[i] = _data[i];
            }

            _data = newData;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"Array1: count={Count} capacity={_data.Length}\n");
            stringBuilder.Append("[");
            for (int i = 0; i < _data.Length; i++)
            {
                stringBuilder.Append(_data[i]);
                if (i != Count - 1)
                {
                    stringBuilder.Append(",");
                }
            }

            stringBuilder.Append("]");
            return stringBuilder.ToString();
        }


        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < _data.Length; i++)
            {
                yield return _data[i];
            }
        }
    }
}