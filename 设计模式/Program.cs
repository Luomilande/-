using System;

namespace 设计模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Ishape Ishape = ShapeFactory.getShape(ShapeType.Circle);
            Ishape.draw();
            Console.WriteLine("Hello World!");
        }
    }
}
