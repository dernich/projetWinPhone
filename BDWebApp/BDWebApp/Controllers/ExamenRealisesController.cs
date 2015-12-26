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
    public class ExamenRealisesController : ApiController
    {
        private DBIG3B9Entities db = new DBIG3B9Entities();

        // GET: api/ExamenRealises
        public IQueryable<ExamenRealise> GetExamenRealise()
        {
            return db.ExamenRealise;
        }

        // GET: api/ExamenRealises/5
        [ResponseType(typeof(ExamenRealise))]
        public IHttpActionResult GetExamenRealise(int id)
        {
            ExamenRealise examenRealise = db.ExamenRealise.Find(id);
            if (examenRealise == null)
            {
                return NotFound();
            }

            return Ok(examenRealise);
        }

        // PUT: api/ExamenRealises/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExamenRealise(int id, ExamenRealise examenRealise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != examenRealise.codeExamReal)
            {
                return BadRequest();
            }

            db.Entry(examenRealise).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamenRealiseExists(id))
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

        // POST: api/ExamenRealises
        [ResponseType(typeof(ExamenRealise))]
        public IHttpActionResult PostExamenRealise(ExamenRealise examenRealise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ExamenRealise.Add(examenRealise);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = examenRealise.codeExamReal }, examenRealise);
        }

        // DELETE: api/ExamenRealises/5
        [ResponseType(typeof(ExamenRealise))]
        public IHttpActionResult DeleteExamenRealise(int id)
        {
            ExamenRealise examenRealise = db.ExamenRealise.Find(id);
            if (examenRealise == null)
            {
                return NotFound();
            }

            db.ExamenRealise.Remove(examenRealise);
            db.SaveChanges();

            return Ok(examenRealise);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExamenRealiseExists(int id)
        {
            return db.ExamenRealise.Count(e => e.codeExamReal == id) > 0;
        }
    }
}