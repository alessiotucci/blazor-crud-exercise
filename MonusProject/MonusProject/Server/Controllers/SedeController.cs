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
using Microsoft.IdentityModel.Tokens;

namespace MonusProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SedeController : ControllerBase
    {
        private readonly ColloquioContext _context;
        // constructor ok ?
        public SedeController(ColloquioContext context)
        {
            _context = context;
        }
        
        // GET: api/Sede
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sede>>> GetSedi()
        {
            var sedi = await _context.Sedi.ToListAsync();
            if (!sedi.IsNullOrEmpty())
                return Ok(sedi);
            else
                return NotFound();
        }
        // GET: api/Sede/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sede>> GetSede(int id)
        {
            var trovataSede = await _context.Sedi.FindAsync(id);

            if (trovataSede == null)
            {
                return NotFound();
            }

            return Ok(trovataSede);
        }
        // DELETE: api/Sede/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSede(int id)
        {
            var sede = await _context.Sedi.FindAsync(id);
            if (sede == null)
            {
                return NotFound();
            }

            _context.Sedi.Remove(sede);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        // POST: api/Sede
        [HttpPost]
        public async Task<IActionResult> AddSede(Sede nuovaSede)
        {
            // Add the new Candidato to the context and save changes to the database
            _context.Sedi.Add(nuovaSede);
            await _context.SaveChangesAsync();
            //return Ok(nuovaSede);
            return CreatedAtAction(nameof(GetSede), new { id = nuovaSede.SedeId }, nuovaSede);
        }
        //PUT: api/Sede
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSede(int id, Sede updatedSede)
        {
            // Find the sede with the specified ID
            var existingSede = await _context.Sedi.FindAsync(id);

            if (existingSede == null)
            {
                return NotFound(); // Sede not found
            }

            //Update the sede properties with the new data
            existingSede.SedeName = updatedSede.SedeName;
            existingSede.Indirizzo = updatedSede.Indirizzo;
            
           // _context.Entry(existingSede).CurrentValues.SetValues(updatedSede);

            // Save the changes to the database
            _context.Sedi.Update(existingSede);
            await _context.SaveChangesAsync();

            return Ok(existingSede);
        }

    }
}
