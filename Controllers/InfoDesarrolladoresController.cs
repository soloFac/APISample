using APISample.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace APISample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("nombre")]
    public class InfoDesarrolladoresController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<InfoDesarrolladores>>> Get()
        {
            try
            {
                using (var db = new desarrolladoresdbContext())
                {
                    //var desarrolladores = await db.Desarrolladores.ToListAsync();
                    var infoDesarrolladores = await (from d in db.Desarrolladores
                                                       join p in db.Puestos on d.IdPuesto equals p.IdPuesto
                                                       join t in db.Tecnologias on d.IdTecnologia equals t.IdTecnologia
                                                       select new InfoDesarrolladores
                                                       {
                                                           IdDesarrollador = d.IdDesarrollador,
                                                           Nombre = d.Nombre,
                                                           Profesion = d.Profesion,
                                                           Puesto = p.Puesto,
                                                           Tecnologia = t.Tecnologia,
                                                       })
                                                       .ToListAsync();
                    if(infoDesarrolladores != null)
                    {
                        return Ok(infoDesarrolladores);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }
        
    }
}
