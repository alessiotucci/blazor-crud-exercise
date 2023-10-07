using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonusProject.Client.Shared.Models;
using MonusProject.Server.Data;


namespace MonusProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DipendenteController : ControllerBase
    {
        private readonly ColloquioContext _context;

        public DipendenteController(ColloquioContext context)
        {
            _context = context;
        }

        //GET : api/Dipendente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dipendente>>> GetDipendente()
        {
            var dipendenti= await _context.Dipendenti.ToListAsync();
            return Ok(dipendenti);
        }



    }
}
