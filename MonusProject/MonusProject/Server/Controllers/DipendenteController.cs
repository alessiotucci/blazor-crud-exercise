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
        // GET: api/Dipendente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dipendente>> GetDipendente(int id)
        {
            var foundDipendente = await _context.Dipendenti.FindAsync(id);

            if (foundDipendente == null)
            {
                return NotFound();
            }

            return Ok(foundDipendente);
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

        //POST: api/Dipendente
        [HttpPost]
        public async Task<IActionResult> AddDipendente(Dipendente nuovoDipendente)
        {
            _context.Dipendenti.Add(nuovoDipendente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDipendente), new { id = nuovoDipendente.DipendenteId }, nuovoDipendente);
        }
        //PUT: api/Dipendente
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDipendente(int id, Dipendente updatedDipendente)
        {
            // Find the Dipendente with the specified ID
            var existingDipenden = await _context.Dipendenti.FindAsync(id);

            if (existingDipenden == null)
            {
                return NotFound(); // Dipendente not found
            }

            /* Update all properties of the Dipendente
            _context.Entry(existingDipenden).CurrentValues.SetValues(updatedDipendente); 
            */

            // Update the Dipendente properties with the new data
            existingDipenden.Nome = updatedDipendente.Nome;
            existingDipenden.Cognome = updatedDipendente.Cognome;
            existingDipenden.SedeId = updatedDipendente.SedeId; // Add this line

            // Save the changes to the database
            _context.Dipendenti.Update(existingDipenden);
            await _context.SaveChangesAsync();

            return Ok(existingDipenden);
        }


    }
}
