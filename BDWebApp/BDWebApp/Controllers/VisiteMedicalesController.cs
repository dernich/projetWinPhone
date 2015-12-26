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
    public class VisiteMedicalesController : ApiController
    {
        private DBIG3B9Entities db = new DBIG3B9Entities();

        // GET: api/VisiteMedicales
        public IQueryable<VisiteMedicale> GetVisiteMedicale()
        {
            return db.VisiteMedicale;
        }

        // GET: api/VisiteMedicales/5
        [ResponseType(typeof(VisiteMedicale))]
        public IHttpActionResult GetVisiteMedicale(int id)
        {
            VisiteMedicale visiteMedicale = db.VisiteMedicale.Find(id);
            if (visiteMedicale == null)
            {
                return NotFound();
            }

            return Ok(visiteMedicale);
        }

        // PUT: api/VisiteMedicales/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVisiteMedicale(int id, VisiteMedicale visiteMedicale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != visiteMedicale.idVM)
            {
                return BadRequest();
            }

            db.Entry(visiteMedicale).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisiteMedicaleExists(id))
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

        // POST: api/VisiteMedicales
        [ResponseType(typeof(VisiteMedicale))]
        public IHttpActionResult PostVisiteMedicale(VisiteMedicale visiteMedicale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VisiteMedicale.Add(visiteMedicale);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = visiteMedicale.idVM }, visiteMedicale);
        }

        // DELETE: api/VisiteMedicales/5
        [ResponseType(typeof(VisiteMedicale))]
        public IHttpActionResult DeleteVisiteMedicale(int id)
        {
            VisiteMedicale visiteMedicale = db.VisiteMedicale.Find(id);
            if (visiteMedicale == null)
            {
                return NotFound();
            }

            db.VisiteMedicale.Remove(visiteMedicale);
            db.SaveChanges();

            return Ok(visiteMedicale);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VisiteMedicaleExists(int id)
        {
            return db.VisiteMedicale.Count(e => e.idVM == id) > 0;
        }
    }
}