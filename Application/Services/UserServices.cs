

using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Domain.IRepository;

namespace Application.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        //ver si va el dto o hacer una request
        public User Add(UserDto userdto)
        {
            var obj = new User();
            obj.Name = userdto.Name;
            obj.Email = userdto.Email;
            //obj.Password --> no lo tenemos en el dto, asi q revisar
            return _userRepository.Add(obj);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User? Get(string name)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
