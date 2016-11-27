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
using HilfepatienApi.Models;

namespace HilfepatienAPI.Controllers
{
    public class MedicinaController : ApiController
    {
        private HilfepatienContext db = new HilfepatienContext();

        // GET api/Medicina
        public IQueryable<Medicina> GetMedicinas()
        {
            return db.Medicinas;
        }

        // GET api/Medicina/5
        [ResponseType(typeof(Medicina))]
        public IHttpActionResult GetMedicina(int id)
        {
            Medicina medicina = db.Medicinas.Find(id);
            if (medicina == null)
            {
                return NotFound();
            }

            return Ok(medicina);
        }

        // PUT api/Medicina/5
        public IHttpActionResult PutMedicina(int id, Medicina medicina)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medicina.Id)
            {
                return BadRequest();
            }

            db.Entry(medicina).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicinaExists(id))
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

        // POST api/Medicina
        [ResponseType(typeof(Medicina))]
        public IHttpActionResult PostMedicina(Medicina medicina)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Medicinas.Add(medicina);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = medicina.Id }, medicina);
        }

        // DELETE api/Medicina/5
        [ResponseType(typeof(Medicina))]
        public IHttpActionResult DeleteMedicina(int id)
        {
            Medicina medicina = db.Medicinas.Find(id);
            if (medicina == null)
            {
                return NotFound();
            }

            db.Medicinas.Remove(medicina);
            db.SaveChanges();

            return Ok(medicina);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MedicinaExists(int id)
        {
            return db.Medicinas.Count(e => e.Id == id) > 0;
        }
    }
}