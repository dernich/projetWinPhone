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
    public class patientsController : ApiController
    {
        private nurseAgendaEntities db = new nurseAgendaEntities();

        // GET: api/patients
        public IEnumerable<patient> Getpatients()
        {
            return db.patients.ToList();
        }

        // GET: api/patients/5
        [ResponseType(typeof(patient))]
        public IHttpActionResult Getpatient(decimal id)
        {
            patient patient = db.patients.Find(id);
            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        // PUT: api/patients/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putpatient(decimal id, patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != patient.idPatient)
            {
                return BadRequest();
            }

            db.Entry(patient).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!patientExists(id))
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

        // POST: api/patients
        [ResponseType(typeof(patient))]
        public IHttpActionResult Postpatient(patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.patients.Add(patient);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (patientExists(patient.idPatient))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = patient.idPatient }, patient);
        }

        // DELETE: api/patients/5
        [ResponseType(typeof(patient))]
        public IHttpActionResult Deletepatient(decimal id)
        {
            patient patient = db.patients.Find(id);
            if (patient == null)
            {
                return NotFound();
            }

            db.patients.Remove(patient);
            db.SaveChanges();

            return Ok(patient);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool patientExists(decimal id)
        {
            return db.patients.Count(e => e.idPatient == id) > 0;
        }
    }
}