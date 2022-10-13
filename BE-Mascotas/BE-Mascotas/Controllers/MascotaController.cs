using BE_Mascotas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BE_Mascotas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotaController : ControllerBase
       
    {
        private readonly AplicationDbContext _context;

        //creamos el contructor para esta clase
        public MascotaController(AplicationDbContext context)
        {
            _context = context;
        }

        //creamos un metodo azincrono para me debuelva un Json en swagger

        [HttpGet]

        public async Task<IActionResult> Get()
        {
            try
            {  
                //me traiga todos los elementos de la tabla mascotas
                var ListMascotas = await _context.Mascotas.ToListAsync();
                return Ok(ListMascotas);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

    }
}
