using Microsoft.EntityFrameworkCore;
using ClienteApi2.Models;

namespace ClienteApi2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
