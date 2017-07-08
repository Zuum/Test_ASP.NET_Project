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
    public class PersonOperationsController : ApiController
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: api/PersonOperations
        public IQueryable<PersonOperation> GetPersonOperations()
        {
            return db.PersonOperations;
        }



        // GET: api/PersonOperations/5
        [ResponseType(typeof(PersonOperation))]
        public IHttpActionResult GetPersonOperation(int id)
        {
            PersonOperation personOperation = db.PersonOperations.Find(id);
            if (personOperation == null)
            {
                return NotFound();
            }

            return Ok(personOperation);
        }

        // PUT: api/PersonOperations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersonOperation(int id, PersonOperation personOperation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personOperation.id)
            {
                return BadRequest();
            }

            db.Entry(personOperation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonOperationExists(id))
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

        // POST: api/PersonOperations
        [ResponseType(typeof(PersonOperation))]
        public IHttpActionResult PostPersonOperation(PersonOperation personOperation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PersonOperations.Add(personOperation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = personOperation.id }, personOperation);
        }

        // DELETE: api/PersonOperations/5
        [ResponseType(typeof(PersonOperation))]
        public IHttpActionResult DeletePersonOperation(int id)
        {
            PersonOperation personOperation = db.PersonOperations.Find(id);
            if (personOperation == null)
            {
                return NotFound();
            }
            
            db.PersonOperations.Remove(personOperation);
            db.SaveChanges();

            return Ok(personOperation);
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