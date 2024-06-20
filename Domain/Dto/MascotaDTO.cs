using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class MascotaDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Estado { get; set; }
        public ICollection<Diagnostico> Diagnosticos { get; set; }
    }
}
