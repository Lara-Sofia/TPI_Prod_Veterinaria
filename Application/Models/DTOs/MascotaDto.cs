using Domain.Entities;
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
        public int ClienteId { get; set; }
        
        [JsonIgnore]
        public Cliente Cliente { get; set; }
        public string ClienteName { get; set; }
        public string Name { get; set; }

        public static MascotaDto Create(Mascota mascota)
        {
            var dto = new MascotaDto();
            dto.ClienteId = mascota.ClienteId;
            //dto.Cliente.Name = mascota.Cliente.Name;
            dto.ClienteName = mascota.Cliente.Name;
            dto.Name = mascota.Name;
            return dto;
        }
    }
}
