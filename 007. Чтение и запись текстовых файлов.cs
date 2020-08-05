//программа читает и записывает в текстовый файл
using System;
using System.IO;
using System.Text;

namespace FileIOExample
{

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Введите номер команды:\n1: Вывести содержимое файла на экран" +
                    "\n2: Дописать текст в конец файла\n3: Перезаписать файл новым текстом\n4: Выход");
                Console.Write("Ваш выбор: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        ShowText(GetText());
                        break;

                    case 2:
                        Console.Write("Введите текст, который нужно дописать: ");
                        string content = Console.ReadLine();
                        WriteToFile(content);
                        break;

                    case 3:
                        Console.Write("Введите текст, который перепишет содержимое: ");
                        string newstr = Console.ReadLine();
                        WriteNewToFile(newstr);
                        break;

                    case 4:
                        return;

                    default:
                        Console.WriteLine("Некорректный ввод. Повторите попытку.");
                        break;
                }
            }
            Console.ReadLine();
        }

        static string GetText()
        {
            using (var sr = new StreamReader("storage.txt", Encoding.UTF8))
            {
                string s = sr.ReadToEnd();
                sr.Close();
                return s;
            }
            

        }
        static void WriteNewToFile(string s)
        {
            using (var sw = new StreamWriter("storage.txt"))
            {
                sw.WriteLine(s);
                sw.Close();
            }
                
        }
        
        static void WriteToFile(string s)
        {
            using (var sw = new StreamWriter("storage.txt", true))
            {
                sw.WriteLine(s);
                sw.Close();
            }
               
        }

        static void ShowText (string s)
        {
            ConsoleColor old = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(s);
            Console.ForegroundColor = old;
        }

    }


}
