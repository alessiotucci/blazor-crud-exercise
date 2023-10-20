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

        [HttpGet("{id}")]
        public async Task<ActionResult<Skill>> GetSkill(int id)
        {
            var findSkill = await _context.Skills.FindAsync(id);

            if (findSkill == null)
            {
                return NotFound();
            }

            return Ok(findSkill);
        }

        //POST: api/Skill
        [HttpPost]
        public async Task<IActionResult> AddSkill(Skill nuovaSkill)
        {
            //Add the new skill to the context and save changes to the database
            _context.Skills.AddAsync(nuovaSkill);
            await _context.SaveChangesAsync();
            return Ok(nuovaSkill);
        }

        // DELETE: api/Skill
        [HttpDelete("{id:int}")]

        public async Task<IActionResult> DeleteSkill(int id)
        {
            var skill = await _context.Skills.FindAsync(id);
            if (skill == null)
            {
                return NotFound();
            }

            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
