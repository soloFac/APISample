using APISample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesarrolladoresController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Desarrolladores>>> Get()
        {
            try
            {
                using (var db = new desarrolladoresdbContext())
                {
                    var desarrolladores = await db.Desarrolladores.ToListAsync();
                    return desarrolladores;
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public void PostDesarrolladores([FromBody] Desarrolladores desarrollador)
        {
            try
            {
                using (var db = new desarrolladoresdbContext())
                {
                    db.Desarrolladores.Add(desarrollador);
                    db.SaveChanges();
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

    }
}
