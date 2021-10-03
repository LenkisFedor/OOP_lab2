using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ООП_лаб2
{
    class ResearchTeam : Team, INameAndCopy
    {
        private ArrayList _listOfMembers = new();
        private System.Collections.ArrayList _listOfPapers = new();

        public enum TimeFrame { Year, TwoYaers, Long };

        #region Конструкторы
        public ResearchTeam(string research_name, string orgName, int regID, TimeFrame time) : base(orgName, regID)
        {

            Research_name = research_name; // название темы исследования
            Time = time;//продолжительность исследования
        }

        public ResearchTeam() : this("Неизвестно", "Неизвестно", 404, TimeFrame.Long) { }
        #endregion

        #region Свойства

        public string Research_name { get; set; } //Название темы исследования

        public TimeFrame Time { get; set; } // Продолжительность исследования 

        public System.Collections.ArrayList ListOfMembers { get => _listOfMembers; set => _listOfMembers = value; }

        public System.Collections.ArrayList ListOfPapers { get => _listOfPapers; set => _listOfPapers = value; }

        public Paper? Latest
        {
            get
            {
                if (ListOfPapers != null)
                {

                    var papers = from Paper paper in ListOfPapers select paper;

                    DateTime maxdate = papers.Max(x => x.Date);

                    var maxpapers = from Paper paper in ListOfPapers where paper.Date == maxdate.Date select paper;

                    return (Paper)maxpapers;
                }
                else return null;
            }
        }

        public Team Team
        {
            get
            {
                Team newteam = new (base.OrgName, base.RegID);
                return newteam;
            }
            set
            {
                OrgName = value.OrgName;
                RegID = value.RegID;
            }
        }

        #endregion

        #region Индексатор
        public bool this[TimeFrame TimeIndex]
        {
            get
            {
                if (Time == TimeIndex) return true;
                else return false;
            }
        }
        #endregion

        #region Итераторы
        
        public IEnumerable Enumerator1() 
        {
            foreach (Person person in ListOfMembers)
            {
                foreach (Paper paper in ListOfPapers)
                {
                    if (person != paper.Person) yield return person; else continue;
                }
            }
        }

        public IEnumerable LastPapers(int n)
        {
            foreach (Paper paper in ListOfPapers)
            {
                if (paper.Date.Year >= DateTime.Now.Year - n) yield return paper;
                else continue;
            }
        }

        public IEnumerable Enumerator2()
        {
            foreach (Person person in ListOfMembers)
            {
                foreach (Paper paper in ListOfPapers)
                {
                    if (person == paper.Person) yield return person;
                    else continue;
                }
            }
        }


        public IEnumerable Enumerator3()
        {

        }

        #endregion

        #region Методы

        public void AddPapers(params Paper[] papers)
        {
            ListOfPapers.AddRange(papers);
        }

        public void AddMembers(params Person[] persons)
        {
            ListOfMembers.AddRange(persons);
        }

        public override string ToString()
        {
            string Info = $"Тема исследования: {Research_name}\nНазвание организации: {Team.OrgName}\nРегистрационный номер: {Team.RegID}\nПродолжительность ииследования: {Time}\n";
            Console.WriteLine();
            Console.WriteLine(Info);

            if (ListOfPapers != null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Списпок публикаций : ");
                Console.ResetColor();
                foreach (Paper paper in ListOfPapers)
                {
                    Console.WriteLine("--------------------------------------------------------");
                    Console.WriteLine(paper.ToString());

                }
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine();
            }
            else return "Список публикаций пуст";

            if (ListOfMembers != null)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Списпок участников : ");
                Console.ResetColor();
                foreach (Person person in ListOfMembers)
                {
                    Console.WriteLine("--------------------------------------------------------");
                    Console.WriteLine(person.ToString());
                }
                Console.WriteLine("--------------------------------------------------------");
            }
            else return "Список участников пуст";

            return "\n";
        }

        public virtual string ToShortString()
        {
            string ShortInfo = $"Тема исследования: {Research_name}\nНазвание организации: {Team.OrgName}\nРегистрационный номер: {Team.RegID}\nПродолжительность ииследования: {Time}\n";
            Console.WriteLine(ShortInfo);
            return ShortInfo;
        }

        public override object DeepCopy()
        {
            ResearchTeam researchTeam = new(Research_name + "(Копия)", OrgName, RegID, Time);
            researchTeam.ListOfMembers = this.ListOfMembers;
            researchTeam.ListOfPapers = this.ListOfPapers;
            return researchTeam;
        }





        #endregion

    }
}
