using Microsoft.EntityFrameworkCore;

namespace MeuProjetoApi.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TAB_Produtos> tab_produtos { get; set; } 
    }
}
