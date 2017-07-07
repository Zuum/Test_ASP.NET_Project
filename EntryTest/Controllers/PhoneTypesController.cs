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
    public class PhoneTypesController : ApiController
    {
        private DataBaseContext db = new DataBaseContext();

        // GET: api/PhoneTypes
        public IQueryable<PhoneType> GetPhoneTypes()
        {
            return db.PhoneTypes;
        }

        // GET: api/PhoneTypes/5
        [ResponseType(typeof(PhoneType))]
        public IHttpActionResult GetPhoneType(int id)
        {
            PhoneType phoneType = db.PhoneTypes.Find(id);
            if (phoneType == null)
            {
                return NotFound();
            }

            return Ok(phoneType);
        }

        // PUT: api/PhoneTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPhoneType(int id, PhoneType phoneType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != phoneType.id)
            {
                return BadRequest();
            }

            db.Entry(phoneType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhoneTypeExists(id))
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

        // POST: api/PhoneTypes
        [ResponseType(typeof(PhoneType))]
        public IHttpActionResult PostPhoneType(PhoneType phoneType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PhoneTypes.Add(phoneType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = phoneType.id }, phoneType);
        }

        // DELETE: api/PhoneTypes/5
        [ResponseType(typeof(PhoneType))]
        public IHttpActionResult DeletePhoneType(int id)
        {
            PhoneType phoneType = db.PhoneTypes.Find(id);
            if (phoneType == null)
            {
                return NotFound();
            }

            db.PhoneTypes.Remove(phoneType);
            db.SaveChanges();

            return Ok(phoneType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PhoneTypeExists(int id)
        {
            return db.PhoneTypes.Count(e => e.id == id) > 0;
        }
    }
}