using ApiGestores.models;
using Microsoft.EntityFrameworkCore;

namespace ApiGestores.context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions <AppDbContext> options):base(options)
        {
                
        }
        public DbSet<gestores_bd> gestores_bd { get; set; }

    }
}
