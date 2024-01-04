using Api.Entites;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class Datacontext : DbContext
    {
        public Datacontext(DbContextOptions<Datacontext> options) : base(options)
        {

        }
        public DbSet<AppUser> AppUsers { get; set; }

    }
    
}