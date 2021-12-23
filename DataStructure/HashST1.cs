namespace DataStructure
{
    /// <summary>
    /// 哈希表
    /// </summary>
    /// <typeparam name="Key"></typeparam>
    public class HashST1<Key>
    {
        private LinkedList1<Key>[] hashtable;
        private int N;
        private int M;

        public HashST1(int M)
        {
            this.M = M;
            N = 0;
            hashtable = new LinkedList1<Key>[M];
            for (int i = 0; i < M; i++)
            {
                hashtable[i] = new LinkedList1<Key>();
            }
        }

        public HashST1() : this(97)
        {
        }

        public int Count => N;

        public bool IsEmpty => N == 0;

        private int Hash(Key key)
        {
            return (int)(key.GetHashCode() & 0x7ffffffff) % M;
        }

        public void Add(Key key)
        {
            var list = hashtable[Hash(key)];
            if (list.Contains(key))
            {
                return;
            }
            else
            {
                list.AddFirst(key);
                N++;
            }
        }

        public void Remove(Key key)
        {
            var list = hashtable[Hash(key)];
            if (list.Contains(key))
            {
                list.Remove(key);
                N--;
            }
        }

        public bool Contains(Key key)
        {
            var list = hashtable[Hash(key)];
            return list.Contains(key);
        }
    }
}