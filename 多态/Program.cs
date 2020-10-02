using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace 多态
{
    class BasePen
    {
        public string TypeName { get; set; }
    }
    class QianPen : BasePen
    {
        public QianPen()
        {
            TypeName = "铅笔";
        }
        public void Write()
        {
            Console.WriteLine("用铅芯写字");

        }
    }

    class Pen : BasePen
    {
        public Pen()
        {
            TypeName = "钢笔";
        }
        public void Write()
        {
            Console.WriteLine("用墨水写字");

        }
    }

    enum PenType
    { 
        铅笔,钢笔
      
    }
    //生产工厂
    class Factory
    {
        public BasePen CreatePen(PenType type)
        {
            switch (type)
            {
                case PenType.铅笔:
                    return new QianPen();
                case PenType.钢笔:
                    return new Pen();
                default:
                    Console.WriteLine("不存在");
                    return null;
            }

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Factory factory = new Factory();
            List<BasePen> basePens = new List<BasePen>();
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                    basePens.Add(factory.CreatePen(PenType.钢笔));
                else
                    basePens.Add(factory.CreatePen(PenType.铅笔));
            }
            foreach (var item in basePens)
            {
                Console.WriteLine(item.TypeName);
            }
        }
    }
}
