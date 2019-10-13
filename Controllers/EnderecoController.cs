using System.Collections.Generic;
using System.Threading.Tasks;
using EFDatabaseFirts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFDatabaseFirts.Controllers
{
    // Definir Rota da API
    // Definir que é um Controller de API
    // Herdar ControllerBase
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {

        testeContext _context = new testeContext();        

         // GET: api/Endereco/
        [HttpGet]
        public async Task<ActionResult<List<Endereco>>> Get()
        {
            var enderecos = await _context.Endereco.ToListAsync();

            if (enderecos == null)
            {
                return NotFound();
            }

            return enderecos;
        }

        // GET: api/Endereco/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Endereco>> Get(int id)
        {
            var endereco = await _context.Endereco.FindAsync(id);

            if (endereco == null)
            {
                return NotFound();
            }

            return endereco;
        }

        // PUT: api/Endereco/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, Endereco endereco)
        {
            if (id != endereco.IdEndereco)
            {
                return BadRequest();
            }

            _context.Entry(endereco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var endereco_valido = await _context.Endereco.FindAsync(id);

                if (endereco_valido == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Endereco/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Endereco>> Delete(int id)
        {
            var endereco = await _context.Endereco.FindAsync(id);
            if (endereco == null)
            {
                return NotFound();
            }

            _context.Endereco.Remove(endereco);
            await _context.SaveChangesAsync();

            return endereco;
        }


    }
}