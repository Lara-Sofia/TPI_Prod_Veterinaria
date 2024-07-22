using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Requets
{
    public class DiagnosticoCreateRequest
    {
        public int MascotaId { get; set; }
        public int VeterinarioId { get; set; }
        public ICollection<DiagnosticoLineaDto> DiagnosticoLineasDto { get; set; }
        
    }

}
