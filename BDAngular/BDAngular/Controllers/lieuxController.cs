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
    public class lieuxController : ApiController
    {
        private DBIG3B9Entities db = new DBIG3B9Entities();

        // GET: api/lieux
        public IQueryable<lieu> Getlieu()
        {
            return db.lieu;
        }

        // GET: api/lieux/5
        [ResponseType(typeof(lieu))]
        public IHttpActionResult Getlieu(int id)
        {
            lieu lieu = db.lieu.Find(id);
            if (lieu == null)
            {
                return NotFound();
            }

            return Ok(lieu);
        }

        // PUT: api/lieux/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putlieu(int id, lieu lieu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lieu.idLieu)
            {
                return BadRequest();
            }

            db.Entry(lieu).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!lieuExists(id))
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

        // POST: api/lieux
        [ResponseType(typeof(lieu))]
        public IHttpActionResult Postlieu(lieu lieu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.lieu.Add(lieu);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lieu.idLieu }, lieu);
        }

        // DELETE: api/lieux/5
        [ResponseType(typeof(lieu))]
        public IHttpActionResult Deletelieu(int id)
        {
            lieu lieu = db.lieu.Find(id);
            if (lieu == null)
            {
                return NotFound();
            }

            db.lieu.Remove(lieu);
            db.SaveChanges();

            return Ok(lieu);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool lieuExists(int id)
        {
            return db.lieu.Count(e => e.idLieu == id) > 0;
        }
    }
}