using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonusProject.Client.Shared.Models;
using MonusProject.Server.Data;

namespace MonusProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColloquioController : ControllerBase
    {
        private readonly ColloquioContext _context;

        public ColloquioController(ColloquioContext context)
        {
            _context = context;
        }

        //GET : api/Colloquio
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Colloquio>>> GetColloqui()
        {
            var colloqui = await _context.Colloqui.ToListAsync();
            return Ok(colloqui);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Colloquio>> GetColloquio(int id)
        {
            var findColloquio = await _context.Colloqui.FindAsync(id);

            if (findColloquio == null)
            {
                return NotFound();
            }

            return Ok(findColloquio);
        }

        //POST: api/Colloquio
        [HttpPost]
        public async Task<IActionResult> AddColloquio(Colloquio nuovoColloquio)
        {
            //Add the new colloquio to the context and save changes to the database
            _context.Colloqui.AddAsync(nuovoColloquio);
            await _context.SaveChangesAsync();
            return Ok(nuovoColloquio);
        }

        // DELETE: api/Colloquio
        [HttpDelete("{id:int}")]

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
    }
}
