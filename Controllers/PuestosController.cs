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
    public class PuestosController : ControllerBase
    {
        public static Logger log = LogManager.GetLogger("myAppLogger");

        [HttpGet]
        public async Task<ActionResult> GetPuestos()
        {
            try
            {
                using (var db = new desarrolladoresdbContext())
                {
                    var puestos = await db.Puestos.ToListAsync();
                    if(puestos != null)
                    {
                        return Ok(puestos);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            catch (System.Exception ex)
            {
                log.Info(ex.Message + "- BadRequest GET List Puestos" + "-" + System.DateTime.Now);

                return BadRequest();
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetPuesto(int id)
        {
            try
            {
                using (desarrolladoresdbContext db = new desarrolladoresdbContext())
                {
                    var puesto = await db.Puestos.FirstOrDefaultAsync(p => p.IdPuesto == id);
                    if(puesto != null)
                    {
                        return Ok(puesto);
                    }
                    else
                    {
                        return NotFound("El puesto no fue encontrado");
                    }
                    //ver que sucede si no encuentra a alguien con ese id
                }
            }
            catch (System.Exception)
            {
                log.Info(ex.Message + "- BadRequest GET Puesto id: " + id + "-" + System.DateTime.Now);
                return BadRequest("Error en la consulta");
                throw;
            }
        }




        [HttpPost]
        public async Task<HttpStatusCode> Post([FromBody] Puestos puesto)
        {
            try
            {
                using (desarrolladoresdbContext db = new desarrolladoresdbContext())
                {
                    //agrego una capa de seguridad ademas del DataAnnotations
                    //considero que no habra un puesto con 3 letras, todos deberan llevar su nombre completo
                    if (!string.IsNullOrEmpty(puesto.Puesto) && (puesto.Puesto.Length > 3))
                    {
                        db.Puestos.Add(puesto);
                        await db.SaveChangesAsync();
                        return HttpStatusCode.OK;
                    }
                    else
                    {
                        //mostrar mensaje de error que el string esta vacio
                        //return new 
                        return HttpStatusCode.NotAcceptable;

                    }
                }
            }
            catch (System.Exception ex)
            {

                log.Info(ex.Message + "- BadRequest POST Puesto id:" + puesto.IdPuesto + "-" + System.DateTime.Now);
                return HttpStatusCode.BadRequest;
                throw;
            }
        }
    }
}
