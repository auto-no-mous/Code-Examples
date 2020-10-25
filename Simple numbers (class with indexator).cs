using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Simple
{
    class SimpleNumber
    {
        private int current = 0;
        private List<long> numbers;

        public SimpleNumber()
        {
            numbers = new List<long>();
            numbers.Add(2);
        }

        public int length
        {
            get
            {
                return numbers.Count;
            }
        }
        public long this[int index]
        {
            get
            {
                if (length > index)
                {
                    current = index;
                    return numbers[index];
                }
                else if (index <= 10000)
                {
                    while (index > length - 1)
                    {
                        FindNext();
                    }
                    return numbers[index];

                }
                else
                    return -1;
            }
        }

        private bool IsSimple(long n)
        {
            long stop = n / 2 + 1;
            long d;
            for (d = 2; d <= stop; d++)
            {
                if (n % d == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private long FindNext()
        {
            long start = numbers[length - 1] + 1;
            while (!IsSimple(start))
            {
                start++;
            }
            numbers.Add(start);
            return start;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            SimpleNumber sn = new SimpleNumber();
            Console.Write("What a simple number you need? Enter an index or press enter to get next: ");
            string input = Console.ReadLine();
            int pos = 0;
            int p;
            while (input.ToLower() != "q")
            {
                if (int.TryParse(input, out p))
                {
                    Console.WriteLine("Simple number #{0} = {1}", p, sn[p]);
                    pos = p;
                }

                else
                {
                    pos++;
                    Console.WriteLine("Simple number #{0} = {1}", pos, sn[pos]);
                }

                Console.Write("Enter an index or press enter to get next: ");
                input = Console.ReadLine();
            }


            Console.ReadLine();
        }
    }
}
