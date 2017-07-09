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
    public class PersonCommunicationsController : ApiController
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: api/PersonCommunications
        public IQueryable<PersonCommunication> GetPersonCommunications()
        {
            return db.PersonCommunications.Include(pc => pc.Person).Include(pc => pc.PhoneType);
        }

        // GET: api/PersonCommunications/5
        [ResponseType(typeof(PersonCommunication))]
        public IHttpActionResult GetPersonCommunication(int id)
        {
            PersonCommunication personCommunication = db.PersonCommunications.Find(id);
            if (personCommunication == null)
            {
                return NotFound();
            }

            return Ok(personCommunication);
        }

        // PUT: api/PersonCommunications/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersonCommunication(int id, PersonCommunication personCommunication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personCommunication.id)
            {
                return BadRequest();
            }

            db.Entry(personCommunication).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonCommunicationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PersonCommunications
        [ResponseType(typeof(PersonCommunication))]
        public IHttpActionResult PostPersonCommunication(PersonCommunication personCommunication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PersonCommunications.Add(personCommunication);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = personCommunication.id }, personCommunication);
        }

        // DELETE: api/PersonCommunications/5
        [ResponseType(typeof(PersonCommunication))]
        public IHttpActionResult DeletePersonCommunication(int id)
        {
            PersonCommunication personCommunication = db.PersonCommunications.Find(id);
            if (personCommunication == null)
            {
                return NotFound();
            }

            db.PersonCommunications.Remove(personCommunication);
            db.SaveChanges();

            return Ok(personCommunication);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonCommunicationExists(int id)
        {
            return db.PersonCommunications.Count(e => e.id == id) > 0;
        }
    }
}