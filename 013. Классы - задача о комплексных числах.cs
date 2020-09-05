using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Transactions;

namespace ConsoleApplication1
{
    class Complex
    {
        public double real;
        public double imaginary;

        public Complex (double r=0, double f=0)
        {
            real = r;
            imaginary = f;
        }

        public bool TryReadNumber()
        {
            try 
            {
                double r;
                Console.Write("Real: ");
                r = double.Parse(Console.ReadLine());

                double i;
                Console.Write("Imaginary: ");
                i = double.Parse(Console.ReadLine());

                real = r;
                imaginary = i;

                return true;
            }
            catch
            {
                return false;
            }
        }

        public string ToString ()
        {
            return "(" + real.ToString() + ", " + imaginary.ToString() + "i)";
        }

        public Complex Conjugate ()
        {
            return new Complex(real, imaginary * -1);
        }

        public Complex Add(Complex b)
        {
            return new Complex(real + b.real, imaginary+b.imaginary);
        }

        public Complex Substract(Complex b)
        {
            return new Complex(real - b.real, imaginary-b.imaginary);
        }

        public Complex Multiply(Complex b)
        {
            return new Complex(real * b.real-imaginary*b.imaginary, real*b.imaginary + imaginary*b.real);
        }
        public Complex Multiply(double x)
        {
            return new Complex(real * x, imaginary * x);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Complex a = new Complex(3.0, 4.0); // инициализация значением (3,4і) 
            Complex c = new Complex();
            Console.WriteLine("Enter a complex number (q to quit) :");
            // Ввод комплексного числа (q для завершения) 
            while (c.TryReadNumber()) 
            {
                // значение с 
                Console.WriteLine("\nс is " + c.ToString());
                // значение сопряженного числа 
                Console.WriteLine("complex conjugate is " + c.Conjugate().ToString());
                // значение а
                Console.WriteLine("a is " + a.ToString());
                // значение а + с 
                Console.WriteLine("a + с is " + a.Add(c).ToString());
                // значение а — с 
                Console.WriteLine("a - с is " + a.Substract(c).ToString());
                // значение а * с 
                Console.WriteLine("a * с is " + a.Multiply(c).ToString());
                // значение 2 * с 
                Console.WriteLine("с * 2 is " + c.Multiply(2).ToString());
                Console.Write("Enter a complex number (q to quit) :\n");
            }
            Console.WriteLine("Done!");
        }

    }
}