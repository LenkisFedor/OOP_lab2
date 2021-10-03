using System;
using System.Collections.Generic;
using System.Text;

namespace ООП_лаб2
{
    class Person
    {
        #region properies
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Date { get; set; }

        public int YearBirth
        {
            get => Date.Year;
            set => Date = Date.AddYears(YearBirth - Date.Year);
        }
        #endregion

        #region constructors
        public Person(string name, string surname, DateTime date)
        {
            Name = name;
            Date = date;
            Surname = surname;
        }

        public Person() : this("Неизвестно", "Неизвестно", new DateTime()) { }

        #endregion

        #region Methods
        public virtual string ToShortString(string fullname) => $"Имя :{Name} Фамилия :{Surname}";

        public override string ToString()
        {
            return string.Format("  Имя :" + Name.ToString() + "\n  Фамилия :" + Surname.ToString() + "\n  Дата рождения :" + Date.ToString("D"));
        }

        public override bool Equals(object? obj)
        {
            return obj is Person person &&
                   Name == person.Name &&
                   Surname == person.Surname &&
                   Date == person.Date;
        }

        public static bool operator ==(Person p1, Person p2)
        {
            if (p1.Date == p2.Date && p1.Surname == p2.Surname && p1.Name == p2.Name)
                return true;
            else
                return false;

        }

        public static bool operator !=(Person p1, Person p2)
        {
            if (p1.Date != p2.Date && p1.Surname != p2.Surname && p1.Name != p2.Name)
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Surname, Date);
        }
        #endregion

    }
}
