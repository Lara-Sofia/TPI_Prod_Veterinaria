using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class MascotaConDiagnosticoDTO
    {
        public string NameDiagnostico { get; set; }
        public string DescripcionComponente { get; set; }
        public List<DiagnosticoDTO> Diagnosticos { get; set; }
    }
}
