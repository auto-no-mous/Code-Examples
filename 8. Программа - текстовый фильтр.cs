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
            Console.WriteLine("Входные данные: \n");
            string s = Console.In.ReadToEnd();
            Console.WriteLine("\n");
            Console.WriteLine("Выходные данные: \n");

            Console.WriteLine(MainFilter(s));
            Console.ReadKey();
        }

        static string MainFilter (string s)
        {
            string[] words = s.Split(' ');
            words = Capitalize(words);
            words = RemoveRef(words);
            return String.Join(' ', words);
        }

        static string[] Capitalize (string[] words)
        {
            bool newSentence = true;
            for (int i = 0; i< words.Length; i++)
            {
                if (newSentence)
                {
                    words[i] = Char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
                    newSentence = false;
                }
                else
                {
                    words[i] = words[i].ToLower();
                }
                if (words[i].Contains(".")&&!IsReference(words[i]))
                    newSentence = true;
            }
            return words;
        }

        static bool IsReference (string s)
        {
            if (s.ToLower().Contains("http") && s.Contains("."))
                return true;
            else return false;
        }

        static string [] RemoveRef (string [] words)
        {
            for (int i = 0; i < words.Length; i++)
            {
                if (IsReference(words[i]))
                {
                    string[] deepSpit = words[i].Split('\r', '\n', '(', ')', ';');
                    for (int j = 0; j<deepSpit.Length; j++)
                    {
                        if (IsReference(deepSpit[j]))
                            words[i] = words[i].Replace(deepSpit[j], "[ссылка удалена]");
                    }
                }
            }
            return words;
        }
    }


}
