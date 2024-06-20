﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface IClienteRepository
    {
        ICollection<Mascota> GetMascotas(int clienteId); 
    }
}
