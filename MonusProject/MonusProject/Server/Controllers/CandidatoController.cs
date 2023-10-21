
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
    public class CandidatoController : ControllerBase
    {
        private readonly ColloquioContext _context;

        public CandidatoController(ColloquioContext context)
        {
            _context = context;
        }

        // GET: api/Candidato
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candidato>>> GetCandidati()
        {
            var candidati = await _context.Candidati.ToListAsync();
            if (candidati != null)
            return Ok(candidati);
            else
                return NotFound();
        }

        // GET: api/Sede/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Candidato>> GetCandidato(int id)
        {
            var foundCandido = await _context.Candidati.FindAsync(id);

            if (foundCandido == null)
            {
                return NotFound();
            }

            return Ok(foundCandido);
        }

        // POST: api/Candidato
          [HttpPost]
        public async Task<IActionResult> AddCandidato(Candidato nuovoCandidato)
        {
            // Add the new Candidato to the context and save changes to the database
            await _context.Candidati.AddAsync(nuovoCandidato);
            await _context.SaveChangesAsync();
            return Ok(nuovoCandidato);
        }


        // DELETE: api/Candidato/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidato(int id)
        {
            var candidato = await _context.Candidati.FindAsync(id);
            if (candidato == null)
            {
                return NotFound();
            }

            _context.Candidati.Remove(candidato);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        //PUT: api/Candidato
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDipendente(int id, Candidato updatedCandidato)
        {
            // Find the Candidato with the specified ID
            var existingCandidato = await _context.Candidati.FindAsync(id);

            if (existingCandidato == null)
            {
                return NotFound(); // Candidato not found
            }

            // Update the Candidato properties with the new data
            existingCandidato.Nome = updatedCandidato.Nome;
            existingCandidato.Cognome = updatedCandidato.Cognome;

            // Save the changes to the database
            _context.Candidati.Update(existingCandidato);
            await _context.SaveChangesAsync();

            return Ok(existingCandidato);
        }


    }
}
