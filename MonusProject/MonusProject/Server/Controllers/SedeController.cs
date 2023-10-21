using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonusProject.Client.Shared.Models;
using MonusProject.Server.Data;

namespace MonusProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SedeController : ControllerBase
    {
        private readonly ColloquioContext _context;
        public SedeController(ColloquioContext context) 
        {
            _context = context;
        }

        //GET : api/Controller
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sede>>> GetSede()
        {
            var sede = await _context.Sedi.ToListAsync();
            return Ok(sede);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Sede>> GetSede(int id)
        {
            var findSede = await _context.Sedi.FindAsync(id);

            if (findSede == null)
            {
                return NotFound();
            }

            return Ok(findSede);
        }

        //POST: api/Sede
        [HttpPost]
        public async Task<IActionResult> AddSede(Sede nuovoSede)
        {
            //Add the new sede to the context and save changes to the database
            await _context.Sedi.AddAsync(nuovoSede);
            await _context.SaveChangesAsync();
            return Ok(nuovoSede);
        }

        // DELETE: api/Sede
        [HttpDelete("{id:int}")]

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
    }
}
