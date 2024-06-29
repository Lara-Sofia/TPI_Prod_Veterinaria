using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.DTOs
{
    public class UserDto
    {
        //podemos eliminar Si
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        //public string Password { get; set; }

        public static UserDto Create(User user)
        {
            var dto = new UserDto();
            dto.Id = user.Id;
            dto.Name = user.Name;
            dto.Email = user.Email;

            return dto;
        }
    }
}
