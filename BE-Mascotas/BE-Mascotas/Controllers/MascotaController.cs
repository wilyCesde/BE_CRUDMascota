﻿using BE_Mascotas.Models;
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
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var mascota =await _context.Mascotas.FindAsync(id);
                if(mascota==null)
                {
                    return NotFound();
                }
                return Ok(mascota);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            try
            {
                var mascota =await _context.Mascotas.FindAsync(id);
                if (mascota==null)
                {
                    return NotFound();
                }
                _context.Mascotas.Remove(mascota);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(Mascota mascota)
        {
            try
            {
                mascota.FechaCreacion = DateTime.Now;
                _context.Add(mascota);
               await _context.SaveChangesAsync();
                return CreatedAtAction("Get",new {id=mascota.Id},mascota);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
