using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace EntryTest.DataHolders
{
    public class HoldersContainer
    {
        [XmlArray("Operation"), XmlArrayItem(typeof(PersonOperationHolder), ElementName = "PersonOperation")]
        public List<PersonOperationHolder> content { get; set; }
    }
}