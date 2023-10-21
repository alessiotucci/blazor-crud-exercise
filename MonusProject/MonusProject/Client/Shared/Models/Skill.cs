using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonusProject.Client.Shared.Models
{
    public class Skill
    {
        [Key] 
        
        public int SkillId { get; set; }

        public string SkillName { get; set; }

        public ICollection<Candidato> CandidatoSkillato { get; set; }
        public ICollection<Dipendente> DipendenteSkillato { get; set; }
        public Skill()
        { 
           CandidatoSkillato = new List<Candidato>();
           DipendenteSkillato = new List<Dipendente>();
        }

    }
}
