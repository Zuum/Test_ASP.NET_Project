using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using DataBase.Migrations;

namespace DataBase.Migrations.DataSets
{
    public static class PersonData
    {
        public static void AddData(DataBase.DataBaseContext context)
        {
            DataModels.Person[] initialData = {
            new DataModels.Person { name = "Иванов Петр", city = "Москва", age = 25, score = 100 },
            new DataModels.Person { name = "Никифоров Георгий", city = "Москва", age = 30, score = 60 },
            new DataModels.Person { name = "Примаков Максим", city = "Пермь", age = 20, score = 70 }
            };

            context.People.AddOrUpdate(initialData);
            context.SaveChanges();
        }
    }
}
