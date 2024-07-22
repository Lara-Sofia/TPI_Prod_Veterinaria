using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Requets
{
    public class DiagnosticoLineaDto
    {
        public string Description { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
