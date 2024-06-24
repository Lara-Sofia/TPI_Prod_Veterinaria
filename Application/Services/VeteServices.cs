

using Application.Interfaces;
using ConsultaAlumnos.Domain.Exceptions;
using Domain.Dto;
using Domain.Entities;
using Domain.IRepository;
using Domain.ViewModels;

namespace Application.Services
{
    public class VeteServices : IVeteServices
    {
        private readonly IVeteRepository _userRepository;
        public VeteServices(IVeteRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool AddVete(VeterinarioViewModel veterinario)
        {
            return _userRepository.AddVete(veterinario);
        }

        public bool DeleteVeterinario(int id)
        {
            var obj = _userRepository.GetVeteById(id);
            if (obj == null)
            {
                throw new NotFoundException(nameof(Veterinario), id);
            }
            return _userRepository.DeleteVeterinario(id);

        }

        public List<VeterinarioDto?> GetAllVete()
        {
            return _userRepository.GetAllVete();
        }

        public VeterinarioDto GetVeteById(int id)
        {
            return _userRepository.GetVeteById(id);
        }

        public bool UpdateVete(VeterinarioViewModel userVeterinario)
        {
            return _userRepository.UpdateVete(userVeterinario);
        }

        public bool ReActivarVete (int id)
        {
            var obj = _userRepository.GetVeteById(id);
            if (obj == null)
            {
                throw new NotFoundException(nameof(Veterinario), id);
            }
            return _userRepository.ReActivarVete(id);
        }
    }
}
