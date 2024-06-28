using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.DTOs
{
    public class VeterinarioDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        // public string Password { get; set; }
        public bool Activo { get; set; }
        public int Matricula { get; set; }

        public  static VeterinarioDto Create(Veterinario veterinario)
        {
            var dto = new VeterinarioDto();
            dto.Id = veterinario.Id;
            dto.Name = veterinario.Name;
            dto.Email = veterinario.Email;
            dto.Matricula = veterinario.Matricula;
            dto.Activo = veterinario.Activo;
            return dto;
        }

        public static List<VeterinarioDto> CreateList(IEnumerable<Veterinario> veterinarios)
        {
            List<VeterinarioDto> listDto = [];
            foreach (var veter in veterinarios)
            {
                listDto.Add(Create(veter));
            }
            return listDto;
        }
    }
}
