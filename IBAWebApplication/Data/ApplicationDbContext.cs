using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IBAWebApplication.Models;

namespace IBAWebApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<IBAWebApplication.Models.IBA_Trainee> IBA_Trainee { get; set; } = default!;
    }
}
