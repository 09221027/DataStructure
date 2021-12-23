using System;

namespace DataStructure
{
    public class SortedArray1<Key> where Key : IComparable<Key>
    {
        private Key[] keys;
        public int Count { get; private set; }

        public SortedArray1(int capacity)
        {
            keys = new Key[capacity];
            Count = 0;
        }

        public SortedArray1() : this(10)
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

        public void Add(Key key)
        {
            var i = Rank(key);

            if (i < Count && keys[i].CompareTo(key) == 0)
            {
                return;
            }

            if (Count == keys.Length)
            {
                ResetCapacity(Count * 2);
            }

            for (int j = Count - 1; j >= i; j--)
            {
                keys[i + 1] = keys[i];
            }

            keys[i] = key;
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
            }

            Count--;
            keys[Count] = default;

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
            for (int i = 0; i < Count; i++)
            {
                newData[i] = keys[i];
            }

            keys = newData;
        }
    }
}