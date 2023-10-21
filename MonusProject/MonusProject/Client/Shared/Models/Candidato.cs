using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonusProject.Client.Shared.Models
{
    public class Candidato : Persona
    {
        [Key] 
        public int CandidatoId { get; set; }

        public ICollection<Skill> SkillCandidato { get; set; }
        public Candidato() :base() { }

        public Candidato(string _nome, string _cognome)
        {
            Nome = _nome;
            Cognome = _cognome;
            SkillCandidato = new List<Skill>();
        }
    }

}
