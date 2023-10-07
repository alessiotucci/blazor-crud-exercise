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


        public Dipendente() : base() { }

        public Dipendente(string _nome, string _cognome, string _skillname)
        {
            Nome = _nome;
            Cognome = _cognome;
            SkillName = _skillname;
        }
    }
}
