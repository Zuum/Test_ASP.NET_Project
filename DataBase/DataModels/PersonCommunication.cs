using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataBase.DataModels
{
    public class PersonCommunication
    {
        public int id { get; set; }
        public string phone { get; set; }
        public bool isUsed { get; set; }

        public Person Person { get; set; }
        public PhoneType PhoneType { get; set; }
    }
}
