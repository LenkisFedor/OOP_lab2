using System;

namespace ООП_лаб2
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            #region Пункт 1
            Team team1 = new("Эпол", 228);
            Team team2 = new("Эпол", 228);
            Console.WriteLine(team1 == team2);
            Console.WriteLine(Object.ReferenceEquals(team1, team2));
            Console.WriteLine($"Хэш-код первого объекта = { team1.GetHashCode()}\nХэш-код второго объекта = {team2.GetHashCode()}");
            #endregion

            #region Пункт 2
            try
            {
                team1.RegID = 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникло иисключение - {ex.Message}");
            }
            #endregion

            #region Пункт 3
            Person p1 = new("Фёдор", "Ленкис", new DateTime(2002, 03, 11));
            Person p2 = new("Александр", "Александров", new DateTime(2000, 11, 11));

            ResearchTeam researchTeam1 = new("Как копирайтить", "Копирайтилка", 1103, ResearchTeam.TimeFrame.Year);
            researchTeam1.AddMembers(p1, p2);

            Paper paper1 = new("Библия c#", p2, new DateTime(1999, 01, 02));
            researchTeam1.AddPapers(new Paper("Руководство по копирайтингу",p1, new DateTime(2021,09, 02)), paper1);

            researchTeam1.ToString();
            Console.WriteLine();
            #endregion

            #region Пункт 4
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Вывод свойства типа <<Team>> ");
            Console.WriteLine("--------------------------------------------------------");
            Console.ResetColor();
            Console.WriteLine(researchTeam1.Team);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("--------------------------------------------------------");
            Console.ResetColor();
            #endregion

            #region Пункт 5
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Создание копии объекта <<ResearchTeam>>\n");
            Console.ResetColor();

            ResearchTeam researchTeam3 = (ResearchTeam)researchTeam1.DeepCopy();

            researchTeam1 = new("Как сдать все лабы очень быстро чтобы тебя не бросила девушка??", "АО Жизненная ситуация", 0101, ResearchTeam.TimeFrame.Long);
            researchTeam1.AddMembers(new Person("Ангелина", "Алексеева", new DateTime(2002, 06, 12)));
            researchTeam1.AddPapers(new Paper("Хочу спать", new Person("Ангелина", "Алексеева", new DateTime(2002, 06, 12)), new DateTime(2021, 11, 11)));
            researchTeam1.AddMembers(p1);
            researchTeam1.AddPapers(new Paper("Хочу есть", new Person("Ангелина", "Алексеева", new DateTime(2002, 06, 12)), new DateTime(2021, 09, 03)));

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Копия");
            Console.ResetColor();
            researchTeam3.ToString();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Оригинал");
            Console.ResetColor();
            researchTeam1.ToString();


            #endregion

            #region Пункт 6

            Console.ForegroundColor = ConsoleColor.Green;   
            Console.WriteLine($"\n\nУчастники проекта <<{researchTeam1.Research_name}>> которые не имеют публикаций: \n");
            Console.ResetColor();
            foreach (Person pers in researchTeam1.Enumerator1()) 
            {
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine(pers);
            }
            Console.WriteLine("--------------------------------------------------------");
            #endregion

            #region Пункт 7
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n\n Публикации исследования <<{researchTeam1.Research_name}>> за последние 30 лет: \n");
            Console.ResetColor();

            foreach (Paper paper in researchTeam1.LastPapers(30))
            {
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine(paper);
            }
            Console.WriteLine("--------------------------------------------------------");

            #endregion

            #region Доп.8

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n\nУчастники проекта <<{researchTeam1.Research_name}>> которые имеют публикаций: \n");
            Console.ResetColor();
            foreach (Person pers in researchTeam1.Enumerator2())
            {
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine(pers);
            }
            Console.WriteLine("--------------------------------------------------------");

            #endregion

            #region Доп.9
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n\nУчастники проекта <<{researchTeam1.Research_name}>> которые имеют больше 1 публикаций: \n");
            Console.ResetColor();
            foreach (Person pers in researchTeam1.Enumerator3())
            {
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine(pers);
            }
            Console.WriteLine("--------------------------------------------------------");
            #endregion
        }

    }
}
