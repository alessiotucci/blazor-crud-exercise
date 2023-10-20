using System.ComponentModel.DataAnnotations;

namespace MonusProject.Client.Shared.Models
{
    public class Sede
    {
        [Key]
        public int SedeId { get; set; }

        public string SedeName { get; set; }

        public string Indirizzo { get; set;}

        public ICollection<Dipendente>? Dipendents { get; set; }


        public Sede()
        {
         Dipendents = new List<Dipendente>();
        }

    }
}
