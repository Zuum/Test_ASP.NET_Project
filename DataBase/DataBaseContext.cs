using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataBase
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() : base("BankingSystem")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<DataModels.Person> People { get; set; }
        public DbSet<DataModels.PersonCommunication> PersonCommunications { get; set; }
        public DbSet<DataModels.PersonOperation> PersonOperations { get; set; }
        public DbSet<DataModels.PhoneType> PhoneTypes { get; set; }
    }
}
