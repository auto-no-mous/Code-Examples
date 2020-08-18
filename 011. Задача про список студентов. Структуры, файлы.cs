/* Эта программа решает задачу, указанную в этом комментарии.
 * 
Создайте структуру с именем Student, содержащую поля:
фамилия и инициалы, номер группы, успеваемость (массив из
пяти целочисленных элементов). Реализуйте у структуры
2 метода. Первый - ShowInfo()–выводящий фамилию и инициалы,
номер группы и средний балл успеваемости. Второй – IsExcellent,
возвращающий true, в случае если студент претендует на
повышенную стипендию (все оценки студента не ниже 4),
и false – в противном случае.

Программа получает на вход файл, содержащий не более 100 строк,
в первой строке находится число N – количество записей о студентах.
В следующих N строках находятся данные на студентов.
После считывания файла, программа выводит список всех
студентов, а затем студентов, претендующих на повышенную стипендию.

Входные данные содержатся в файле students.txt (кодировка UTF-8).
В качестве разделителя между полями используется символ «;». 

Примерное содержимое файла students.txt:
11
Мухин М.В.;КС-20;3 4 5 4 3
Овечкина Ж.В.;П-19;5 5 3 4 5
Петров П.С.;ЗИ-18;4 4 5 5 4
Ларионов Б.А.;КС-18;4 5 5 5 5
Рогов Е.В.;ЗТ-17;3 3 3 3 3
Смирнова М.Э.;П-20;5 5 4 4 5
Громова Н.М.;ЗИ-17;4 4 3 5 4
Гущина М.Е.;СП-16;5 5 4 4 4
Мельникова Л.В.;КС-18;3 3 4 4 5
Федотов В.Ф.;ЗИ-17;4 4 4 4 4
Тимофеев А.Р.;ЗТ-19;4 3 5 4 3
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StructuresAndFileIO
{
    struct Student
    {
        public string fio;
        public string groupNumber;
        private int[] ratings;

        public Student(string f, string g, string r)
        {
            fio = f;
            groupNumber = g;
            string[] t = r.Split();
            ratings = new int[5];
            for (int i = 0; i < t.Length; i++)
                ratings[i] = int.Parse(t[i]);
        }

        public double GetAvg ()
        {
            double a = 0;
            for (int i = 0; i < ratings.Length; i++)
                a += ratings[i];
            return a/5;
        }

        public bool IsExcellent ()
        {
            bool e = true;
            for (int i = 0; i < ratings.Length; i++)
                if (ratings[i] < 4)
                    e = false;
            return e;
        }

        public void ShowInfo()
        {
            Console.WriteLine("{0, 18}, группа {1,6}, средний балл = {2}", fio, groupNumber, GetAvg());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student[] st;
            using (var sr = new StreamReader("students.txt", Encoding.UTF8))
            {
                int count = int.Parse(sr.ReadLine());
                st = new Student[count];
                for (int i = 0; i < count; i++)
                {
                    string [] s = sr.ReadLine().Split(';');
                    st[i] = new Student(s[0], s[1], s[2]);
                }
                sr.Close();
            }
            for (int i = 0; i<st.Length; i++)
            {
                Console.Write("{0,3}. ",i+1);
                st[i].ShowInfo();
            }
            Console.WriteLine("\nСписок студентов на повышенную стипендию:");
            int c = 1;
            for (int i = 0; i < st.Length; i++)
            {
                if (st[i].IsExcellent())
                {
                    Console.Write("{0,3}. ", c);
                    st[i].ShowInfo();
                    c++;
                }
            }
            Console.ReadLine();
        }
    }
}