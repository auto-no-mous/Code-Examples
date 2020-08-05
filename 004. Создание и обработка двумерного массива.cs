//Задача. Сгенерировать двухмерный массив 5×5 случайных чисел(в диапазоне  [-10;10]). 
//Вывести массив на экран.
//Найти сумму модулей отрицательных нечетных элементов.

using System;


namespace MultidimensionalArrays
{
    class Program
    {
        static void Main(string[] args)
        {

            int[,] m = new int[5, 5];
            FillMatrix(m);
            ShowMatrix(m);
            Console.WriteLine("Модуль суммы отрицательных нечетных чисел = {0}", SearchInMatrix(m));
        }

        static void ShowMatrix(int[,] a)
        {
            int rows = a.GetUpperBound(0) + 1;
            int columns = a.GetUpperBound(1) + 1;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write("{0,4} ", a[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void FillMatrix(int[,] a)
        {
            int rows = a.GetUpperBound(0) + 1;
            int columns = a.GetUpperBound(1) + 1;
            Random rand = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    a[i, j] = rand.Next(-10, 10);
                }
            }
        }

        static int SearchInMatrix(int[,] a)
        {
            int rows = a.GetUpperBound(0) + 1;
            int columns = a.GetUpperBound(1) + 1;
            int answer = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if ((a[i, j] % 2 == 0) && (a[i, j] < 0))
                    {
                        answer += a[i, j];
                    }
                }
            }
            return Math.Abs(answer);
        }
    }

}
