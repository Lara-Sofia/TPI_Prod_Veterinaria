using Domain.Entities;

namespace Domain.IRepository
{
    public interface IVeteRepository
    {
        Veterinario Add(Veterinario veterinario);
        void Delete(Veterinario veterinario);
        void Update(Veterinario veterinario);
        List<Veterinario> GetAll();
        Veterinario? GetById(int id);
        void SaveChanges();

    }
}
