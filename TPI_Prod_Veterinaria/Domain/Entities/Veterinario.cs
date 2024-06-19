using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Veterinario : User
    {
        //especificar en el context segunda 
        public int Matricula {  get; set; }
        public ICollection<Diagnostico> Diagnosticos { get; set; } = new List<Diagnostico>();
    }
}
