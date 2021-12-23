using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = 10000000;
            #region 链表栈和数组栈

            //数组栈 优于 链表栈，链表栈需要new
            //var s1 = new Array1Stack<int>();
            //var t1 = TestStack(s1, N);

            //var s2 = new LinkedList1Stack<int>();
            //var t2 = TestStack(s2, N);

            #endregion

            #region 循环数组队列和带尾指针链表队列

            ////循环数组队列 优于 带尾指针链表队列
            //var q1 = new Array2Queue<int>();
            //var t1 = TestQueue(q1, N);

            //var q2 = new LinkedList2Queue<int>();
            //var t2 = TestQueue(q2, N);

            #endregion

            #region 链表集合和有序数组

            

            #endregion

            Console.ReadKey();
        }

        public static long TestStack(IStack<int> stack, int capacity)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            for (int i = 0; i < capacity; i++)
            {
                stack.Push(i);
            }

            for (int i = 0; i < capacity; i++)
            {
                stack.Pop();
            }

            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        public static long TestQueue(IQueue<int> queue, int capacity)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            for (int i = 0; i < capacity; i++)
            {
                queue.Enqueue(i);
            }

            for (int i = 0; i < capacity; i++)
            {
                queue.Dequeue();
            }

            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

    }
}
