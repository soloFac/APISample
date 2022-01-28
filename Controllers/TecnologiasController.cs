using APISample.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using NLog;

namespace APISample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("nombre")]
    public class TecnologiasController : ControllerBase
    {
        public static Logger log = LogManager.GetLogger("myAppLogger");

        [HttpGet]
        public async Task<ActionResult<List<Tecnologias>>> Get()
        {
            try
            {
                using (var db = new desarrolladoresdbContext())
                {
                    var tecnologias = await db.Tecnologias.ToListAsync();
                    if(tecnologias != null)
                    {
                        return Ok(tecnologias);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            catch (System.Exception ex)
            {
                log.Info(ex.Message + "- BadRequest GET Lista Tecnologias" + "-" + System.DateTime.Now);
                return BadRequest();
                throw;
            }
        }

        [HttpPost]
        public async Task<HttpStatusCode> PostTecnologias([FromBody] Tecnologias tecnologia)
        {
            try
            {
                if (!string.IsNullOrEmpty(tecnologia.Tecnologia) && (tecnologia.Tecnologia.Length > 3))
                {
                    using (var db = new desarrolladoresdbContext())
                    {
                        db.Tecnologias.Add(tecnologia);
                        db.SaveChanges();
                        return HttpStatusCode.OK;
                    }
                }
                else
                {
                    return HttpStatusCode.NotAcceptable;
                }
            }
            catch (System.Exception ex)
            {
                log.Info(ex.Message + "- BadRequest POST Tecnologia id: " + tecnologia.IdTecnologia + "-" + System.DateTime.Now);
                return HttpStatusCode.BadRequest;
                throw;
            }
        }
    }
}
