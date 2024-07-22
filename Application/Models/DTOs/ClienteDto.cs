using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.DTOs
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }

        public static ClienteDto Create(Cliente cliente)
        {
            var dto = new ClienteDto();
            dto.Id = cliente.Id;
            dto.Name = cliente.Name;
            dto.Email = cliente.Email;
            dto.Activo = cliente.Activo;
            return dto;
        }

        public static List<ClienteDto> CreateList(IEnumerable<Cliente> clientes)
        {
            List<ClienteDto> listDto = [];
            foreach (var clits in clientes)
            {
                listDto.Add(Create(clits));
            }
            return listDto;
        }
    }
}
