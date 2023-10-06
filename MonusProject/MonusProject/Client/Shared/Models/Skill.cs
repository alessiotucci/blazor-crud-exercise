using System.ComponentModel.DataAnnotations;

namespace MonusProject.Client.Shared.Models
{
    public class Skill
    {
        [Key] 
        
        public int SkillId { get; set; }

        public string SkillName { get; set; }

        public Skill() { }
    }
}
