using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MLNET模型图片分类机器学习
{
    class Program
    {
        static void Main(string[] args)
        {
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
        }
    }
}
