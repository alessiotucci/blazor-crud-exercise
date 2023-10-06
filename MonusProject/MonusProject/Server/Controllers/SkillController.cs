﻿using Microsoft.AspNetCore.Http;
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
    public class SkillController : ControllerBase
    {
        private readonly ColloquioContext _context;

        // constructor ok ?
        public SkillController(ColloquioContext context)
        {
            _context = context;
        }

        // GET: api/Colloquio
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Skill>>> GetSkill()
        {
            var skill = await _context.Skills.ToListAsync<Skill>();
            if (skill != null)
                return Ok(skill);
            else
                return NotFound();
          
        }
        // DELETE: api/Skill/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            var piccola_skill = await _context.Skills.FindAsync(id);
            if (piccola_skill == null)
            {
                return NotFound();
            }

            _context.Skills.Remove(piccola_skill);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        // POST: api/Skill
        [HttpPost]
        public async Task<IActionResult> AddSkill(Skill nuovaSkill)
        {
            // Add the new Candidato to the context and save changes to the database
            _context.Skills.AddAsync(nuovaSkill);
            await _context.SaveChangesAsync();
            return Ok(nuovaSkill);
        }

    }
}
