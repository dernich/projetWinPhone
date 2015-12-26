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
using BDWebApp.Models;

namespace BDWebApp.Controllers
{
    public class soumissionParticulieresController : ApiController
    {
        private DBIG3B9Entities db = new DBIG3B9Entities();

        // GET: api/soumissionParticulieres
        public IQueryable<soumissionParticuliere> GetsoumissionParticuliere()
        {
            return db.soumissionParticuliere;
        }

        // GET: api/soumissionParticulieres/5
        [ResponseType(typeof(soumissionParticuliere))]
        public IHttpActionResult GetsoumissionParticuliere(int id)
        {
            soumissionParticuliere soumissionParticuliere = db.soumissionParticuliere.Find(id);
            if (soumissionParticuliere == null)
            {
                return NotFound();
            }

            return Ok(soumissionParticuliere);
        }

        // PUT: api/soumissionParticulieres/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutsoumissionParticuliere(int id, soumissionParticuliere soumissionParticuliere)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != soumissionParticuliere.idSoumPart)
            {
                return BadRequest();
            }

            db.Entry(soumissionParticuliere).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!soumissionParticuliereExists(id))
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

        // POST: api/soumissionParticulieres
        [ResponseType(typeof(soumissionParticuliere))]
        public IHttpActionResult PostsoumissionParticuliere(soumissionParticuliere soumissionParticuliere)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.soumissionParticuliere.Add(soumissionParticuliere);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = soumissionParticuliere.idSoumPart }, soumissionParticuliere);
        }

        // DELETE: api/soumissionParticulieres/5
        [ResponseType(typeof(soumissionParticuliere))]
        public IHttpActionResult DeletesoumissionParticuliere(int id)
        {
            soumissionParticuliere soumissionParticuliere = db.soumissionParticuliere.Find(id);
            if (soumissionParticuliere == null)
            {
                return NotFound();
            }

            db.soumissionParticuliere.Remove(soumissionParticuliere);
            db.SaveChanges();

            return Ok(soumissionParticuliere);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool soumissionParticuliereExists(int id)
        {
            return db.soumissionParticuliere.Count(e => e.idSoumPart == id) > 0;
        }
    }
}