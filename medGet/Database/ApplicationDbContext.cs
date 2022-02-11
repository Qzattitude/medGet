using medGet.Models;
using Microsoft.EntityFrameworkCore;

namespace medGet.Database
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<MedicineDetails> MedicineDetails { get; set; }
    }
}
