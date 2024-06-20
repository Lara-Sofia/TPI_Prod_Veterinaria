using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IVeteServices
    {
        Veterinario GetVeteById(int id);
        IEnumerable<User> GetAllUsers();
        int AddVete(Veterinario userVete);
        bool DeleteUser(int id);
        bool UpdateClientes(Cliente userCliente);
    }
}
