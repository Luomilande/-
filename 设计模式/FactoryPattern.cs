using System;
using System.Collections.Generic;
using System.Text;

namespace 设计模式
{
    /// <summary>
    /// 工厂模式：
    /// 例如，将小车制作过程方式都封装了，需要小车只需通过小车接口来获取
    /// /// </summary>
    public interface Ishape
    {
        public void draw();
    }
    class FactoryPattern
    {
       
    }
    public class Square : shape
    {
        public void draw()
        {
            Console.WriteLine("矩形实现的接口方法draw()");
        }
    }
    public class Circle : shape
    {
        public void draw()
        {
            Console.WriteLine("圆形实现的接口方法draw()");
        }
    }
    public class Triangle : shape
    {
        public void draw()
        {
            Console.WriteLine("三角形实现的接口方法draw()");
        }
    }
    public enum ShapeType
    {
        Square,
        Circle,
        Triangle

    }
    public class ShapeFactory
    {
        public static shape getShape(ShapeType shapetype)
        {
            if (shapetype == ShapeType.Circle)
            {
                return new Circle();
            }
            else if (shapetype == ShapeType.Triangle)
            {
                return new Triangle();
            }
            else
            {
                return new Square();
            }

        }
    }
}
