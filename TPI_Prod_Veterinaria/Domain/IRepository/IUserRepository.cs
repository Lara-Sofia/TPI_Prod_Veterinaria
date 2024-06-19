using Domain.Entities;


namespace Domain.IRepository
{
    public interface IUserRepository
    {
        User? Get(string name);
        List<User> GetAll();
        User Add(User user);
        bool Delete(int id);
        bool Update (User user);
    }
}
