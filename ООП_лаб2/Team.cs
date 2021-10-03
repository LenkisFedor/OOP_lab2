
namespace ООП_лаб2
{
    class Team : INameAndCopy
    {
        #region Поля
        protected string _orgName;

        protected int _regID;
        #endregion

        #region Конструкторы
        public Team(string orgName, int regID)
        {
            _orgName = orgName;
            _regID = regID;
        }

        public Team() : this("Неизвестно", 000) { }
        #endregion

        #region Свойства
        public int RegID
        {
            get { return _regID; }
            set
            {
                if (value <= 0) throw new Exception("Некорректный регистрационный номер");
                _regID = value;
            }
        }

        public string OrgName
        {
            get { return _orgName; }
            set { _orgName = value; }
        }

        public string Name { get => OrgName; set => OrgName = value; }
        #endregion

        #region Методы
        public override string ToString()
        {
            return string.Format("Название организации - " + OrgName.ToString() + "\nРегистрационный номер - " + RegID.ToString());
        }

        public static bool operator ==(Team t1, Team t2)
        {
            if (t1.OrgName == t2.OrgName && t1.RegID == t2.RegID) return true;

            else return false;
        }

        public static bool operator !=(Team t1, Team t2)
        {
            if (t1.OrgName != t2.OrgName && t1.RegID != t2.RegID) return true;

            else return false;
        }

        public override bool Equals(object? obj)
        {
            return obj is Team team &&
                   RegID == team.RegID &&
                   OrgName == team.OrgName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(RegID, OrgName);
        }

        public virtual object DeepCopy()
        {
            Team newteam = new(OrgName + "(Копия)", RegID);
            return newteam;
        }
        #endregion

    }
}
