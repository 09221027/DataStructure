namespace DataStructure
{
    public class TestSearch
    {
        /// <summary>
        /// 二分查找
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int BinarySearch(int[] arr, int target)
        {
            int l = 0;
            int r = arr.Length - 1;

            while (l <= r)
            {
                var mid = l + (r - l) / 2;

                if (target < arr[mid])
                {
                    r = mid - 1;
                }
                else if (target > arr[mid])
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
    }
}