using System;


namespace FunWithEnums
{
    // объявление перечисления
    enum EmpType
    {
        Manager,       // = 0
        Grunt,         // = 1
        Contractor,    // = 2
        VicePresident  // = 3
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** Fun with Enums *****");
            //создаётся экземпляр перечисления
            EmpType emp = EmpType.Contractor;
            AskForBonus(emp);

            // выводит "emp is a Contractor".
            Console.WriteLine("emp is a {0}.", emp.ToString());

            // выводит "Contractor = 100".
            Console.WriteLine("{0} = {1}", emp.ToString(), (byte)emp);

            EmpType e2 = EmpType.Contractor;

            // Эти перечисления объявлены в пространстве имен System
            DayOfWeek day = DayOfWeek.Monday;
            ConsoleColor cc = ConsoleColor.Gray;
            EvaluateEnum(e2);
            EvaluateEnum(day);
            EvaluateEnum(cc);

            Console.ReadLine();
        }

        #region Enum as parameter
        // передача перечислений в качестве аргументов
        static void AskForBonus(EmpType e)
        {
            switch (e)
            {
                case EmpType.Manager:
                    Console.WriteLine("How about stock options instead?");
                                     //He желаете ли взамен фондовые опционы?
                    break;
                case EmpType.Grunt:
                    Console.WriteLine("You have got to be kidding...");
                                    // Вы должно быть шутите. . .
                    break;
                case EmpType.Contractor:
                    Console.WriteLine("You already get enough cash...");
                                    // Вы уже получаете вполне достаточно...
                    break;
                case EmpType.VicePresident:
                    Console.WriteLine("VERY GOOD, Sir!");
                                    // Очень хорошо, сэр!
                    break;
            }
        }
        #endregion

        #region Analyse Enum
        // этот метод выводит подробности о переданном в аргументе перечислении
        static void EvaluateEnum(System.Enum e)
        {
            Console.WriteLine("=> Information about {0}", e.GetType().Name);

            Console.WriteLine("Underlying storage type: {0}",
              Enum.GetUnderlyingType(e.GetType()));
            // Получить все пары "имя-значение" для входного параметра.
            Array enumData = Enum.GetValues(e.GetType());
            Console.WriteLine("This enum has {0} members.", enumData.Length);
            // Вывести строковое имя и ассоциированное значение,
            // используя флаг формата D
            for (int i = 0; i < enumData.Length; i++)
            {
                Console.WriteLine("Name: {0}, Value: {0:D}",
                  enumData.GetValue(i));
            }
            Console.WriteLine();
        }
        #endregion
    }
}
