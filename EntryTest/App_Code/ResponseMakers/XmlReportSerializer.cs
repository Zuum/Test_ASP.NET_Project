using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace EntryTest.App_Code.ResponseMakers
{
    public static class XmlReportSerializer
    {
        public static string SerializeReport(IEnumerable<Object> data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(IEnumerable<Object>));
            string filePath = "GeneratedReports/report" + (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds + ".xml";
            serializer.Serialize(File.Create(filePath), data);

            return filePath;
        }
    }
}