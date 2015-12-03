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
using WebApiNurseAgenda.Models;

namespace WebApiNurseAgenda.Controllers
{
    public class infirmiersController : ApiController
    {
        private nurseAgendaEntities db = new nurseAgendaEntities();

        // GET: api/infirmiers
        public IQueryable<infirmier> Getinfirmiers()
        {
            return db.infirmiers;
        }

        // GET: api/infirmiers/5
        [ResponseType(typeof(infirmier))]
        public IHttpActionResult Getinfirmier(decimal id)
        {
            infirmier infirmier = db.infirmiers.Find(id);
            if (infirmier == null)
            {
                return NotFound();
            }

            return Ok(infirmier);
        }

        // PUT: api/infirmiers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putinfirmier(decimal id, infirmier infirmier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != infirmier.idInfi)
            {
                return BadRequest();
            }

            db.Entry(infirmier).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!infirmierExists(id))
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

        // POST: api/infirmiers
        [ResponseType(typeof(infirmier))]
        public IHttpActionResult Postinfirmier(infirmier infirmier)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.infirmiers.Add(infirmier);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (infirmierExists(infirmier.idInfi))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = infirmier.idInfi }, infirmier);
        }

        // DELETE: api/infirmiers/5
        [ResponseType(typeof(infirmier))]
        public IHttpActionResult Deleteinfirmier(decimal id)
        {
            infirmier infirmier = db.infirmiers.Find(id);
            if (infirmier == null)
            {
                return NotFound();
            }

            db.infirmiers.Remove(infirmier);
            db.SaveChanges();

            return Ok(infirmier);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool infirmierExists(decimal id)
        {
            return db.infirmiers.Count(e => e.idInfi == id) > 0;
        }
    }
}