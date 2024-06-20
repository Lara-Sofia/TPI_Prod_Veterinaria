using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Infra.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Diagnostico> Diagnosticos { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<Veterinario> Veterinarios { get; set; }
    }
}
