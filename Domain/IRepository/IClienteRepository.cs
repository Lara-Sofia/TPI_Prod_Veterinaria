﻿
using Domain.Entities;

namespace Domain.IRepository
{
    public interface IClienteRepository
    {
        Cliente Add(Cliente cliente);
        void Delete(Cliente cliente);
        void Update(Cliente cliente);
        List<Cliente> GetAll();
        List<Cliente> GetAllInactivos();
        Cliente? GetById(int id);
        void SaveChanges();
    }
}
