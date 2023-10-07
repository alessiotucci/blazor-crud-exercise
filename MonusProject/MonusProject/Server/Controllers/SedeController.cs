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
            if (sedi != null)
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
            _context.Sedi.AddAsync(nuovaSede);
            await _context.SaveChangesAsync();
            return Ok(nuovaSede);
        }
    }
}
