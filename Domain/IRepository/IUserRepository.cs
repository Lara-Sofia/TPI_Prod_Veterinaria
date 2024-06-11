using Domain.Entities;


namespace Domain.IRepository
{
    public interface IUserRepository
    {
        User? Get(string name);
    }
}
