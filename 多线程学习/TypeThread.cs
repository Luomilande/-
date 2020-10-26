using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace 多线程学习
{
    /// <summary>
    /// 使用Thread的类创建线程，Thread是CLR2.0(framework 2.0)才出现的。
    /// </summary>
    class TypeThread
    {
        public void Dosomething()
        {
            Console.WriteLine("线程休眠!");
            Thread.Sleep(5000);
            Console.WriteLine($"方式1，当前线程ID：{Thread.CurrentThread.ManagedThreadId}");
            
        }
        public void TheardEstablish()
        {
            {
                //framework2.0创建多线程的方式
                //ThreadStart 是一个无参数的委托
                //创建方式1：
                ThreadStart threadStart = this.Dosomething;
                Thread t = new Thread(threadStart);

                ThreadStart threadStart2 = this.Dosomething;
                Thread t2 = new Thread(threadStart2);
                t.Start();
                t2.Start();
                // t.Start();//运行当前线程
                // Console.WriteLine("结束");


                Console.WriteLine($"当前主线程，当前线程ID：{Thread.CurrentThread.ManagedThreadId}");
                //创建方式2：
                Thread thread = new Thread(() =>
                {
                    Thread.Sleep(3000);
                    Console.WriteLine($"Thread2，当前线程ID：{Thread.CurrentThread.ManagedThreadId}");
                });
                thread.Start();//运行当前线程
               // thread.Join();//主等待子线程结束
                Console.WriteLine("主线程结束。");

                //不卡界面的方式，重新开启一个线程用于等待线程
                Thread thread2 = new Thread(() =>
                {
                    thread.Join();
                    Console.WriteLine($"Thread2 end.......，当前线程ID：{Thread.CurrentThread.ManagedThreadId}");
                });
                thread2.Start();
                Console.WriteLine($"当前主线程end.....,线程ID：{Thread.CurrentThread.ManagedThreadId}");
            }
        }

        public void TheardLoop()
        {
            for(int i = 0; i < 20; i++)
            {
                int k = i;
                new Thread(() =>
                {
                    Console.WriteLine($"执行第{k}次，当前线程ID：{Thread.CurrentThread.ManagedThreadId}");
                }).Start();
            }
        }
    }
}
