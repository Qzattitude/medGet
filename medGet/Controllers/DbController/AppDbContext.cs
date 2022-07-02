using medGet.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace medGet.Controllers.DbController
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        public DbSet<MedicineDetails> MedicineDetails { get; set; }
        public DbSet<PriceVariation> PriceVariation { get; set; }   
        //public DbSet<GenericModel> GenericModel { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            const string ADMIN_ID = "49F70FB3-4F6E-4168-A912-A38658510A9F";
            //const string ROLE_ID = ADMIN_ID;
            const string USER_ID = "4DABBE26-AD0E-4EC7-AA6F-A615E951BD83";
            const string PROVIDER_ID = "25E46705-C687-4728-9A08-F81C0EAAFBE7";

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = ADMIN_ID,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = USER_ID,
                    Name = "User",
                    NormalizedName = "USER"
                },
                new IdentityRole
                {
                    Id = PROVIDER_ID,
                    Name = "Provider",
                    NormalizedName = "PROVIDER"
                }

            );

            var hasher = new PasswordHasher<ApplicationUser>();
            builder.Entity<ApplicationUser>()
                .HasData(
                new ApplicationUser
                {
                    Id = ADMIN_ID,
                    UserName = "Admin@2022",
                    NormalizedUserName = "ADMIN@2022",
                    Email = "mukit@gmail.com",
                    NormalizedEmail = "mukit@gmail.com",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Mukit@2022"),
                    SecurityStamp = string.Empty
                });
            //SeedingData
            builder.Entity<IdentityUserRole<string>>().HasData(
                    new IdentityUserRole<string>
                    {
                        RoleId = ADMIN_ID,
                        UserId = ADMIN_ID
                    }
                );

        }
    }
}
