using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Diagnostico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("MascotaId")]
        public int MascotaId { get; set; }
        public Mascota Mascota { get; set; }
        public int VeterinarioId { get; set; }
        public ICollection<DiagnosticoLinea> DiagnosticoLineas { get ; set; } 
        
    }
}
