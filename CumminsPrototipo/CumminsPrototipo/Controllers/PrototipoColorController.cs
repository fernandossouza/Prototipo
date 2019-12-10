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
    public class PrototipoColorController : ApiController
    {
        private SPI_DB_PROTOTIPOSEntities db = new SPI_DB_PROTOTIPOSEntities();

        // GET: api/Prototipo/Ws=W5dsd        
        [ResponseType(typeof(PROTOTIPO))]
        public IHttpActionResult GetPROTOTIPOCOR(string SO)
        {
            PROTOTIPO pROTOTIPO = db.PROTOTIPO.Where(x => x.shopOrder == SO).FirstOrDefault();
            string cor = string.Empty;
            if (pROTOTIPO == null)
            {
                return Ok(new { color = "" });
            }

            if (pROTOTIPO.tipo.ToLower() == "validacao")
            {
                cor = ConfigurationSettings.AppSettings["corValidacao"].ToString();
                return Ok(new { color = cor });
            }

            cor = ConfigurationSettings.AppSettings["corPrototipo"].ToString();
            return Ok(new { color = cor });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
