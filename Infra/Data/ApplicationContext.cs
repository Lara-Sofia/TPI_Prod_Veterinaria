using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Infra.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
    }
}
