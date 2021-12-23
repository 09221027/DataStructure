namespace DataStructure
{
    /// <summary>
    /// 哈希表集合
    /// HashSet
    /// 不支持最大最小等
    /// </summary>
    /// <typeparam name="Key"></typeparam>
    public class HashST1Set<Key> : ISet<Key>
    {
        private HashST1<Key> hashST1;
        public bool IsEmpty => hashST1.IsEmpty;
        public int Count => hashST1.Count;
        public void Add(Key e)
        {
            hashST1.Add(e);
        }

        public void Remove(Key e)
        {
            hashST1.Remove(e);
        }

        public bool Contains(Key e)
        {
            return hashST1.Contains(e);
        }
    }
}