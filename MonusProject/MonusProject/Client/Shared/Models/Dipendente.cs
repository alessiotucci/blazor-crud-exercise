using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonusProject.Client.Shared.Models
{
    public class Dipendente : Persona
    {
        [Key]
        public int DipendenteId { get; set; }

        public ICollection<Skill> SkillDipendente { get; set; }

        public Dipendente() : base() 
        { 
            
        }

        public Dipendente(string _nome, string _cognome)
        {
            Nome = _nome;
            Cognome = _cognome;
            SkillDipendente = new List<Skill>();
        }
    }
}
