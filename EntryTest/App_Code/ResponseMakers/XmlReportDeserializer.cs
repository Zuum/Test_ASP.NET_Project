using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.IO;

namespace EntryTest.App_Code.ResponseMakers
{
    public static class XmlReportDeserializer
    {
        public static List<int> DeserializeReport(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(IEnumerable<Object>));
            serializer.Deserialize(File.OpenRead(filePath));

            return new List<int>();
      
        }
    }
}