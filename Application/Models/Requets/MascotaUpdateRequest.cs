using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Requets
{
    public class MascotaUpdateRequest
    {
        public string Name { get; set; } = string.Empty;
        public bool Estado { get; set; } = true;
        public int ClientId { get; set; } = 0;
    }
}
