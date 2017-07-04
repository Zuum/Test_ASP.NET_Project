using System;

namespace DataModels
{
    /// <summary>
    /// Сводное описание для PersonOperation
    /// </summary>
    public class PersonOperation : Person
    {
        public string _city;
        public string _account;
        public PersonActions _personActions;
        public double _sum;
        public DateTime _date;

        public PersonOperation(string name, string phone, int score, string city, 
            string account, PersonActions action, double sum, DateTime date) : base(name, phone, score)
        {
            this._city = city;
            this._account = account;
            this._personActions = action;
            this._sum = sum;
            this._date = date;
        }
    }
}
