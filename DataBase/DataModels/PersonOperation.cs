using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataBase.DataModels
{
    public class PersonOperation
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public string account { get; set; }
        public Enums.OperationTypes operationType { get; set; }
        public double amount { get; set; }

        public Person Person { get; set; }
    }
}
