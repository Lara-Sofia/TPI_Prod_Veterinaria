using Application.Interfaces;
using Application.Models.DTOs;
using Application.Models.Requets;
using Domain.Entities;
using Domain.Exceptions;
using Domain.IRepository;

namespace Application.Services
{
    public class VeteServices : IVeteServices
    {
        private readonly IVeteRepository _veteRepository;
     
        public VeteServices(IVeteRepository veteRepository)
        {
            _veteRepository = veteRepository;
            
        }

        public List<VeterinarioDto> GetAll()
        {
            var list = _veteRepository.GetAll();
            return VeterinarioDto.CreateList(list);
        }

        public VeterinarioDto GetById(int id)
        {
            var obj = _veteRepository.GetById(id)
                ?? throw new NotFoundException(nameof(id)); //como un if
            var dto = VeterinarioDto.Create(obj);
            return dto;
        }

        public Veterinario Create(VeterinarioCreateRequets veterinarioCreateRequets)
        {
            var obj = new Veterinario();
            obj.Name = veterinarioCreateRequets.Name;
            obj.Email = veterinarioCreateRequets.Email;
            obj.Password = veterinarioCreateRequets.Password;
            obj.Matricula = veterinarioCreateRequets.Matricula;
            return _veteRepository.Add(obj);
        }

        public void Update(int id, VeterinarioUpdateRequets veterinarioUpdateRequets)
        {
            var obj = _veteRepository.GetById(id);

            if (obj == null)
                throw new NotFoundException(nameof(Veterinario), id);

            if (veterinarioUpdateRequets.Name != string.Empty) obj.Name = veterinarioUpdateRequets.Name;

            if (veterinarioUpdateRequets.Email != string.Empty) obj.Email = veterinarioUpdateRequets.Email;

            if (veterinarioUpdateRequets.Password != string.Empty) obj.Password = veterinarioUpdateRequets.Password;

            _veteRepository.Update(obj);
        }

        public void Delete(int id)
        {
            var obj = _veteRepository.GetById(id);

            if (obj == null) throw new NotFoundException(nameof(Veterinario), id);

            _veteRepository.Delete(obj);
        }


    }
}
