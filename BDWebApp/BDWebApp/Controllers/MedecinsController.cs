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
    public class MedecinsController : ApiController
    {
        private DBIG3B9Entities db = new DBIG3B9Entities();

        // GET: api/Medecins
        public IQueryable<Medecin> GetMedecin()
        {
            return db.Medecin;
        }

        // GET: api/Medecins/5
        [ResponseType(typeof(Medecin))]
        public IHttpActionResult GetMedecin(int id)
        {
            Medecin medecin = db.Medecin.Find(id);
            if (medecin == null)
            {
                return NotFound();
            }

            return Ok(medecin);
        }

        // PUT: api/Medecins/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMedecin(int id, Medecin medecin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medecin.idMed)
            {
                return BadRequest();
            }

            db.Entry(medecin).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedecinExists(id))
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

        // POST: api/Medecins
        [ResponseType(typeof(Medecin))]
        public IHttpActionResult PostMedecin(Medecin medecin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Medecin.Add(medecin);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = medecin.idMed }, medecin);
        }

        // DELETE: api/Medecins/5
        [ResponseType(typeof(Medecin))]
        public IHttpActionResult DeleteMedecin(int id)
        {
            Medecin medecin = db.Medecin.Find(id);
            if (medecin == null)
            {
                return NotFound();
            }

            db.Medecin.Remove(medecin);
            db.SaveChanges();

            return Ok(medecin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MedecinExists(int id)
        {
            return db.Medecin.Count(e => e.idMed == id) > 0;
        }
    }
}