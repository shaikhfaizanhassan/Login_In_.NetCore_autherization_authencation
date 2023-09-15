using Microsoft.EntityFrameworkCore;

namespace RoleBaseAuthen_Autroziation.Models
{
    public class RegisterDbContext : DbContext
    {
        public RegisterDbContext(DbContextOptions<RegisterDbContext>options):base (options) 
        { }
        public DbSet<Register> registers { get; set; }
    }
}
