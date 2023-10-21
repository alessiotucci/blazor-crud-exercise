using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MonusProject.Client.Pages;
using MonusProject.Client.Shared.Models;
using MonusProject.Server.Data;

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

        //GET : api/Candidato
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candidato>>> GetCandidati()
        {
            var candidati = await _context.Candidati.ToListAsync();
            return Ok(candidati);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Candidato>> GetCandidato(int id)
        {
            var findCandidato = await _context.Candidati.FindAsync(id);

            if(findCandidato == null)
            {
                return NotFound();
            }

            return Ok(findCandidato);
        }

        //POST: api/Candidato
        [HttpPost]
        public async Task<IActionResult> AddCandidato(Candidato nuovoCandidato)
        {
            //Add the new candidato to the context and save changes to the database
            await _context.Candidati.AddAsync(nuovoCandidato);
            await _context.SaveChangesAsync();
            return Ok(nuovoCandidato);
        }

        // DELETE: api/Candidato
        [HttpDelete("{id:int}")]

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

        [HttpPost]
        [Route("UpdateCandidato/{id:int}")]

        public async Task<IActionResult> UpdateCandidato(int id, Candidato candidatoAggiornato)
        {
            var candidatoEsistente = await _context.Candidati.FindAsync(id);
            if(candidatoEsistente == null)
            { 
                return NotFound(); 
            }

            candidatoEsistente.Nome = candidatoAggiornato.Nome;
            candidatoEsistente.Cognome = candidatoAggiornato.Cognome;
            //candidatoEsistente.SkillName = candidatoAggiornato.SkillName;
            //Add the new candidato to the context and save changes to the database
            _context.Candidati.Update(candidatoEsistente);
            await _context.SaveChangesAsync();
            return Ok(candidatoEsistente);
        }

    }
}
