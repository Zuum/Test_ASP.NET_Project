namespace DataBase.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataBase.DataBaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataBase.DataBaseContext context)
        {
            DataSets.PersonData.AddData(context);
            DataSets.PhoneTypeData.AddData(context);
            DataSets.PersonCommunicationData.AddData(context);
            DataSets.PersonOperationData.AddData(context);
        }
    }
}
