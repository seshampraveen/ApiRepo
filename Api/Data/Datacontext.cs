using Api.Entites;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class Datacontext : DbContext
    {
        public Datacontext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<AppUser> Users { get; set; }





    }
    
}