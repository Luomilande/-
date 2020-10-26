using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace 多线程学习
{
    class Program
    {
        /// <summary>
        /// 多线程：
        /// 并行：多个任务并行执行
        /// 并发：CPU将任务切片轮流切换运行
        /// 上锁：线程不能自己锁自己
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            TestDemo td = new TestDemo();
           // td.TestDemoAsync();

            TypeThread typeThread = new TypeThread();
            //typeThread.TheardEstablish();
            //typeThread.TheardLoop();
            TypeAction typeAction = new TypeAction();
            //typeAction.TheardEstablish();
            TypeThreadPool typeThreadPool = new TypeThreadPool();
            typeThreadPool.TheardEstablish();
            TypeParallel typeParallel = new TypeParallel();
            //typeParallel.TheardEstablish();
            Console.ReadKey();
        }
    }
    class TestDemo
    {
        public async  void TestDemoAsync()
        {
            Console.WriteLine($"当前主线程start.....,线程ID：{Thread.CurrentThread.ManagedThreadId}");
            await Task.Run(() =>
            {
                AwaitDemo();
                Console.WriteLine("等我跑完才轮到你!");
            });
            Console.WriteLine("终于到我了，谢谢大哥！");
            //ThreadDemo();
            Console.WriteLine($"当前主线程end.....,线程ID：{Thread.CurrentThread.ManagedThreadId}");
        }

        /// <summary>
        /// 不用await的话，Task后面不会被阻塞，也就是直接运行Task的下一句语句
        /// </summary>
        public void ThreadDemo()
        {
            Task.Run(() =>
            {
                Thread.Sleep(1000);
                

                Console.WriteLine($"ThreadDemo .......,线程ID：{Thread.CurrentThread.ManagedThreadId}");
            });
            Console.WriteLine($"在ThreadDemo之后执行.....，线程ID：{Thread.CurrentThread.ManagedThreadId}");

        }


        /// <summary>
        /// 加了await在Task后一句会被阻塞，当Task运行完以后，才会执行下一步语句
        /// </summary>
        /// <returns></returns>
        public async Task AwaitDemo()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(1000);

                int num = 0;
                int num_1 = 0;
                object lockObj = new object();
                for (int i = 0; i < 10000; i++)
                {
                    num += 1;
                }
                List<Task> tasks = new List<Task>();
                for (int i = 0; i < 10000; i++)
                {
                    tasks.Add(Task.Run(() =>
                    {
                        lock (lockObj)
                        {
                            num_1 += 1;
                        }
                    }));
                }
                Task.WaitAll(tasks.ToArray());//等待所有线程执行完成
                Console.WriteLine($"num的值为：{num},num_1的值为：{num_1}");

                Console.WriteLine($"AwaitDemo .......,线程ID：{Thread.CurrentThread.ManagedThreadId}");
            });
            Console.WriteLine($"在AwaitDemo之后执行.....，线程ID：{Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
