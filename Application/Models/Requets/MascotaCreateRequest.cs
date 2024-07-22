using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Requets
{
    public class MascotaCreateRequest
    {
        public int ClienteId { get; set; }
        public string Name { get; set; }
        public string Animal { get; set; }
        //public bool Estado { get; set; }
    }
}
