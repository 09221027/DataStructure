using System;

namespace DataStructure
{
    /// <summary>
    /// 循环数组
    /// </summary>
    public class Array2<E>
    {
        private E[] data;
        private int first;
        private int last;

        public Array2(int capacity)
        {
            data = new E[capacity];

            first = 0;
            last = 0;
            Count = 0;
        }

        public Array2() : this(10)
        {
        }

        public int Count { get; private set; }

        public bool IsEmpty => Count == 0;

        public void AddLast(E e)
        {
            if (Count == data.Length)
            {
                ResetCapacity(Count * 2);
            }


            data[last] = e;
            last = (last + 1) % data.Length;
            Count++;
        }

        public E RemoveFirst()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("数组为空");
            }

            if (Count == data.Length / 2)
            {
                ResetCapacity(Count);
            }

            E ret = data[first];
            data[first] = default;
            first = (first + 1) % data.Length;
            Count--;

            return ret;
        }

        public E GetFirst()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("数组为空");
            }

            return data[first];
        }

        private void ResetCapacity(int newCapacity)
        {
            E[] newData = new E[newCapacity];
            for (int i = 0; i < Count; i++)
            {
                newData[i] = data[(first + i) % Count];
            }

            data = newData;
            first = 0;
            last = Count;
        }
    }
}