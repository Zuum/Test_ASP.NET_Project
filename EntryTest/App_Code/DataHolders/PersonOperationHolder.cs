using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataBase;

namespace EntryTest.DataHolders
{
    public class PersonOperationHolder : PersonHolder
    {
        public string city { get; set; }
        public string account { get; set; }
        public DataBase.DataModels.Enums.OperationTypes operationType { get; set; }
        public double amount { get; set; }
        public double amountEUR { get; set; } //TODO: dictionary
        public DateTime date { get; set; }

        // Reflection needed to set amount by currencyCode without switch
        public object this[string propertyName]
        {
            get { return this.GetType().GetProperty(propertyName).GetValue(this, null); }
            set { this.GetType().GetProperty(propertyName).SetValue(this, value, null); }
        }

        public void convertMoney(string currencyCode, double ratio)
        {
            try
            {
                this["amount" + currencyCode] = this.amount * ratio;
            }
            catch(Exception e)
            {
                Console.WriteLine("Tried to convert to unsupported currency");
                Console.WriteLine(e);
            }
        }
    }
}