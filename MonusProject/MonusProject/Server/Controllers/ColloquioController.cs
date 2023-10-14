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
    public class ColloquioController : ControllerBase
    {
        private readonly ColloquioContext _context;

        // constructor ok ?
        public ColloquioController(ColloquioContext context)
        {
            _context = context;
        }

        // GET: api/Colloquio
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Colloquio>>> GetColloqui()
        {
            var candidati = await _context.Colloqui.ToListAsync();
            if (candidati != null)
                return Ok(candidati);
            else
                return NotFound();
        }

        // GET: api/Colloquio/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Colloquio>> GetColloquio(int id)
        {
            var trovatoColloquio = await _context.Colloqui.FindAsync(id);

            if (trovatoColloquio == null)
            {
                return NotFound();
            }

            return Ok(trovatoColloquio);
        }


        // DELETE: api/Colloquio/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColloquio(int id)
        {
            var colloquio = await _context.Colloqui.FindAsync(id);
            if (colloquio == null)
            {
                return NotFound();
            }

            _context.Colloqui.Remove(colloquio);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        // POST: api/Colloquio
        [HttpPost]
        public async Task<IActionResult> AddColloquio(Colloquio nuovoColloquio)
        {
            // Add the new Candidato to the context and save changes to the database
            await _context.Colloqui.AddAsync(nuovoColloquio);
            await _context.SaveChangesAsync();
            return Ok(nuovoColloquio);
        }

    }
}
