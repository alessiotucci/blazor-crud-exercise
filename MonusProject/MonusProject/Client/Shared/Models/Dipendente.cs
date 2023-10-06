using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonusProject.Client.Shared.Models
{
    public class Dipendente : Persona
    {
        [Key]
        public int DipendenteId { get; set; }
        [ForeignKey(nameof(SkillName))]
        public string SkillName { get; set; }

        public Dipendente() { }
    }
}
