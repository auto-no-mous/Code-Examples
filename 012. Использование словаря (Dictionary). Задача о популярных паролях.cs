//Дан файл  с логинами и паролями. Найдите топ10 самых популярных паролей.
//ссылка на файл с логинами и паролями:
//https://yadi.sk/i/6ywJqzm93HGmy9

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PopularPasswords
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> passDict = new Dictionary<string, int>();
            //Ниже костыль, чтобы комплилятор не ругался. Настоящее присваивание в блоке try
            string[] lines = new string[1];
            try
            {
                    var sr = new StreamReader("pwd.txt", Encoding.UTF8);
                    string r = sr.ReadToEnd();
                    lines = r.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
                    sr.Close();

            }
            catch (Exception e)
            {
                    Console.WriteLine(e.Message);
                    return;
            }
            foreach (string s in lines)
            {
                string password = s.Split(';')[1];
                if (passDict.ContainsKey(password))
                {
                    passDict[password]++;
                }
                else
                {
                    passDict.Add(password, 1);
                }
            }
            int count = 1;
            foreach (KeyValuePair<string, int> key in passDict.OrderByDescending(key =>key.Value))
            {
                ShowPassword(count, key.Key, key.Value);
                count++;
                if (count >= 11)
                    break;
            }
            Console.ReadLine();
        }
        //выводим номер пароля, пароль, и сколько раз он встретился
        static void ShowPassword(int pos, string pass, int value)
        {
            Console.Write("{0, 2}. Password: \"", pos);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("{0}", pass);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\" met ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(value);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" times.");
        }
    }
}