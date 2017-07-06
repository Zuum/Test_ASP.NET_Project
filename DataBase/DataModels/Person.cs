using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataBase.DataModels
{
    public class Person
    {
        public int id { get; set; }
        public string name { get; set; }
        public string city { get; set; }
        public int age { get; set; }
        public int score { get; set; }

        public virtual List<PersonCommunication> PersonCommunications { get; set; }
        public virtual List<PersonOperation> PersonOperations { get; set; }
    }
}
