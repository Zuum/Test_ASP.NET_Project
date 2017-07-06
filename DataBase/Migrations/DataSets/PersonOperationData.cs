using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace DataBase.Migrations.DataSets
{
    public static class PersonOperationData
    {
        public static void AddData(DataBase.DataBaseContext context)
        {
            DataModels.PersonOperation[] initialData = {
                new DataModels.PersonOperation {
                    date = new DateTime(2015, 7, 12),
                    account = "124537899454",
                    operationType = DataModels.Enums.OperationTypes.WriteOff,
                    amount = 3000,
                    Person = context.People.FirstOrDefault(x => x.name == "Примаков Максим")
                },
                new DataModels.PersonOperation {
                    date = new DateTime(2015, 6, 20),
                    account = "498753184684",
                    operationType = DataModels.Enums.OperationTypes.WriteOn,
                    amount = 2500,
                    Person = context.People.FirstOrDefault(x => x.name == "Иванов Петр")
                },
                new DataModels.PersonOperation {
                    date = new DateTime(2014, 2, 3),
                    account = "687964419884",
                    operationType = DataModels.Enums.OperationTypes.WriteOn,
                    amount = 9000,
                    Person = context.People.FirstOrDefault(x => x.name == "Никифоров Георгий")
                }
            };

            context.PersonOperations.AddOrUpdate(initialData);
            context.SaveChanges();
        }
    }
}
