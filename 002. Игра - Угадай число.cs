//Это игра, программа загадывает число, пользователю нужно угадать
//Также здесь есть пример обработки аргументов командной строки

using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 4;
            if (args.Length != 0 && args[0] == "god")
                i = 999;

            Console.Write("Угадай число в диапазоне 1-16: ");
            Random z = new Random();
            int x = z.Next(1,16);
            while (i > 0)
            {

                int y = Convert.ToInt32(Console.ReadLine());
                if (x < y)
                {
                    i--;
                    Console.Write("Не угадал, попробуй меньше (У тебя осталось ещё {0} попыток): ", i);

                }
                else if (x > y)
                {
                    i--;
                    Console.Write("Не угадал, попробуй больше (У тебя осталось ещё {0} попыток): ", i);
                }
                else
                {
                    break;
                }
            }

            if (i != 0)
            {
                Console.WriteLine("Вот блин, ты угадал! ;(");
            }
            else
            {
                Console.WriteLine("Вот блин, ты не угадал! ;)");
            }
        }
    }
}
