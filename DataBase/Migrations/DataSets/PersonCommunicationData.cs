using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace DataBase.Migrations.DataSets
{
    public static class PersonCommunicationData
    {
        public static void AddData(DataBase.DataBaseContext context)
        {
            DataModels.PersonCommunication[] initialData = {
                new DataModels.PersonCommunication {
                    phone = "79161234586",
                    isUsed = true,
                    PhoneType = context.PhoneTypes.FirstOrDefault(x => x.phoneType == "Мобильный"),
                    Person = context.People.FirstOrDefault(x => x.name == "Иванов Петр")
                },
                new DataModels.PersonCommunication {
                    phone = "79163214569",
                    isUsed = true,
                    PhoneType = context.PhoneTypes.FirstOrDefault(x => x.phoneType == "Рабочий"),
                    Person = context.People.FirstOrDefault(x => x.name == "Иванов Петр")
                },
                new DataModels.PersonCommunication {
                    phone = "",
                    isUsed = false,
                    PhoneType = context.PhoneTypes.FirstOrDefault(x => x.phoneType == "Мобильный"),
                    Person = context.People.FirstOrDefault(x => x.name == "Никифоров Георгий")
                },
            };

            context.PersonCommunications.AddOrUpdate(initialData);
            context.SaveChanges();
        }
    }
}
