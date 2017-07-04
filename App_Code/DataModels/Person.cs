namespace DataModels
{
    /// <summary>
    /// Класс Person - хранит основные данные о Person
    /// </summary>
    public class Person
    {
        public string _name;
        public string _phone;
        public int _score;

        public Person(string name, string phone, int score)
        {
            this._name = name;
            this._phone = phone;
            this._score = score;
        }
    }
}
