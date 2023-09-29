using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonusProject.Client.Shared.Models
{
    public class Colloquio
    {
        [Key] 
        public int ColloquioId { get; set; }

        public DateTime RaiseTimeUTC { get; set; }
        [ForeignKey(nameof(CandidatoId))]
        public int CandidatoId { get; set; }
        [ForeignKey(nameof(DipendenteId))]
        public int DipendenteId { get; set; }
        
        
    }
}
