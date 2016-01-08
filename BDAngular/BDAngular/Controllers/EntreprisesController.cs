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
    public class EntreprisesController : ApiController
    {
        private DBIG3B9Entities db = new DBIG3B9Entities();

        // GET: api/Entreprises
        public IQueryable<Entreprise> GetEntreprise()
        {
            return db.Entreprise;
        }

        // GET: api/Entreprises/5
        [ResponseType(typeof(Entreprise))]
        public IHttpActionResult GetEntreprise(int id)
        {
            Entreprise entreprise = db.Entreprise.Find(id);
            if (entreprise == null)
            {
                return NotFound();
            }

            return Ok(entreprise);
        }

        // PUT: api/Entreprises/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEntreprise(int id, Entreprise entreprise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entreprise.numeroEntr)
            {
                return BadRequest();
            }

            db.Entry(entreprise).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntrepriseExists(id))
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

        // POST: api/Entreprises
        [ResponseType(typeof(Entreprise))]
        public IHttpActionResult PostEntreprise(Entreprise entreprise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entreprise.Add(entreprise);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = entreprise.numeroEntr }, entreprise);
        }

        // DELETE: api/Entreprises/5
        [ResponseType(typeof(Entreprise))]
        public IHttpActionResult DeleteEntreprise(int id)
        {
            Entreprise entreprise = db.Entreprise.Find(id);
            if (entreprise == null)
            {
                return NotFound();
            }

            db.Entreprise.Remove(entreprise);
            db.SaveChanges();

            return Ok(entreprise);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EntrepriseExists(int id)
        {
            return db.Entreprise.Count(e => e.numeroEntr == id) > 0;
        }
    }
}