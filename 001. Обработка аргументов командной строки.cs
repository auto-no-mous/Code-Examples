using System;

namespace CommandPromtArgumentsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 0)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    Console.WriteLine("{0} argument = {1}", i + 1, args[i]);
                }
            }
            else
                Console.WriteLine("no arguments received");

            Console.ReadKey();

        } 
    }
}
