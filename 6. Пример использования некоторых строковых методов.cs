using System;
using System.Linq;

namespace FunWithStrings
{

    class Program
    {
        static void Main(string[] args)
        {
            string s = "hello";
            char[] c = { 'h', 'e', 'l', 'l', 'o' };
            Console.WriteLine(s[0]);
            Console.WriteLine(c[0] + c[1] + c[2] + c[3] + c[4]);

            s = new string(c);
            s = s + " world";
            c = s.ToCharArray();
            Console.WriteLine(s);

            s = s.Insert(5, ", dear");
            Console.WriteLine(s);

            s = s.Remove(12);
            Console.WriteLine(s);

            s = s[0].ToString().ToUpper() + s.Substring(1);
            Console.WriteLine(s);

            string[] s1 = s.Split(' ');
            Array.Reverse(s1);
            s = String.Join(' ', s1);
            Console.WriteLine(s);

            int age = 25;
            double weight = 82;
            string name = "Jerry";

            string info = String.Format("Name = {0}, {1:d3} years old, weight = {2:f2} kg", name, age, weight);
            Console.WriteLine(info);

            Console.ReadLine();
        }
    }
}
