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
    }
}
