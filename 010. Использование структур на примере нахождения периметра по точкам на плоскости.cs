//программа находит периметр фигуры по точкам в пространстве
//и демонстрирует использование структур
using System;
using System.IO;
using System.Text;

namespace FileIOExample
{
    struct Point
    {
        public double X;
        public double Y;

        public Point(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }

        public void ShowInfo ()
        {
            Console.WriteLine("X = {0}, Y = {1}", X, Y);
        }
        
        public double Distance (Point p)
        {
            return Math.Sqrt((X - p.X) * (X - p.X) + (Y - p.Y) * (Y - p.Y));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Количество точек: ");
            int count = int.Parse(Console.ReadLine());
            double dist = 0;
            Point prev = new Point();
            Point first = new Point();
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Точка №{0}", i + 1);
                Console.Write("Позиция X: ");
                int x = int.Parse(Console.ReadLine());
                Console.Write("Позиция Y: ");
                int y = int.Parse(Console.ReadLine());
                Point current = new Point(x, y);
                if (i>0)
                {
                    dist += prev.Distance(current);
                    prev = current;
                }
                else
                {
                    prev = current;
                    first = current;
                }
            }
            dist += prev.Distance(first);
            if (count > 2)
            {
                Console.WriteLine("Perimeter of {0}-points shape = {1}", count, dist);
            }
            else if (count == 2)
            {
                Console.WriteLine("Perimeter of {0}-points shape = {1}", count, dist/2);
            }
            else
            {
                Console.WriteLine("Not enough points to calculate distance...");
            }
            Console.ReadLine();
        }  
    }
}
