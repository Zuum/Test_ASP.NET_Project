using CsvHelper;
using EntryTest.DataHolders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace EntryTest.ResponseMakers
{
    public static class XmlReportSerializer
    {
        public static string SerializeReport(HoldersContainer data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(DataHolders.HoldersContainer));
            if(!Directory.Exists(Environment.CurrentDirectory + "/GeneratedReports"))
            {
                Directory.CreateDirectory(Environment.CurrentDirectory + "/GeneratedReports");
            }
            string filePath = Environment.CurrentDirectory + "/GeneratedReports/report" 
                            + (Int64)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalMilliseconds + ".xml";

            using (FileStream fs = new FileStream(@filePath, FileMode.Create))
            {
                serializer.Serialize(fs, data);
            }

            return filePath;
        }

        public static string DeserializeReport(string filePath)
        {
           
            if (!Directory.Exists(Environment.CurrentDirectory + "/CSVReports"))
            {
                Directory.CreateDirectory(Environment.CurrentDirectory + "/CSVReports");
            }
            string csvPath = Environment.CurrentDirectory + "/CSVReports/report"
                           + (Int64)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalMilliseconds + ".csv";
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(HoldersContainer));
                var data = (HoldersContainer)serializer.Deserialize(fs);
                var textWriter = new StreamWriter(csvPath, false, Encoding.UTF8);
                var csvSerializer = new CsvWriter(textWriter);
                csvSerializer.Configuration.AutoMap(typeof(PersonOperationHolder));
                csvSerializer.WriteHeader(typeof(PersonOperationHolder));
                data.content.ForEach(item => csvSerializer.WriteRecord(item));
                textWriter.Close();
            }

            return csvPath;
        }
    }
}