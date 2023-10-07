using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonusProject.Client.Shared.Models
{
    public class Sede
    {
        [Key]
        public int SedeId { get; set; }

        [ForeignKey(nameof(SedeId))]

        public string SedeName { get; set; }

        public string Indirizzo { get; set;}

        public Sede() :base() { }

        public Sede(string _nome, string _indirizzo)
        {
            SedeName = _nome;
            Indirizzo = _indirizzo;
        }

    }
}
