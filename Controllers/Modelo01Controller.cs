using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projeto01.Data;
using projeto01.Models;

namespace projeto01.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Modelo01Controller : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public Modelo01Controller(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [HttpPost]
        public async Task<IActionResult> AddModelo01(modelo01 modelo01)
        {
            _appDbContext.darlyson.Add(modelo01);
            await _appDbContext.SaveChangesAsync();

            return Ok(modelo01);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerator<modelo01>>> GetModelo01()
        {
            var modelo01 = await _appDbContext.darlyson.ToListAsync();
            return Ok(modelo01);
        }

        [HttpGet("id")]
        public async Task<ActionResult<modelo01>> Getmodelo01(int id)
        {
            var modelo01 = await _appDbContext.darlyson.FindAsync(id);
            if(modelo01 == null)
            {
                return NotFound("Modelo não encontrado!");
            }
            return Ok(modelo01);
        }
        [HttpPut("id")]
        public async Task<IActionResult> Updatemodelo01(int id, [FromBody] modelo01 modelo01Atualizado)
        {
            var modelo01Existente = await _appDbContext.darlyson.FindAsync(id);

            if(modelo01Existente == null)
            {
                return NotFound("Modelo não encontrado!");
            }
                _appDbContext.Entry(modelo01Existente).CurrentValues.SetValues(modelo01Atualizado);
                await _appDbContext.SaveChangesAsync();

                return StatusCode(201, modelo01Existente);
            
        }


        [HttpDelete("id")]
        public async Task<IActionResult> modelo01(int id, [FromBody] modelo01 modelo01Atualizado)
        {
            var modelo01 = await _appDbContext.darlyson.FindAsync(id);

            if(modelo01 == null)
            {
                return NotFound("Modelo não encontrado!");
            }
                _appDbContext.darlyson.Remove(modelo01);
                await _appDbContext.SaveChangesAsync();

                return Ok("Modelo01 deletado com sucesso!!");
            
        }
    }
}