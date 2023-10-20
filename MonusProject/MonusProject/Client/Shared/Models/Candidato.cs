using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonusProject.Client.Shared.Models
{
    public class Candidato : Persona
    {
        [Key] 
        public int CandidatoId { get; set; }
        public ICollection<Skill> Skills { get; set; }

        public Candidato() : base() { }

        //construttore custom 
       public Candidato(string _nome, string _cognome) : base()
        {
            Nome = _nome;
            Cognome = _cognome;
            Skills = new List<Skill>(); 

        }
        
    }
}
