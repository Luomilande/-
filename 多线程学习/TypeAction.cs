using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace 多线程学习
{
    /// <summary>
    /// Action(委托)创建线程，所有的线程都是基于委托实现的
    /// </summary>
    class TypeAction
    {
        public void TheardEstablish()
        {
            AsyncCallback callback = (o) =>
            {
                Console.WriteLine($"Thread end.......，参数：{o.AsyncState}，当前线程ID：{Thread.CurrentThread.ManagedThreadId}");
            };
            Action action = new Action(() =>
            {
                Thread.Sleep(5000);
                Console.WriteLine($"Thread start.......，当前线程ID：{Thread.CurrentThread.ManagedThreadId}");
            });
            
            //action.Invoke();//等待，使用的是同步方式，主线程处于等待状态
            
            //action.BeginInvoke(null, null);//不等待，异步方式，不阻塞
            action.BeginInvoke(callback, "我是参数");//第二个是传给回调的参数,是个object类型
        }
    }
}
