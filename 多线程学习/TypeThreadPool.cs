using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace 多线程学习
{
    /// <summary>
    /// 线程池创建线程
    /// </summary>
    class TypeThreadPool
    {
        public void Dosomething(object state)
        {

            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}号线程休眠!");

            Thread.Sleep(5000);
            Console.WriteLine($"方式1，当前线程ID：{Thread.CurrentThread.ManagedThreadId}");
        }
        public void TheardEstablish()
        {

            ThreadPool.SetMaxThreads(10, 10);//设置线程池最大线程数量为15
            //ThreadPool.SetMinThreads(5, 5);//设置线程池最小线程数量为5
            //使用线程池的方式创建线程可以更好的利于线程，创建的线程可以重复利于，性能相当于Thread创建的方式更好
            //原理：一次性创建多个线程放到线程池中，使用线程池里面的线程去执行任务，任务执行完成后再把线程放回去，需要执行任务后先判断线程池有没有
            //空闲的线程，如果没有会等待其它线程执行完成后再从线程池取空闲的线程来执行任务


            for (int i = 0; i < 20; i++)
            {
                int k = i;
                ThreadPool.QueueUserWorkItem(new WaitCallback(Dosomething));
            }
        }
    }
}
