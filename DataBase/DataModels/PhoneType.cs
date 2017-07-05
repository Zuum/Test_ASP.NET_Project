using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataBase.DataModels
{
    public class PhoneType
    {
        public int id { get; set; }
        public string phoneType { get; set; }

        public virtual List<PersonCommunication> PersonCommunications { get; set; }
    }
}
