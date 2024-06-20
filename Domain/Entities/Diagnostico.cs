using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Diagnostico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(180)]
        public string Descripcion { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; private set; } = DateTime.Now;

        public Mascota Mascota { get; set; }
        
    }
}
