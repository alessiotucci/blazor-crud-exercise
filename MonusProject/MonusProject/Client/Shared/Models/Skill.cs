using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonusProject.Client.Shared.Models
{
    public class Skill
    {
        [Key] 
        
        public int SkillId { get; set; }

        [ForeignKey(nameof(SkillName))]

        public string SkillName { get; set; }

        public Skill() :base() { }

        public Skill(string _skillName)
        {
            SkillName = _skillName;
        }
    }
}
