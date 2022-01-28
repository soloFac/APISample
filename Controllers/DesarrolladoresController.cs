using APISample.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLog;

namespace APISample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("nombre")]
    public class DesarrolladoresController : ControllerBase
    {
        public static Logger log = LogManager.GetLogger("myAppLogger");

        [HttpGet]
        public async Task<ActionResult<List<Desarrolladores>>> Get()
        {
            try
            {
                using (var db = new desarrolladoresdbContext())
                {
                    var desarrolladores = await db.Desarrolladores.ToListAsync();
                    if(desarrolladores != null)
                    {
                        return Ok(desarrolladores);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            catch (System.Exception ex)
            {
                log.Info(ex.Message + "- BadRequest GET ListDev " + "-" + System.DateTime.Now);
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Desarrolladores>>> GetDesarrollador(int id)
        {
            try
            {
                using (var db = new desarrolladoresdbContext())
                {
                    var desarrollador = await db.Desarrolladores.FirstOrDefaultAsync(d => d.IdDesarrollador == id);
                    if (desarrollador != null)
                    {
                        return Ok(desarrollador);
                    }
                    else
                    {
                        log.Info("Not found " + id + "-" + System.DateTime.Now);
                        return NotFound();
                    }
                }
            }
            catch (System.Exception ex)
            {
                log.Info(ex.Message + "- BadRequest GET idDev: " + id + "-" + System.DateTime.Now);
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutDesarrolladores(Desarrolladores desarrollador)
        {
            try
            {
                using (var db = new desarrolladoresdbContext())
                {
                    Desarrolladores oDesarrollador = await db.Desarrolladores.FindAsync(desarrollador.IdDesarrollador);
                    oDesarrollador.Nombre = desarrollador.Nombre;
                    oDesarrollador.Profesion = desarrollador.Profesion;
                    oDesarrollador.IdTecnologia = desarrollador.IdTecnologia;
                    oDesarrollador.IdPuesto = desarrollador.IdPuesto;
                    db.Entry(oDesarrollador).State = EntityState.Modified;
                    db.SaveChanges();
                    return Ok("Modificado satisfactoriamente en la base de datos");
                }
            }
            catch (System.Exception ex)
            {
                log.Info(ex.Message + "- BadRequest PUT idDev: " + desarrollador.IdDesarrollador + "-" + System.DateTime.Now);
                return BadRequest();
                throw;
            }
        }

        [HttpPost]
        public ActionResult PostDesarrolladores([FromBody] Desarrolladores desarrollador)
        {
            try
            {
                using (var db = new desarrolladoresdbContext())
                {
                    db.Desarrolladores.Add(desarrollador);
                    db.SaveChanges();
                    return Ok("Ingresado a la base de datos satisfactoriamente");
                }
            }
            catch (System.Exception ex)
            {
                log.Info(ex.Message + "- BadRequest POST idDev: " + desarrollador.IdDesarrollador + "-" + System.DateTime.Now);
                return BadRequest();
                throw;
            }
        }


    }
}
