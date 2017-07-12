using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DataBase;
using DataBase.DataModels;

namespace EntryTest.Controllers
{
    public class TaskController : ApiController
    {
        private DataBaseContext db = new DataBaseContext();

        [HttpGet]
        public void GetTask()
        {

            ResponseMakers.FileSender.PostMultipleFiles("http://localhost:56880/xmlreport/", new string[] { ResponseMakers.XmlReportSerializer.SerializeReport(new DataHolders.HoldersContainer
            {
                content = db.Database.SqlQuery<DataHolders.PersonOperationHolder>(
                "" +
                "SELECT          \"P\".\"name\", \"PC\".\"phone\", \"P\".\"city\", \"P\".\"score\", \"PO\".\"account\", " +
                                 "\"PO\".\"operationType\", \"PO\".\"amount\", \"PO\".\"date\" " +
                "FROM            \"PersonOperations\" AS PO " +
                "INNER JOIN      \"People\" AS P ON \"PO\".\"Person_id\" = \"P\".\"id\" " +
                "INNER JOIN      \"PersonCommunications\" AS PC ON \"PC\".\"Person_id\" = \"P\".\"id\" " +
                "WHERE           \"PC\".\"phone\" IS NOT NULL " +
                "AND             \"PC\".\"isUsed\" = '1' " +
                "AND             \"PO\".\"date\" >= '20130701' " +
                "AND             \"P\".\"city\" IN('Москва', 'Санкт-Петербург') " +
                ""
                ).ToList()
            })
            });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonOperationExists(int id)
        {
            return db.PersonOperations.Count(e => e.id == id) > 0;
        }
    }
}