using APISample.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APISample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("nombre")]
    public class TecnologiasController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Tecnologias>>> Get()
        {
            try
            {
                using (var db = new desarrolladoresdbContext())
                {
                    var tecnologias = await db.Tecnologias.ToListAsync();
                    return tecnologias;
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public void PostTecnologias([FromBody] Tecnologias tecnologia)
        {
            try
            {
                if (string.IsNullOrEmpty(tecnologia.Tecnologia))
                {
                    using (var db = new desarrolladoresdbContext())
                    {
                        db.Tecnologias.Add(tecnologia);
                        db.SaveChanges();
                    }
                }
                else
                {
                    //mostrar mensaje de error
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
