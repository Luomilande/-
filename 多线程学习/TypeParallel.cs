using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 多线程学习
{
    class TypeParallel
    {
        public void TheardEstablish()
        {
            //Parallel 创建线程执行任务时，如果主线程闲置也会参与执行任务
            Parallel.Invoke(() =>
            {
                Thread.Sleep(500);
                Console.WriteLine($"执行第1次，当前线程ID：{Thread.CurrentThread.ManagedThreadId}");
            }, () =>
            {
                Thread.Sleep(500);
                Console.WriteLine($"执行第2次，当前线程ID：{Thread.CurrentThread.ManagedThreadId}");
            }, () =>
            {
                Thread.Sleep(500);
                Console.WriteLine($"执行第3次，当前线程ID：{Thread.CurrentThread.ManagedThreadId}");
            }, () =>
            {
                Thread.Sleep(500);
                Console.WriteLine($"执行第4次，当前线程ID：{Thread.CurrentThread.ManagedThreadId}");
            }, () =>
            {
                Thread.Sleep(500);
                Console.WriteLine($"执行第5次，当前线程ID：{Thread.CurrentThread.ManagedThreadId}");
            });

            new Thread(() =>//这里包一层，可以不让主线程参与，可以解决占用主线程的问题。（没有什么问题是包一层解决不了的，解决不了再包一层）
            {
                int[] taskNums = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };//设置任务数
                var data = Parallel.For(1, taskNums.Length, new ParallelOptions()
                {
                    MaxDegreeOfParallelism = 3//一次性执行任务最大数，可以控制并发的线程数，需要控制并发数的时候非常有用
                }, (i) =>
                {
                    Thread.Sleep(1000);
                    Console.WriteLine($"执行第{i}次，当前线程ID：{Thread.CurrentThread.ManagedThreadId}");
                });
            }).Start();
        }
    }
}
