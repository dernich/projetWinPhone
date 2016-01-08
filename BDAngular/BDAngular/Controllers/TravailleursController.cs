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
using BDAngular.Models;

namespace BDAngular.Controllers
{
    public class TravailleursController : ApiController
    {
        private DBIG3B9Entities db = new DBIG3B9Entities();

        // GET: api/Travailleurs
        public IQueryable<Travailleur> GetTravailleur()
        {
            return db.Travailleur;
        }

        // GET: api/Travailleurs/5
        [ResponseType(typeof(Travailleur))]
        public IHttpActionResult GetTravailleur(int id)
        {
            Travailleur travailleur = db.Travailleur.Find(id);
            if (travailleur == null)
            {
                return NotFound();
            }

            return Ok(travailleur);
        }

        // PUT: api/Travailleurs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTravailleur(int id, Travailleur travailleur)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != travailleur.idTrav)
            {
                return BadRequest();
            }

            db.Entry(travailleur).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TravailleurExists(id))
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

        // POST: api/Travailleurs
        [ResponseType(typeof(Travailleur))]
        public IHttpActionResult PostTravailleur(Travailleur travailleur)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Travailleur.Add(travailleur);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = travailleur.idTrav }, travailleur);
        }

        // DELETE: api/Travailleurs/5
        [ResponseType(typeof(Travailleur))]
        public IHttpActionResult DeleteTravailleur(int id)
        {
            Travailleur travailleur = db.Travailleur.Find(id);
            if (travailleur == null)
            {
                return NotFound();
            }

            db.Travailleur.Remove(travailleur);
            db.SaveChanges();

            return Ok(travailleur);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TravailleurExists(int id)
        {
            return db.Travailleur.Count(e => e.idTrav == id) > 0;
        }
    }
}