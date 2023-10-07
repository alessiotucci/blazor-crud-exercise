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
    }
}
