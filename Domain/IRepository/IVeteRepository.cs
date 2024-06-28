using Domain.Entities;

namespace Domain.IRepository
{
    public interface IVeteRepository
    {
        Veterinario Add(Veterinario veterinario);
        void Delete(Veterinario voterinario);
        void Update(Veterinario veterinario);
        List<Veterinario> GetAll();
        Veterinario? GetById(int id);
        void SaveChanges();

    }
}
