
using System;
using System.IO;

namespace ConsoleApp2
{
    public class Person
    {
        private static int population = 0;
        public string name;
        public int age;

        public Person(string n = "Неизвестно", int a = 18)
        { name = n; age = a; population++; }//конструктор

        public void GetInfo()
        {
            Console.WriteLine($"Имя: {name}  Возраст: {age}");
        }

        public static int Population
        {
            get
            {
                return population;
            }
        }

        ~Person()
        {
            population--;
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            {
                Person p1 = new Person("Vasya", 22);
                Person p2 = new Person("Petya");

                Console.WriteLine("Всего объектов Person: {0}", Person.Population);
                p1.GetInfo();
                p2.GetInfo();
            }

            Console.Write("G - force call GC, N - create new Person, or Q to quit (press enter to refresh): ");
            string input = Console.ReadLine().ToLower();
            while (input != "q")
            {
                if (input == "g")
                {

                    GC.Collect();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Всего объектов Person: {0}", Person.Population);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else if (input == "n")
                {
                    Person p4 = new Person();
                    p4.GetInfo();
                }
                else
                {
                    Console.WriteLine("Всего объектов Person: {0}", Person.Population);
                }
                Console.Write("G - call garbage collector, Q - quit, or press enter to refresh: ");
                input = Console.ReadLine().ToLower();
            }
        }
    }
}


