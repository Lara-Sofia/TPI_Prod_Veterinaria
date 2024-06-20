

using Application.Interfaces;
using Application.Models;
using ConsultaAlumnos.Domain.Exceptions;
using Domain.Entities;
using Domain.IRepository;

namespace Application.Services
{
    public class VeteServices : IVeteServices
    {
        private readonly IVeteRepository _userRepository;
        public VeteServices(IVeteRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public int AddVete(Veterinario userVete)
        {
            var obj = new Veterinario();
            obj.Name = userVete.Name;
            obj.Matricula = userVete.Matricula;
            obj.Email = userVete.Email;
            obj.Password = userVete.Password;

            return _userRepository.AddVete(obj);

        }

        public bool DeleteUser(int id)
        {
            var obj = _userRepository.GetVeteById(id);
            if (obj == null)
            {
                throw new NotFoundException(nameof(Veterinario), id);
            }
            return _userRepository.DeleteUser(id);

        }

        public IEnumerable<User?> GetAllUsers()
        {
            var list = _userRepository.GetAllUsers();

            return list;
        }

        public Veterinario GetVeteById(int id)
        {
            return _userRepository.GetVeteById(id);
        }

        public bool UpdateClientes(Cliente userCliente)
        {
            return _userRepository.UpdateClientes(userCliente);
        }
    }
}
