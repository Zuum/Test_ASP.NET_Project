using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace EntryTest.ResponseMakers
{
    public static class XmlReportSerializer
    {
        public static string SerializeReport(DataHolders.HoldersContainer data)
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

        public static List<T> DeserializeReport<T>(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(IEnumerable<Object>));
            serializer.Deserialize(File.OpenRead(filePath));

            return new List<T>();

        }
    }
}