using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonusProject.Client.Shared.Models
{
    public class Dipendente : Persona
    {
        [Key]
        public int DipendenteId { get; set; }
        public ICollection<Skill>? Skills { get; set; }

        // Aggiunta della proprietà nullable SedeId
        public int? SedeId { get; set; }

        // Aggiunta della proprietà di navigazione per Sede
        public Sede? Sede { get; set; }

        public Dipendente()
        {
            Skills = new List<Skill>();
        }
    }
}
