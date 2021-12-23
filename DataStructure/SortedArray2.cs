using System;

namespace DataStructure
{
    /// <summary>
    /// 有序数组键值对
    /// SortedList
    /// SortedDictionary 基于红黑树
    /// </summary>
    /// <typeparam name="Key"></typeparam>
    /// <typeparam name="Value"></typeparam>
    public class SortedArray2<Key, Value> where Key : IComparable<Key>
    {
        private Key[] keys;
        private Value[] values;
        public int Count { get; private set; }

        public SortedArray2(int capacity)
        {
            keys = new Key[capacity];
            values = new Value[capacity];
            Count = 0;
        }

        public SortedArray2() : this(10)
        {
        }

        public bool IsEmpty => Count == 0;

        public int Rank(Key key)
        {
            int l = 0;
            int r = Count - 1;

            while (l <= r)
            {
                var mid = l + (r - l) / 2;

                if (key.CompareTo(keys[mid]) < 0)
                {
                    r = mid - 1;
                }
                else if (key.CompareTo(keys[mid]) > 0)
                {
                    l = mid + 1;
                }
                else
                {
                    return mid;
                }
            }

            return -1;
        }

        public Value Get(Key key)
        {
            if (IsEmpty)
            {
                throw new ArgumentException("数组为空");
            }

            int i = Rank(key);

            if (i < Count && keys[i].CompareTo(key) == 0)
            {
                return values[i];
            }
            else
            {
                throw new ArgumentException("键" + key + "不存在");
            }
        }

        public void Add(Key key, Value value)
        {
            var i = Rank(key);

            if (Count == keys.Length)
            {
                ResetCapacity(Count * 2);
            }

            if (i < Count && keys[i].CompareTo(key) == 0)
            {
                values[i] = value;
                return;
            }

            for (int j = Count - 1; j >= i; j--)
            {
                keys[i + 1] = keys[i];
                values[i + 1] = values[i];
            }

            keys[i] = key;
            values[i] = value;
            Count++;
        }

        public void Remove(Key key)
        {
            if (IsEmpty)
            {
                return;
            }

            var i = Rank(key);

            if (i >= Count || keys[i].CompareTo(key) != 0)
            {
                return;
            }

            for (int j = i + 1; j < Count - 1; j++)
            {
                keys[j - 1] = keys[j];
                values[j - 1] = values[j];
            }

            Count--;
            keys[Count] = default;
            values[Count] = default;

            if (Count == keys.Length / 4)
            {
                ResetCapacity(keys.Length / 2);
            }
        }

        public Key Min()
        {
            if (IsEmpty)
            {
                throw new ArgumentException("数组为空");
            }

            return keys[0];
        }

        public Key Max()
        {
            if (IsEmpty)
            {
                throw new ArgumentException("数组为空");
            }

            return keys[Count - 1];
        }

        public Key Select(int k)
        {
            if (k < 0 || k > Count)
            {
                throw new ArgumentException("索引越界");
            }

            return keys[k];
        }

        public bool Contains(Key key)
        {
            int i = Rank(key);
            return i < Count && keys[i].CompareTo(key) == 0;
        }

        public Key Floor(Key key)
        {
            int i = Rank(key);

            if (i < Count && keys[i].CompareTo(key) == 0)
            {
                return keys[i];
            }

            if (i == 0)
            {
                throw new ArgumentException("没有找到小于和等于" + key + "的最大键");
            }
            else
            {
                return keys[i - 1];
            }
        }

        public Key Ceiling(Key key)
        {
            int i = Rank(key);

            if (i < Count && keys[i].CompareTo(key) == 0)
            {
                return keys[i];
            }

            if (i == Count)
            {
                throw new ArgumentException("没有找到大于和等于" + key + "的最小键");
            }
            else
            {
                return keys[i + 1];
            }
        }


        /// <summary>
        /// 内存的动态管理
        /// </summary>
        /// <param name="capacity"></param>
        public void ResetCapacity(int capacity)
        {
            var newData = new Key[capacity];
            var newValue = new Value[capacity];
            for (int i = 0; i < Count; i++)
            {
                newData[i] = keys[i];
                newValue[i] = values[i];
            }

            keys = newData;
            values = newValue;
        }
    }
}