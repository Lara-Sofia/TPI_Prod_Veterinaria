using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserServices
    {
        User? Get(string name);
        List<User> GetAll();
        User Add(UserDto userDto);
        bool Delete(int id);
        bool Update(User user);
    }
}
