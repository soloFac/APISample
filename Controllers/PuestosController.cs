using APISample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APISample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuestosController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Puestos>>> Get()
        {
            try
            {
                using (var db = new desarrolladoresdbContext())
                {
                    var puestos = await db.Puestos.ToListAsync();
                    return puestos;
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public void Post([FromBody] Puestos puesto)
        {
            try
            {
                using (desarrolladoresdbContext db = new desarrolladoresdbContext())
                {
                    if (!string.IsNullOrEmpty(puesto.Puesto))
                    {
                        db.Puestos.Add(puesto);
                        db.SaveChanges();
                    }
                    else
                    {
                        //mostrar que el string esta vacio
                    }
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
