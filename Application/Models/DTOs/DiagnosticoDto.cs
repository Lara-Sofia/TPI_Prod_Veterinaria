using Application.Models.Requets;
using Domain.Entities;
using System.Text.Json.Serialization;

namespace Application.Models.DTOs
{
    public class DiagnosticoDto
    {
        public int Id { get; set; }

        [JsonIgnore]
        public Mascota Mascota { get; set; }
        public int MascotaId { get; set; }
        public string MascotaName { get; set; }
        public string MascotaClienteName { get; set; }
        public int VeterinarioId { get; set; }
        public ICollection<DiagnosticoLineaDto> DiagnosticoLineas { get; set; }

        public static DiagnosticoDto Create(Diagnostico diagnostico)
        {
            var dto = new DiagnosticoDto
            {
                Id = diagnostico.Id,
                MascotaId = diagnostico.MascotaId,
                MascotaName = diagnostico.Mascota.Name,
                MascotaClienteName = diagnostico.Mascota.Cliente.Name,
                VeterinarioId = diagnostico.VeterinarioId,
                DiagnosticoLineas = diagnostico.DiagnosticoLineas.Select(linea => new DiagnosticoLineaDto
                {
                    Description = linea.Description,
                }).ToList()
            };

            return dto;
        }

        public static List<DiagnosticoDto> CreateList(IEnumerable<Diagnostico> diagnosticos)
        {
            List<DiagnosticoDto> listDto = [];
            foreach (var diag in diagnosticos)
            {
                listDto.Add(Create(diag));
            }
            return listDto;
        }
    }
    
}
