using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataBase;
using System.Xml.Serialization;

namespace EntryTest.DataHolders
{
    [Serializable]
    public class PersonOperationHolder : PersonHolder
    {
        public string city { get; set; }
        public string account { get; set; }
        public DataBase.DataModels.Enums.OperationTypes operationType { get; set; }
        public double amount { get; set; }
        public double amountEUR { get
            {
                /*try
                {
                    return amount * ratios["EUR"];
                }
                catch(Exception e)
                {*/
                    return amount * 1 / 65;
                //}
            } }
        public DateTime date { get; set; }
        [XmlIgnore]
        public Dictionary<string, double> ratios { get; set; }

        // Reflection needed to set amount by currencyCode without switch
        //{
        //    get { return this.GetType().GetProperty(propertyName).GetValue(this, null); }
        //    set { this.GetType().GetProperty(propertyName).SetValue(this, value, null); }
        //}

        //Not used. For task purpose only.
        //public void convertMoney(string currencyCode, double ratio)
        //{
        //    try
        //    {
        //        this["amount" + currencyCode] = this.amount * ratio;
        //    }
        //    catch(Exception e)
        //    {
        //        Console.WriteLine("Tried to convert to unsupported currency");
        //        Console.WriteLine(e);
        //    }
        //}
    }
}