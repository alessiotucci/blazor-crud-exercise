using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonusProject.Client.Pages;
using MonusProject.Server.Data; // Import your DbContext and Candidato classes here
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MonusProject.Client.Shared;
using MonusProject.Client.Shared.Models;

namespace MonusProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DipendenteController : ControllerBase
    {
        private readonly ColloquioContext _context;


        // constructor ok ?
        public DipendenteController(ColloquioContext context)
        {
            _context = context;
        }

        // GET: api/Dipendenti
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dipendente>>> GetDipendenti()
        {
            var dipendenti = await _context.Dipendenti.ToListAsync();
            if (dipendenti != null)
                return Ok(dipendenti);
            else
                return NotFound();
        }
        // DELETE: api/Dipendenti/5
        [HttpDelete("{id}")]
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
        // POST: api/Dipendente
        [HttpPost]
        public async Task<IActionResult> AddDipendente(Dipendente nuovoDipendente)
        {
            // Add the new Candidato to the context and save changes to the database
            _context.Dipendenti.AddAsync(nuovoDipendente);
            await _context.SaveChangesAsync();
            return Ok(nuovoDipendente);
        }
    }
}
