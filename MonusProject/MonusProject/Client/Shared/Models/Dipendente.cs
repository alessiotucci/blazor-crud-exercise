using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonusProject.Client.Shared.Models
{
    public class Dipendente : Persona
    {
        [Key]
        public int DipendenteId { get; set; }
        public ICollection<Skill> Skills { get; set; }


        public Dipendente() { }
    }
}
