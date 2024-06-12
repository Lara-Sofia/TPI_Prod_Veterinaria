using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cliente : User
    {
        public ICollection<Mascota> Mascotas {  get; set; } = new List<Mascota>();
    }
}
