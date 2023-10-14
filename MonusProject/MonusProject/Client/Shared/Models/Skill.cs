using System.ComponentModel.DataAnnotations;

namespace MonusProject.Client.Shared.Models
{
    public class Skill
    {
        [Key] 
        
        public int SkillId { get; set; }

        public string SkillName { get; set; }
        public ICollection<Candidato> CandidatiSkillati { get; set; }
        public ICollection<Dipendente> DipendentiSkillati { get; set; }
        public Skill() { }
    }
}
