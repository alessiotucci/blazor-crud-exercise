using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonusProject.Client.Shared.Models;
using MonusProject.Server.Data;

namespace MonusProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ColloquioContext _context;

        public SkillController(ColloquioContext context)
        {
            _context = context;
        }

        //GET : api/Skill
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Skill>>> GetSkills()
        {
            var skills = await _context.Skills.ToListAsync<Skill>();
            if (skills != null)
            return Ok(skills);
            return BadRequest();
        }
    }
}
