using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonusProject.Client.Shared.Models
{
    public class Candidato : Persona
    {
        [Key] 
        public int CandidatoId { get; set; }

		[ForeignKey(nameof(SkillName))]
        public string SkillName { get; set; }

        public Candidato() :base() { }

        public Candidato(string _nome, string _cognome, string _skillname)
        {
            Nome = _nome;
            Cognome = _cognome;
            SkillName = _skillname;
        }
    }

}
