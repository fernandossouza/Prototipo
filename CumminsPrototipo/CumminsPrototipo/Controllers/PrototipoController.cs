using System;
using System.Collections.Generic;
using System.Configuration;
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
    public class PrototipoController : ApiController
    {
        private SPI_DB_PROTOTIPOSEntities db = new SPI_DB_PROTOTIPOSEntities();

        // GET: api/Prototipo
        public IQueryable<PROTOTIPO> GetPROTOTIPO()
        {
            return db.PROTOTIPO.Include(x=>x.PROTOTIPO_GRUPO_EMAIL);
        }

        // GET: api/Prototipo/5
        [ResponseType(typeof(PROTOTIPO))]
        public IHttpActionResult GetPROTOTIPO(long id)
        {
            PROTOTIPO pROTOTIPO = db.PROTOTIPO.Find(id);
            if (pROTOTIPO == null)
            {
                return NotFound();
            }

            return Ok(pROTOTIPO);
        }
       

        // PUT: api/Prototipo/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPROTOTIPO(long id, PROTOTIPO pROTOTIPO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pROTOTIPO.prototipoId)
            {
                return BadRequest();
            }

            var prototipoDB = db.PROTOTIPO.AsNoTracking().FirstOrDefault(x=>x.prototipoId == id);



            // deleta os grupos de email dos prototipos
            foreach (var deletarGrupo in prototipoDB.PROTOTIPO_GRUPO_EMAIL)
            {
                if (pROTOTIPO.PROTOTIPO_GRUPO_EMAIL.Count(x => x.prototipoGrupoEmailId == deletarGrupo.prototipoGrupoEmailId) == 0)
                {
                    var delete = db.PROTOTIPO_GRUPO_EMAIL.FirstOrDefault(x => x.prototipoGrupoEmailId == deletarGrupo.prototipoGrupoEmailId);
                    db.PROTOTIPO_GRUPO_EMAIL.Remove(delete);
                    //db.SaveChanges();
                    //db.Entry(deletarGrupo).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }

            // atualiza e adiciona os grupos de email do prototipo
            foreach (var pGrupo in pROTOTIPO.PROTOTIPO_GRUPO_EMAIL)
            {

                pGrupo.prototipoId = pROTOTIPO.prototipoId;
                if (pGrupo.prototipoGrupoEmailId > 0)
                {
                    db.Entry(pGrupo).State = EntityState.Modified;
                }
                else
                {
                    db.PROTOTIPO_GRUPO_EMAIL.Add(pGrupo);
                }
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PROTOTIPOExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }



            db.Entry(pROTOTIPO).State = EntityState.Modified;

   
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PROTOTIPOExists(id))
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

        // POST: api/Prototipo
        [ResponseType(typeof(PROTOTIPO))]
        public IHttpActionResult PostPROTOTIPO(PROTOTIPO pROTOTIPO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PROTOTIPO.Add(pROTOTIPO);

            foreach (var pGrupo in pROTOTIPO.PROTOTIPO_GRUPO_EMAIL)
            {
                pGrupo.prototipoId = pROTOTIPO.prototipoId;
                db.PROTOTIPO_GRUPO_EMAIL.Add(pGrupo);
            }

            db.SaveChanges();


            return CreatedAtRoute("DefaultApi", new { id = pROTOTIPO.prototipoId }, pROTOTIPO);
        }

        // DELETE: api/Prototipo/5
        [ResponseType(typeof(PROTOTIPO))]
        public IHttpActionResult DeletePROTOTIPO(long id)
        {
            PROTOTIPO pROTOTIPO = db.PROTOTIPO.Find(id);
            if (pROTOTIPO == null)
            {
                return NotFound();
            }

            db.PROTOTIPO.Remove(pROTOTIPO);
            db.SaveChanges();

            return Ok(pROTOTIPO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PROTOTIPOExists(long id)
        {
            return db.PROTOTIPO.Count(e => e.prototipoId == id) > 0;
        }
    }
}