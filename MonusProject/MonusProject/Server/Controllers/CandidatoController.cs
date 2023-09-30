using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

    }
}
