using Domain.Entities;


namespace Domain.IRepository
{
    public interface IVeteRepository
    {
        Veterinario GetVeteById(int id);
        List<User> GetAllUsers();
        int AddVete(Veterinario userVete);
        bool DeleteUser(int id);
        bool UpdateClientes(Cliente userCliente);
    }
}
