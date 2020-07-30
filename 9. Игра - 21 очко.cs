using System;

namespace game21
{
    class Program
    {
        static Random rnd = new Random();
        static int[] discharge = new int[36];
        enum cards
        {
            Валет = 2,
            Дама = 3,
            Король = 4,
            Шесть = 6,
            Семь = 7,
            Восемь = 8,
            Девять = 9,
            Десять = 10,
            Туз = 11
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Сыграем в 21 очко? [Y/N]: ");
                string choice = Console.ReadLine();
                if (choice.ToLower() == "y")
                {
                    int playerPoints = 0;
                    int computerPoints = 0;
                    bool computerPlay = true;
                    bool playerPlay = true;
                    
                    while (playerPlay)
                    {
                        char input = GetChoice(playerPoints);
                        switch (input)
                        {
                            case '1':
                                int newCard = DrawCard(discharge);
                                playerPoints += newCard;
                                ShowNewCard(newCard, playerPoints);
                                
                                if (playerPoints>21)
                                {
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                    Console.WriteLine("ВЫ ПРОИГРАЛИ...");
                                    Console.Beep(500, 2);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    playerPlay = false;
                                }
                                else if (playerPoints==21)
                                {
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("ВЫ ВЫИГРАЛИ, НАБРАВ 21 ОЧКО!!!");
                                    Console.Beep(5000, 1);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    playerPlay = false;
                                }
                                else if (computerPlay)
                                {
                                    computerPlay = ComputerDraw(ref computerPoints, playerPoints);
                                    if (computerPoints == 21)
                                    {
                                        Console.WriteLine();
                                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                                        Console.WriteLine("Компьютер выигрывает, набрав 21 очко...");
                                        Console.Beep(500, 2);
                                        Console.ForegroundColor = ConsoleColor.White;
                                        playerPlay = false;
                                        break;
                                    }
                                }
                                break;

                            case '2':
                                playerPlay = false;
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("Вы решили остановиться, набрав ");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write(playerPoints);
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine(" очков.");
                                Console.ForegroundColor = ConsoleColor.White;
                                while (computerPlay)
                                {
                                    computerPlay = ComputerDraw(ref computerPoints, playerPoints, playerPlay);
                                }
                                if (computerPoints==21)
                                {
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    Console.WriteLine("Компьютер выигрывает, набрав 21 очко...");
                                    Console.Beep(500, 2);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    break;
                                }
                                else if (computerPoints>21)
                                {
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.WriteLine("Компьютер проигрывает, набрав {0}!", computerPoints);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("ВЫ ВЫИГРАЛИ!");
                                    Console.Beep(5000, 1);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    break;
                                }
                                else if (computerPoints>playerPoints)
                                {
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    Console.WriteLine("Компьютер выигрывает, набрав {0} очко...", computerPoints);
                                    Console.Beep(500, 2);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    break;
                                }
                                else if (playerPoints>computerPoints)
                                {
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("ВЫ ВЫИГРАЛИ, НАБРАВ {0}!", playerPoints);
                                    Console.Beep(5000, 1);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("НИЧЬЯ :)");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    break;
                                }
                        }
                    }
                    discharge = new int[36];
                    Console.WriteLine();
                }
                else if (choice.ToLower() == "n")
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Некорретный ввод, попробуйте еще раз.");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("<<<<<<<<<<<  СПАСИБО ЗА ИГРУ!   >>>>>>>>>>>>");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static char GetChoice (int p)
        {
            Console.WriteLine();
            Console.Write("У Вас сейчас ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(p);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" очков. [1] - тянуть карту, [2] - остановиться: ");
            string input = Console.ReadLine();
            if (input == "1")
                return '1';
            else if (input == "2")
                return '2';
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Некорретный ввод, попробуйте еще раз.");
                Console.ForegroundColor = ConsoleColor.White;
                return GetChoice(p);
            }
        }

        static int DrawCard(int [] d)
        {
            int pos = Array.IndexOf(d, 0);
            int newCard = 0;

            while (newCard==0 ||newCard==5)
            {
                newCard = rnd.Next(2, 12);
            }

            int count = 0;
            for (int i = 0; i < pos; i++)
            {
                if (d[i] == newCard)
                    count++;
            }
            if (count < 4)
            {
                d[pos] = newCard;
                return newCard;
            }
            else return DrawCard(d);
        }

        static void ShowNewCard (int c, int p)
        {
            Console.WriteLine();
            Console.Write("Ваша карта - ");
            cards card = (cards)c;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(card);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(", стоимостью = ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(c);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Всего очков у Вас - ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(p);
        }

        static bool ComputerDraw(ref int cp, int p, bool playerPlay = true)
        {
            if ((cp>15) && (p<cp) || !playerPlay&&(p<cp))
            {
                Console.WriteLine();
                Console.Write("Компьютер решает ");
                Console.ForegroundColor = ConsoleColor.Blue; 
                Console.Write("остановиться");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(", набрав  ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(cp);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("очков.");
                return false;
            }
            else
            {
                int newCard = DrawCard(discharge);
                Console.WriteLine();
                Console.Write("Компьютер вытягивает ");
                cards card = (cards)newCard;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(card);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(", стоимостью = ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(newCard);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Всего очков у компьютера -  ");
                Console.ForegroundColor = ConsoleColor.Blue;
                cp += newCard;
                Console.WriteLine(cp);
                Console.ForegroundColor = ConsoleColor.White;
                if (cp > 21)
                    return false;
                else return true;
            }

        }
    }
}