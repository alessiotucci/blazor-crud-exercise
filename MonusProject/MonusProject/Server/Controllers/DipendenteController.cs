using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonusProject.Client.Shared.Models;
using MonusProject.Server.Data;


namespace MonusProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DipendenteController : ControllerBase
    {
        private readonly ColloquioContext _context;

        public DipendenteController(ColloquioContext context)
        {
            _context = context;
        }

        //GET : api/Dipendente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dipendente>>> GetDipendente()
        {
            var dipendenti= await _context.Dipendenti.ToListAsync();
            return Ok(dipendenti);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Dipendente>> GetDipendente(int id)
        {
            var findDipendente = await _context.Dipendenti.FindAsync(id);

            if (findDipendente == null)
            {
                return NotFound();
            }

            return Ok(findDipendente);
        }

        //POST: api/Dipendente
        [HttpPost]
        public async Task<IActionResult> AddDipendente(Dipendente nuovoDipendente)
        {
            //Add the new dipendente to the context and save changes to the database
            _context.Dipendenti.AddAsync(nuovoDipendente);
            await _context.SaveChangesAsync();
            return Ok(nuovoDipendente);
        }

        // DELETE: api/Dipendente
        [HttpDelete("{id:int}")]

        public async Task<IActionResult> DeleteDipendente(int id)
        {
            var dipendente = await _context.Dipendenti.FindAsync(id);
            if (dipendente == null)
            {
                return NotFound();
            }

            _context.Dipendenti.Remove(dipendente);
            await _context.SaveChangesAsync();

            return NoContent();
        }



    }
}
