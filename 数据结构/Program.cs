using System;

namespace 数据结构
{
    class Program
    {
   
        static void Main(string[] args)
        {
            MyStack myStack = new MyStack();
            
            //myStack.Push(7);//存10到栈顶
            Console.WriteLine($"创建顺序栈，请输入栈长度：");//打印栈顶
            int length = Convert.ToInt32(Console.ReadLine());
            myStack.SeqStack(length);//创建长度为10的栈

            while (true)
            {
                Console.WriteLine($"1：入栈");
                Console.WriteLine($"2：出栈");
                Console.WriteLine($"3：打印");
                int a=Convert.ToInt32( Console.ReadLine());
                switch(a)
                {
                    case 1:
                        Console.WriteLine("请输入入栈元素!");
                        int data = Convert.ToInt32(Console.ReadLine());
                        myStack.Push(data);
                        myStack.Println();
                        break;
                    case 2:
                        myStack.Pop();
                        myStack.Println();
                        break;
                    case 3:
                        myStack.Println();
                        break;
                    case 4:
                        return;
                }
            }
        }
    }
    class MyStack
    {
        public int maxSize;//栈容量
        public int MaxSize
        {
            get { return maxSize; }
            set { maxSize = value; }
        }
        public int [] data;//数组存储数据元素

        public int top;//栈顶
        public void SeqStack(int max)//初始化栈
        {
            data = new int[max];
            maxSize = max;
            top = -1;
        }
        public int this[int index]
        {
            get {return data[index]; }
            set { data[index] = value; }
        }
        public void Println() //栈顶打印
        {
           int value = data[top];
            Console.WriteLine($"当前栈顶元素为：{ value}，栈顶所在位：{top}，栈长度：{MaxSize}");
            Console.WriteLine();
        }
        public bool  Push(int value)//入栈
        {
            
            if(maxSize> data.Length)
            {
                Console.WriteLine("栈满");
                return false;
            }
            data[top + 1] = value;
            top++;
            return true;
        }
        public bool Pop()//出栈
        {
            if(data.Length<0)
            {
                Console.WriteLine("栈空");
                return false;
            }
            data[top] = 0;
            top--;
            return true;
        }
    }
}
