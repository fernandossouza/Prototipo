using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using CumminsPrototipo.Models;

namespace CumminsPrototipo.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GrupoEmailController : ApiController
    {
        private SPI_DB_PROTOTIPOSEntities db = new SPI_DB_PROTOTIPOSEntities();

        // GET: api/GrupoEmail
        public IQueryable<GRUPO_EMAIL> GetGRUPO_EMAIL()
        {
            return db.GRUPO_EMAIL.Include(x=>x.EMAIL);
        }

        // GET: api/GrupoEmail/5
        [ResponseType(typeof(GRUPO_EMAIL))]
        public IHttpActionResult GetGRUPO_EMAIL(long id)
        {
            GRUPO_EMAIL gRUPO_EMAIL = db.GRUPO_EMAIL.Include(x=>x.EMAIL).FirstOrDefault(x=>x.grupoEmailId==id);
            if (gRUPO_EMAIL == null)
            {
                return NotFound();
            }

            return Ok(gRUPO_EMAIL);
        }

        // PUT: api/GrupoEmail/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGRUPO_EMAIL(long id, GRUPO_EMAIL gRUPO_EMAIL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gRUPO_EMAIL.grupoEmailId)
            {
                return BadRequest();
            }

            db.Entry(gRUPO_EMAIL).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GRUPO_EMAILExists(id))
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

        // POST: api/GrupoEmail
        [ResponseType(typeof(GRUPO_EMAIL))]
        public IHttpActionResult PostGRUPO_EMAIL(GRUPO_EMAIL gRUPO_EMAIL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GRUPO_EMAIL.Add(gRUPO_EMAIL);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = gRUPO_EMAIL.grupoEmailId }, gRUPO_EMAIL);
        }

        // DELETE: api/GrupoEmail/5
        [ResponseType(typeof(GRUPO_EMAIL))]
        public IHttpActionResult DeleteGRUPO_EMAIL(long id)
        {
            GRUPO_EMAIL gRUPO_EMAIL = db.GRUPO_EMAIL.Find(id);
            if (gRUPO_EMAIL == null)
            {
                return NotFound();
            }

            db.GRUPO_EMAIL.Remove(gRUPO_EMAIL);
            db.SaveChanges();

            return Ok(gRUPO_EMAIL);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GRUPO_EMAILExists(long id)
        {
            return db.GRUPO_EMAIL.Count(e => e.grupoEmailId == id) > 0;
        }
    }
}