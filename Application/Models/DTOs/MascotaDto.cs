using Domain.Entities;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Models.DTOs
{
    public class MascotaDto
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        
        [JsonIgnore]
        public Cliente Cliente { get; set; }
        public string ClienteName { get; set; }
        public string Name { get; set; }
        public EstadoMascota Estado {  get; set; }

        public static MascotaDto Create(Mascota mascota)
        {
            var dto = new MascotaDto();
            dto.Id = mascota.Id;
            dto.ClienteId = mascota.ClienteId;
            dto.ClienteName = mascota.Cliente.Name;
            dto.Name = mascota.Name;
            dto.Estado = mascota.Estado;
            return dto;
        }

        public static List<MascotaDto> CreateList(IEnumerable<Mascota> mascotas)
        {
            List<MascotaDto> listDto = [];
            foreach (var masc in mascotas)
            {
                listDto.Add(Create(masc));
            }
            return listDto;
        }
    }
}
