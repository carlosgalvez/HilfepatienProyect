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
    public class RecetaController : ApiController
    {
        private HilfepatienContext db = new HilfepatienContext();

        // GET api/Receta
        public IQueryable<Receta> GetRecetas()
        {
            return db.Recetas;
        }

        // GET api/Receta/5
        [ResponseType(typeof(Receta))]
        public IHttpActionResult GetReceta(int id)
        {
            Receta receta = db.Recetas.Find(id);
            if (receta == null)
            {
                return NotFound();
            }

            return Ok(receta);
        }

        // PUT api/Receta/5
        public IHttpActionResult PutReceta(int id, Receta receta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != receta.Id)
            {
                return BadRequest();
            }

            db.Entry(receta).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecetaExists(id))
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

        // POST api/Receta
        [ResponseType(typeof(Receta))]
        public IHttpActionResult PostReceta(Receta receta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Recetas.Add(receta);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = receta.Id }, receta);
        }

        // DELETE api/Receta/5
        [ResponseType(typeof(Receta))]
        public IHttpActionResult DeleteReceta(int id)
        {
            Receta receta = db.Recetas.Find(id);
            if (receta == null)
            {
                return NotFound();
            }

            db.Recetas.Remove(receta);
            db.SaveChanges();

            return Ok(receta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RecetaExists(int id)
        {
            return db.Recetas.Count(e => e.Id == id) > 0;
        }
    }
}