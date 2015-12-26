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
    public class TypeExamenController : ApiController
    {
        private DBIG3B9Entities db = new DBIG3B9Entities();

        // GET: api/TypeExamen
        public IQueryable<TypeExamen> GetTypeExamen()
        {
            return db.TypeExamen;
        }

        // GET: api/TypeExamen/5
        [ResponseType(typeof(TypeExamen))]
        public IHttpActionResult GetTypeExamen(int id)
        {
            TypeExamen typeExamen = db.TypeExamen.Find(id);
            if (typeExamen == null)
            {
                return NotFound();
            }

            return Ok(typeExamen);
        }

        // PUT: api/TypeExamen/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTypeExamen(int id, TypeExamen typeExamen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != typeExamen.codeTypeExam)
            {
                return BadRequest();
            }

            db.Entry(typeExamen).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeExamenExists(id))
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

        // POST: api/TypeExamen
        [ResponseType(typeof(TypeExamen))]
        public IHttpActionResult PostTypeExamen(TypeExamen typeExamen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TypeExamen.Add(typeExamen);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = typeExamen.codeTypeExam }, typeExamen);
        }

        // DELETE: api/TypeExamen/5
        [ResponseType(typeof(TypeExamen))]
        public IHttpActionResult DeleteTypeExamen(int id)
        {
            TypeExamen typeExamen = db.TypeExamen.Find(id);
            if (typeExamen == null)
            {
                return NotFound();
            }

            db.TypeExamen.Remove(typeExamen);
            db.SaveChanges();

            return Ok(typeExamen);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TypeExamenExists(int id)
        {
            return db.TypeExamen.Count(e => e.codeTypeExam == id) > 0;
        }
    }
}