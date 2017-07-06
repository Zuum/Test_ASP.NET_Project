using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace DataBase.Migrations.DataSets
{
    public static class PhoneTypeData
    {
        public static void AddData(DataBase.DataBaseContext context)
        {
            DataModels.PhoneType[] initialData = {
            new DataModels.PhoneType { phoneType = "Мобильный" },
            new DataModels.PhoneType { phoneType = "Рабочий" },
            new DataModels.PhoneType { phoneType = "Домашний" }
            };

            context.PhoneTypes.AddOrUpdate(initialData);
            context.SaveChanges();
        }
    }
}
