using System;
using System.Collections.Generic;
using System.Text;

namespace ООП_лаб2
{
    class Paper
    {
        #region Конструкторы
        public Paper(string name, Person person, DateTime date)
        {
           Name = name; //название публикации
           Person = person; //автор публикации
           Date = date; // дата публикации
        }

        public Paper() : this("Неизвестно", new Person(), new DateTime()) { }
                #endregion

        #region Методы
        public override string ToString()
        {
            return string.Format("  Название публикации - " + Name.ToString() + "\n\n  Автор - \n" + Person.ToString() + "\n\n  Дата публикации - " + Date.ToString("D"));
        }
        public override bool Equals(object? obj)
        {
            return obj is Paper paper &&
                   Name == paper.Name &&
                   EqualityComparer<Person>.Default.Equals(Person, paper.Person) &&
                   Date == paper.Date;
        }
        public static bool operator ==(Paper p1, Paper p2)
        {
            if (p1.Date == p2.Date && p1.Person == p2.Person && p1.Name == p2.Name) return true;

            else return false;
        }
        public static bool operator !=(Paper p1, Paper p2)
        {
            if (p1.Date != p2.Date && p1.Person != p2.Person && p1.Name != p2.Name) return true;

            else return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Person, Date);
        }

        public virtual object DeepCopy()
        {
            Paper paper = new (Name + "(Копия)", Person, Date);
            return paper;
        }

        #endregion

        #region Свойства
        public string Name { get; set; }
        public Person Person { get; set; }
        public DateTime Date { get; set; }
        #endregion
    }
}
