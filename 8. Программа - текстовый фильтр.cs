/*Дана строка, состоящая из слов, разделенных пробелами, и знаками пунктуации. Сформировать новую строку со следующими свойствами:

а) все слова в нижнем регистре, кроме первой буквы первого слова предложения;
б) все ссылки в словах заменяются на "[ссылка удалена]";
в) все email заменяются на "[контакты запрещены]";
г) все слова длины 3 и более символов, содержащие только цифры, заменяются на символы *, соответствующей длинны.

Пример входных данных:

Доставка Контактных линз по Симферополю
https://optikacrystal.ru
У нас Вы можете заказать Контактные линзы, растворы и капли по доступным ценам. Тел. +7 (978) 273-8533. Все в наличии.
По вопросам оптовых закупок: optikakristal@yandex.ru

Пример выходных данных:

Доставка контактных линз по симферополю
[ссылка удалена]
У нас вы можете заказать контактные линзы, растворы и капли по доступным ценам. Тел. +7 (***) -****. Все в наличии.
По вопросам оптовых закупок: [контакты запрещены]

Примечание: при отладке программы, используйте сочетание Ctrl + Z, чтобы ввести символ EOF (конец файла). Таким образом удастся закончить ввод данных.
 */

using System;
using System.IO;
using System.Linq;
using System.Text;

namespace TextFilter
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите текст:");
            string s = Console.In.ReadToEnd();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(MainFilter(s));
            Console.ReadKey();
        }

        static string MainFilter(string s)
        {
            string[] words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            words = Capitalize(words);
            words = RemoveRefs(words);

            return String.Join(' ', words);
        }

        static string[] Capitalize(string[] words)
        {
            bool newSentence = true;
            for (int i = 0; i < words.Length; i++)
            {
                if (!newSentence)
                {
                    words[i] = words[i].ToLower();
                }
                else
                {
                    words[i] = words[i].ToLower();
                    words[i] = Char.ToUpper(words[i][0]) + words[i].Substring(1);
                    newSentence = false;
                }
                if (words[i].Contains('\n'))
                {
                    int pos = words[i].IndexOf('\n');
                    while (pos!=-1 && !Char.IsLetter(words[i][pos]) && pos<words[i].Length-1)
                        pos++;
                    if (pos!=-1 && pos<words[i].Length)
                    {
                        char [] ch = words[i].ToCharArray();
                        ch[pos] = Char.ToUpper(ch[pos]);
                        words[i] = new string(ch);
                    }
                }
                else if  (words[i].Contains(".") && !IsReference(words[i]))
                    newSentence = true;
            }
            return words;
        }

        static bool IsReference(string s)
        {
            if (s.ToLower().Contains("http") && s.Contains("."))
            {
                return true;
            }
            else
                return false;
        }

        static string[] RemoveRefs(string[] words)
        {
            for (int i = 0; i < words.Length; i++)
            {
                if (IsReference(words[i]))
                {
                    string[] deepSplit = words[i].Split(',', ';', '(', ')', '\r', '\n');
                    for (int j = 0; j < deepSplit.Length; j++)
                    {
                        if (deepSplit[j].ToLower().Contains("http"))
                        {
                            words[i] = words[i].Replace(deepSplit[j], "[ссылка удалена]");
                        }
                    }

                }
            }
            return words;
        }
    }


}
